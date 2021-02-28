using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Supplier
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Компания"), StringLength(50, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите имя компании")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите адрес офиса")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Начальник")]
        [RegularExpression(@"^[А-Я]+[а-яА-я-""'\s-]*$", ErrorMessage = "Пожалуйста, введите корреткное значение")]
        public string ChiefFullName { get; set; }

        [Display(Name = "Материалы")]
        public ICollection<Material> Materials { get; set; }

    }
}
