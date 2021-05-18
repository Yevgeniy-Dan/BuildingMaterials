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
    public class DetailsModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public DetailsModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public Registration Registration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registration = await _context.Registrations
                .Include(r => r.Facility)
                .Include(r => r.Warehouse)
                .ThenInclude(r => r.Order)
                .ThenInclude(r => r.Material)
                .FirstOrDefaultAsync(m => m.RegistrationID == id);

            if (Registration == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
