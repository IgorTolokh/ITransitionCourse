using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Entities
{
    public class Collection
    {
        [HiddenInput(DisplayValue = false)]
        public int CollectionId { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
        public string Category { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string customNumberField1 { get; set; }
        public string customNumberField2 { get; set; }
        public string customNumberField3 { get; set; }
        public string customOneLineField1 { get; set; }
        public string customOneLineField2 { get; set; }
        public string customOneLineField3 { get; set; }
        public string customTextField1 { get; set; }
        public string customTextField2 { get; set; }
        public string customTextField3 { get; set; }
        public string customDateField1 { get; set; }
        public string customDateField2 { get; set; }
        public string customDateField3 { get; set; }
        public string customCheckBoxField1 { get; set; }
        public string customCheckBoxField2 { get; set; }
        public string customCheckBoxField3 { get; set; }
    }
}
