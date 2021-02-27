using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }


        public string Phone { get; set; }


        public string ChiefFullName { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
