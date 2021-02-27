using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySupplier = new Supplier();

            if (await TryUpdateModelAsync<Supplier>(
                emptySupplier,
                "supplier",
                s => s.ChiefFullName, s => s.CompanyName, s => s.Address, s => s.Phone))
            {
                _context.Suppliers.Add(emptySupplier);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
