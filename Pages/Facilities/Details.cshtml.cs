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
    public class DetailsModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public DetailsModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public Facility Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facilities
                .Include(f => f.Registrations)
                .ThenInclude(f => f.Warehouse)
                .ThenInclude(f => f.Order)
                .ThenInclude(f => f.Material)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
