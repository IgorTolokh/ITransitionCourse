using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Entities
{
    public class Item
    {
        [HiddenInput(DisplayValue = false)]
        public int ItemId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Name { get; set; }

        [Display(Name = "Тег")]
        [Required(ErrorMessage = "Пожалуйста, укажите Тег")]
        public string Tag { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
        public int customNumberField1 { get; set; }
        public int customNumberField2 { get; set; }
        public int customNumberField3 { get; set; }
        public string customOneLineField1 { get; set; }
        public string customOneLineField2 { get; set; }
        public string customOneLineField3 { get; set; }
        public string customTextField1 { get; set; }
        public string customTextField2 { get; set; }
        public string customTextField3 { get; set; }
        public DateTime customDateField1 { get; set; }
        public DateTime customDateField2 { get; set; }
        public DateTime customDateField3 { get; set; }
        public int customCheckBoxField1 { get; set; }
        public int customCheckBoxField2 { get; set; }
        public int customCheckBoxField3 { get; set; }
    }
}
