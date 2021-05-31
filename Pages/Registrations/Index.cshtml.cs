using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Registrations
{
    public class IndexModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public IndexModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }
        public string MaterialNameSort { get; set; }
        public string FacilityNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Registration> Registration { get; set; }

        public async Task OnGetAsync(string sortRegistration, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = currentFilter;
            MaterialNameSort = string.IsNullOrEmpty(sortRegistration) ? "name_desc" : "";
            FacilityNameSort = sortRegistration == "Facility" ? "fac_desc" : "Facility";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;


            IQueryable<Registration> registrationIQ = from r in _context.Registrations
                                                      select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                registrationIQ = registrationIQ.Where(r => r.Warehouse.Order.Material.Name.Contains(searchString));
            }

            switch (sortRegistration)
            {
                case "name_desc":
                    registrationIQ = registrationIQ.OrderByDescending(r => r.Warehouse.Order.Material.Name);
                    break;
                case "Facility":
                    registrationIQ = registrationIQ.OrderBy(r => r.Facility.Name);
                    break;
                case "fac-desc":
                    registrationIQ = registrationIQ.OrderByDescending(r => r.Facility.Name);
                    break;
                default:
                    registrationIQ = registrationIQ.OrderBy(r => r.Warehouse.Order.Material.Name);
                    break;
            }

            int pageSize = ConstantValues.pageSize;

            Registration = await PaginatedList<Registration>.CreateAsync(registrationIQ
                .Include(r => r.Facility)
                .Include(r => r.Warehouse)
                .ThenInclude(r => r.Order)
                .ThenInclude(r => r.Material), pageIndex ?? 1, pageSize);
        }
    }
}
