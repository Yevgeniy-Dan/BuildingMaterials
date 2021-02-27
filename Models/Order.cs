using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int MaterialID { get; set; }

        public DateTime FillingDate { get; set; }

        public int Quantity { get; set; }


        public string Unit { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Material Material { get; set; }
    }
}
