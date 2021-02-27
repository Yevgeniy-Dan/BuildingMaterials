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

namespace BuildingMaterials.Pages.Materials
{
    public class EditModel : SupplierNamePageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public EditModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Material = await _context.Materials.FindAsync(id);

            if (Material == null)
            {
                return NotFound();
            }
            PopulateSuppliersDropDownList(_context);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var materialToUpdate = await _context.Materials.FindAsync(id);

            if (materialToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Material>(
                materialToUpdate,
                "material",
                 m => m.Name, m => m.Manufacturer, m => m.ShelfLife, m => m.UnitCost, m => m.MinimumBatch, m => m.SupplierID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.ID == id);
        }
    }
}
