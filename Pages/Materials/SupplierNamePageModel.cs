using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingMaterials.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuildingMaterials.Pages.Materials
{
    public class SupplierNamePageModel : PageModel
    {
        public SelectList SupplierNameSL { get; set; }

        public void PopulateSuppliersDropDownList(BuildingMaterialsContext _context, object selectedSupplier = null)
        {
            var suppliersQuery = from s in _context.Suppliers
                                 orderby s.ChiefFullName
                                 select s;

            SupplierNameSL = new SelectList(suppliersQuery.AsNoTracking(), "ID", "ChiefFullName", selectedSupplier);
        }
    }
}
