using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class AmountOrdersViewModel
    {
        [Display(Name="Наименование")]
        public string Name { get; set; }

        [Display(Name = "Цена/ед.")]
        public decimal UnitCost { get; set; }

        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }

        [Display(Name = "ID заказа")]
        public int OrderID { get; set; }

        [Display(Name = "Поставщик")]
        public string Supplier { get; set; }

        [Display(Name = "Дата доставки")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
    }
}
