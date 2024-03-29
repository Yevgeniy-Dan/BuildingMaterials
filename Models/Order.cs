﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Материал")]
        public int MaterialID { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите значение больше 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата доставки")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }

        [Display(Name = "Сумма к оплате")]
        public decimal AmountToPay { get; set; }

        [Display(Name = "Материал")]
        public Material Material { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
