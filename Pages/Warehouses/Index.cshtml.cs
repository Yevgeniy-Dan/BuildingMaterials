using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Warehouses
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

        public PaginatedList<Warehouse> Warehouse { get; set; }

        public async Task OnGetAsync(string sortMaterial, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortMaterial;
            NameSort = string.IsNullOrEmpty(sortMaterial) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Warehouse> warehouseIQ = from w in _context.Warehouses
                                                select w;

            if (!string.IsNullOrEmpty(searchString))
            {
                warehouseIQ = warehouseIQ.Where(o => o.Order.Material.Name.Contains(searchString));
            }

            switch (sortMaterial)
            {
                case "name_desc":
                    warehouseIQ = warehouseIQ.OrderByDescending(o => o.Order.Material.Name);
                    break;
                default:
                    warehouseIQ = warehouseIQ.OrderBy(o => o.Order.Material.Name);
                    break;
            }

            int pageSize = ConstantValues.pageSize;

            Warehouse = await PaginatedList<Warehouse>.CreateAsync(warehouseIQ
                .Include(w => w.Order)
                .ThenInclude(w => w.Material), pageIndex ?? 1, pageSize);
        }
    }
}
