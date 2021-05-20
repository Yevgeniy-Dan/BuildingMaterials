using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Materials
{
    public class CreateModel : SupplierNamePageModel
    {
        private readonly BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateSuppliersDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Material Material { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyMaterial = new Material();

            if (await TryUpdateModelAsync<Material>(
                emptyMaterial,
                "material", // Префикс для значения формы.
                m => m.SupplierID, m => m.Name, m => m.Manufacturer, m => m.UnitCost, m => m.MinimumBatch, m => m.ShelfLife))
            {
                _context.Materials.Add(emptyMaterial);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Выбираем SupplierID, если TryUpdateModelAsync не работает.
            PopulateSuppliersDropDownList(_context, emptyMaterial.SupplierID);
            return Page();
        }
    }
}
