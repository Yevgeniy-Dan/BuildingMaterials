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
    public class DetailsModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public DetailsModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouses
                .Include(w => w.Order).FirstOrDefaultAsync(m => m.ID == id);

            if (Warehouse == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
