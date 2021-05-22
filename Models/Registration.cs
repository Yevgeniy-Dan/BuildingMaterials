using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Registration
    {
        
        public string ErrorMessageQty { get; }

        public int RegistrationID { get; set; }

        [Display(Name = "Объект")]
        public int FacilityID { get; set; }

        [Display(Name = "Материал")]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите значние больше 0")]
        public int Quantity { get; set; }

        //[Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Объект")]
        public Facility Facility { get; set; }

        [Display(Name = "Материал")]
        public Warehouse Warehouse { get; set; }
    }
}
