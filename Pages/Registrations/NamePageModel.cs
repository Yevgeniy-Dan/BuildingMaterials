using BuildingMaterials.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Pages.Registrations
{
    public class NamePageModel: PageModel
    {
        public SelectList MaterialNameML { get; set; }
        public SelectList FacilityNameFL { get; set; }


        public void PopulateMaterialDropDownList(BuildingMaterialsContext _context, object selectedMaterial = null)
        {
            var materialsQuery = from m in _context.Warehouses
                                 where m.Order.DeliveryDate.AddDays((double)m.Order.Material.ShelfLife) >= DateTime.Today 
                                 &&
                                 m.Quantity > 0
                                 orderby m.Order.Material.Name
                                 select
                (new
                {
                    id = m.ID,
                    NameMaterial = m.Order.Material.Name
                });

            MaterialNameML = new SelectList(materialsQuery, "id", "NameMaterial", selectedMaterial);
        }

        public void PopulateFacilityDropDownList(BuildingMaterialsContext _context, object selectedFacility = null)
        {
            var facilitiesQuery = from f in _context.Facilities
                                 orderby f.Name
                                 select
                (new
                {
                    id = f.ID,
                    facilityName = f.Name
                });

            FacilityNameFL = new SelectList(facilitiesQuery, "id", "facilityName", selectedFacility);
        }
    }
}
