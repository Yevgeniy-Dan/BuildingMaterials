using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Warehouse
    {
        public int ID { get; set; }

        [Display(Name = "Наименование")]
        public int OrderID { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        [Display(Name = "Наименование")]
        public Order Order { get; set; }
    }
}
