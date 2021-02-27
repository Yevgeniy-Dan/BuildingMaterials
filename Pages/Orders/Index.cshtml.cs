using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public IndexModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Order> Orders { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Order> ordersIQ = from o in _context.Orders
                                         select o;

            if (!string.IsNullOrEmpty(searchString))
            {
                ordersIQ = ordersIQ.Where(o => o.Material.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordersIQ = ordersIQ.OrderByDescending(o => o.Material.Name);
                    break;
                default:
                    ordersIQ = ordersIQ.OrderBy(o => o.Material.Name);
                    break;
            }

            int pageSize = ConstantValues.pageSize;

            Orders = await PaginatedList<Order>.CreateAsync(ordersIQ
                .Include(o => o.Material)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
