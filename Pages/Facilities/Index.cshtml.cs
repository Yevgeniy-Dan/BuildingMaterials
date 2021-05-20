using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Facilities
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

        public PaginatedList<Facility> Facility { get;set; }

        public async Task OnGetAsync(string sortFacility, string currentFilter, string searchString, int? pageIndex)
        {

            CurrentSort = sortFacility;
            NameSort = string.IsNullOrEmpty(sortFacility) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Facility> facilityIQ = from f in _context.Facilities
                                                select f;

            if (!string.IsNullOrEmpty(searchString))
            {
                facilityIQ = facilityIQ.Where(o => o.Name.Contains(searchString));
            }

            switch (sortFacility)
            {
                case "name_desc":
                    facilityIQ = facilityIQ.OrderByDescending(o => o.Name);
                    break;
                default:
                    facilityIQ = facilityIQ.OrderBy(o => o.Name);
                    break;
            }

            int pageSize = ConstantValues.pageSize;

            Facility = await PaginatedList<Facility>.CreateAsync(facilityIQ, pageIndex ?? 1, pageSize);
        }
    }
}
