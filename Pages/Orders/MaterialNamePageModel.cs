using BuildingMaterials.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Pages.Orders
{
    public class MaterialNamePageModel : PageModel
    {
        public SelectList MaterialNameSL { get; set; }

        public void PopulateMaterialsDropDownList(BuildingMaterialsContext _context, object selectedMaterial = null)
        {
            var materialsQuery = from o in _context.Materials
                                 orderby o.Name
                                 select (new
                                 {
                                     id = o.ID,
                                     NameSupplier = o.Name + " | " + o.Supplier.ChiefFullName
                                 });

            MaterialNameSL = new SelectList(materialsQuery.AsNoTracking(), "id", "NameSupplier", selectedMaterial);
        }
    }
}
