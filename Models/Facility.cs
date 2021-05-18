using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Facility
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Наименование"), StringLength(50, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите имя компании")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите адрес объекта")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
