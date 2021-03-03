using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models.MaterialViewModels
{
    public class MaterialDeliveryData
    {
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
