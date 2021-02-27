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

namespace BuildingMaterials.Pages.Orders
{
    public class EditModel : MaterialNamePageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public EditModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order = await _context.Orders.FindAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            PopulateMaterialsDropDownList(_context, Order.MaterialID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderToUpdate = await _context.Orders.FindAsync(id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Order>(
                orderToUpdate,
                "order",
                 o => o.DeliveryDate, o => o.MaterialID, o => o.Quantity, o => o.Unit, o => o.FillingDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateMaterialsDropDownList(_context, Order.MaterialID);
            return Page();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
