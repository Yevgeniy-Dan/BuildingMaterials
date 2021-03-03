using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BuildingMaterials.Data;
using BuildingMaterials.Models;
using BuildingMaterials.Pages.Materials;
using BuildingMaterials.Pages.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Models.MaterialViewModels;

namespace BuildingMaterials.Pages
{
    public class AdditionalModel : SupplierNamePageModel
    {
        private readonly BuildingMaterialsContext _context;
        public AdditionalModel(BuildingMaterialsContext context)
        {
            _context = context;
        }

        public Material Material { get; set; }
        public IList<AmountOrdersViewModel> AmountOrdersVM { get; set; }
        public DateTime CurrentDate { get; set; }
        public decimal SumOrders { get; set; }


        public async Task OnGetAsync()
        {
            PopulateSuppliersDropDownList(_context);
            AmountOrdersVM = await _context.Orders
                .Select(o => new AmountOrdersViewModel
                {
                    OrderID = o.ID,
                    Name = o.Material.Name,
                    UnitCost = o.Material.UnitCost,
                    Cost = o.Quantity * o.Material.UnitCost,
                    Supplier = o.Material.Supplier.ChiefFullName,
                    DeliveryDate = o.DeliveryDate
                }).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? searchSupplier, string startDateSearchString)
        {

            PopulateSuppliersDropDownList(_context);
            if (searchSupplier == null || startDateSearchString == null)
            {
                return RedirectToPage("./Additional");
            }
            if (startDateSearchString != null)
            {
                if (DateTime.TryParse(startDateSearchString, out DateTime dateValue))
                {
                    CurrentDate = dateValue;
                }
            }

            AmountOrdersVM = await _context.Orders
                .Where(o => o.Material.SupplierID == searchSupplier
                && o.DeliveryDate == CurrentDate)
                 .Select(o => new AmountOrdersViewModel
                 {
                     OrderID = o.ID,
                     Name = o.Material.Name,
                     UnitCost = o.Material.UnitCost,
                     Cost = o.Quantity * o.Material.UnitCost,
                     Supplier = o.Material.Supplier.ChiefFullName,
                     DeliveryDate = o.DeliveryDate
                 }).ToListAsync();
            SumOrders = Math.Round(AmountOrdersVM.Sum(o => o.Cost), 2);
            return Page();
        }
    }
}
