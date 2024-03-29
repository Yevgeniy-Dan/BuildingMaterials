﻿using System;
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
        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRegistration = new Registration();

            if (await TryUpdateModelAsync<Registration>(
                emptyRegistration, 
                "registration",
                 r => r.FacilityID, r => r.WarehouseID, r => r.Quantity, r => r.Unit, r => r.RegistrationDate))
            {
                //Выбираем единицу измерения
                var warehouseIQ = from w in _context.Warehouses
                                  select w;

                emptyRegistration.Unit = warehouseIQ.Single(w => w.ID == emptyRegistration.WarehouseID).Unit;

                //Устанавливаем дату
                emptyRegistration.RegistrationDate = DateTime.Now;

                //Уменьшаем кол-во оставшегося товара на складе
                var materialToUpdate = await _context.Warehouses.FindAsync(warehouseIQ.Single(w => w.ID == emptyRegistration.WarehouseID).ID);

                materialToUpdate.Quantity -= emptyRegistration.Quantity;
                if (materialToUpdate.Quantity < 0)
                {
                    materialToUpdate.Quantity += emptyRegistration.Quantity;
                    ErrorMessage = $"Введите кол-во, равное {materialToUpdate.Quantity} или меньше";
                    PopulateMaterialDropDownList(_context);
                    PopulateFacilityDropDownList(_context);
                    return Page();
                }
                //Сохранить изменения
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
