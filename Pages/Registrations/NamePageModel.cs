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
            var materialsQuery = from m in _context.Materials
                                 orderby m.Name
                                 select
                (new
                {
                    id = m.ID,
                    materialName = m.Name
                });

            MaterialNameML = new SelectList(materialsQuery, "id", "materialName", selectedMaterial);
        }

        public void PopulateFacilityDropDownList(BuildingMaterialsContext _context, object selectedMaterial = null)
        {
            var facilitiesQuery = from m in _context.Facilities
                                 orderby m.Name
                                 select
                (new
                {
                    id = m.ID,
                    facilityName = m.Name
                });

            FacilityNameFL = new SelectList(facilitiesQuery, "id", "facilityName", selectedMaterial);
        }
    }
}
