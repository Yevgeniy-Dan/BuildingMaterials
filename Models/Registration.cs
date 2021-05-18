using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }

        public int FacilityID { get; set; }

        public int WarehouseID { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        public string linkEstimate { get; set; }

        public Facility Facility { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
