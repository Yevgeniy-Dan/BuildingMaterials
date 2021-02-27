using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingMaterials.Models
{
    public class Material
    {
        public int ID { get; set; }

        public int SupplierID { get; set; }
        

        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public decimal UnitCost { get; set; }
        public int MinimumBatch { get; set; }
        public int ShelfLife { get; set; }

        public ICollection<Order> Orders { get; set; }
        public  Supplier Supplier { get; set; }
    }
}
