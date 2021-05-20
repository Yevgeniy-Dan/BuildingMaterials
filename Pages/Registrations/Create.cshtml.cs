using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Registrations
{
    public class CreateModel : NamePageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateMaterialDropDownList(_context);
            PopulateFacilityDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRegistration = new Registration();

            if (await TryUpdateModelAsync<Registration> (emptyRegistration, "registration", r => r.FacilityID, r => r.WarehouseID, r => r.Quantity, r => r.Unit, r => r.RegistrationDate))
            {
                _context.Registrations.Add(emptyRegistration);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateFacilityDropDownList(_context, emptyRegistration.FacilityID);
            PopulateMaterialDropDownList(_context, emptyRegistration.WarehouseID);

            return Page();
        }
    }
}
