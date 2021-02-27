using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Orders
{
    public class CreateModel : MaterialNamePageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateMaterialsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyOrder = new Order();

            if (await TryUpdateModelAsync<Order>(emptyOrder,
                "order",
                o => o.ID, o => o.MaterialID, o => o.FillingDate, o => o.Quantity, o => o.Unit, o => o.DeliveryDate))
            {
                _context.Orders.Add(emptyOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateMaterialsDropDownList(_context, emptyOrder.MaterialID);
            return Page();
        }
    }
}
