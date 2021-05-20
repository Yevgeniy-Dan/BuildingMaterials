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

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите значение больше 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата доставки")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Наименование")]
        public Order Order { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
