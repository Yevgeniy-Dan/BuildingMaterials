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
    public class CreateModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public CreateModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FacilityID"] = new SelectList(_context.Facilities, "ID", "Address");
        ViewData["WarehouseID"] = new SelectList(_context.Warehouses, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registrations.Add(Registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
