using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Warehouses
{
    public class IndexModel : PageModel
    {
        private readonly BuildingMaterials.Data.BuildingMaterialsContext _context;

        public IndexModel(BuildingMaterials.Data.BuildingMaterialsContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get; set; }

        public async Task OnGetAsync()
        {
            Warehouse = await _context.Warehouses
                .Include(w => w.Order)
                .ThenInclude(w => w.Material)
                .ToListAsync();
        }
    }
}
