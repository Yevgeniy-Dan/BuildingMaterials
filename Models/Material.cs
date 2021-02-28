﻿using System;
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
        
        [Display(Name ="Наименование")]
        [StringLength(100, MinimumLength=3)]
        public string Name { get; set; }

        [Display(Name ="Изготовитель")]
        [StringLength(50, MinimumLength =3)]
        public string Manufacturer { get; set; }

        [Display(Name ="Цена/ед.")]
        [Column(TypeName ="money"), DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [Display(Name ="Миимальная партия")]    
        public int MinimumBatch { get; set; }
        public int ShelfLife { get; set; }

        public ICollection<Order> Orders { get; set; }
        [Display(Name ="Поставщик")]
        public  Supplier Supplier { get; set; }
    }
}
