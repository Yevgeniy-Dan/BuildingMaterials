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
    public class DeleteModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public DeleteModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouses.FindAsync(id);

            if (Warehouse != null)
            {
                _context.Warehouses.Remove(Warehouse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
