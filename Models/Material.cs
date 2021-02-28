using System;
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

        [Display(Name = "Поставщик")]
        public int SupplierID { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите наименование материала")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Изготовитель")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Пожалуйста, введите наименование материала")]
        public string Manufacturer { get; set; }

        [Display(Name = "Цена/ед.")]
        [Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [Display(Name = "Минимальная партия")]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите значние больше 0")]
        public int MinimumBatch { get; set; }

        [Display(Name = "Срок годности (в днях)")]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите значние больше 0")]
        public int ShelfLife { get; set; }

        public ICollection<Order> Orders { get; set; }
        [Display(Name = "Поставщик")]
        public Supplier Supplier { get; set; }
    }
}
