using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Materials
{
    public class IndexModel : PageModel
    {
        private readonly BuildingMaterialsContext _context;

        public IndexModel(BuildingMaterialsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string ManufacterSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Material> Materials { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentFilter = currentFilter;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ManufacterSort = sortOrder == "Manufacter" ? "manef_desc" : "Manufacter";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Material> materialsIQ = from m in _context.Materials
                                               select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                materialsIQ = materialsIQ.Where(m => m.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    materialsIQ = materialsIQ.OrderByDescending(m => m.Name);
                    break;
                case "Manufacter":
                    materialsIQ = materialsIQ.OrderBy(m => m.Manufacturer);
                    break;
                case "manef_desc":
                    materialsIQ = materialsIQ.OrderByDescending(m => m.Manufacturer);
                    break;
                default:
                    materialsIQ = materialsIQ.OrderBy(m => m.Name);
                    break;
            }

            int pageSize = ConstantValues.pageSize;//КОНФИГУРАЦИЯ
            Materials = await PaginatedList<Material>.CreateAsync(materialsIQ
                .Include(m => m.Supplier)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
