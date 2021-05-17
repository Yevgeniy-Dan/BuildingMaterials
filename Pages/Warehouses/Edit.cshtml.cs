using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Warehouses
{
    public class EditModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public EditModel(BuildingMaterials.Data.BuildingMaterialsContext context)
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
           ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "Unit");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Warehouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(Warehouse.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WarehouseExists(int id)
        {
            return _context.Warehouses.Any(e => e.ID == id);
        }
    }
}
