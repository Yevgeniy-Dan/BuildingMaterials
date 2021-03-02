using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models.MaterialViewModels
{
    public class UnusedMaterialsViewModel
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
