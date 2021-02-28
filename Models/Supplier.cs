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

        [Required]
        [Display(Name = "Компания"), StringLength(50, MinimumLength = 3, ErrorMessage ="Пожалуйста, введите имя компании")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Пожалуйста, введите адрес офиса")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона (например, +380(97)965-45-45)")]
        [RegularExpression(@"(^(?!\+.*\(.*\).*\-\-.*$)(?!\+.*\(.*\).*\-$)(\+[0-9]{1,3}\([0-9]{1,3}\)[0-9]{1}([-0-9]{0,8})?([0-9]{0,1})?)$)|(^[0-9]{1,4}$)", ErrorMessage = "Пожалуйста, введите корректный номер телефона")]
        public string Phone { get; set; }

        [Display(Name ="Начальник (имя, фамилия и отчество)")]
        [RegularExpression(@"(^[A-Z]{1}[a-z]{1,14} [A-Z]{1}[a-z]{1,14} [A-Z]{1}[a-z]{1,14}$)|(^[А-Я]{1}[а-я]{1,14} [А-Я]{1}[а-я]{1,14} [А-Я]{1}[а-я]{1,14}$)", ErrorMessage ="Пожалуйста, введите полное имя начальника")]
        public string ChiefFullName { get; set; }

        public ICollection<Material> Materials { get; }

    }
}
