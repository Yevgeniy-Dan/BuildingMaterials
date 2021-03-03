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
        private readonly BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterialsContext context)
        {
            _context = context;
        }
        public string QuantityValidate { get; set; }
        public string DateValidate { get; set; }

        public IActionResult OnGet()
        {
            PopulateMaterialsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public Material Material { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyOrder = new Order();
            IQueryable<Material> materialsIQ = from m in _context.Materials
                                               select m;
            if (await TryUpdateModelAsync<Order>(emptyOrder,
                "order",
                o => o.ID, o => o.MaterialID, o => o.Quantity, o => o.Unit, o => o.DeliveryDate))
            {

                Material material = (from m in materialsIQ
                                     where m.ID == emptyOrder.MaterialID
                                     select m).Single();
                if (emptyOrder.Quantity < material.MinimumBatch)
                {
                    QuantityValidate = $"Количество не может быть меньше {material.MinimumBatch}";
                    PopulateMaterialsDropDownList(_context, Order.MaterialID);
                    return Page();
                }
                else if (emptyOrder.DeliveryDate < DateTime.Now)
                {
                    DateValidate = $"Пожалуйста, введите корректную дату";
                    PopulateMaterialsDropDownList(_context, Order.MaterialID);
                    return Page();
                }
                _context.Orders.Add(emptyOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateMaterialsDropDownList(_context, emptyOrder.MaterialID);
            return Page();
        }
    }
}
