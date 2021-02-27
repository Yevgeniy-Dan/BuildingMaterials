using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models.MaterialViewModels
{
    public class MaterialViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public decimal UnitCost { get; set; }

        public int MinimumBatch { get; set; }
        public int ShelfLife { get; set; }

        public string SupplierName { get; set; }
    }
}
