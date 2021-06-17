using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Category : EntityBase
    {
        [Required(ErrorMessage = "Please, specify the category title name.")]
        [Display(Name = "Category Title")]
        public override string Title { get; set; }

        [Display(Name = "Category short description (subtitle)")]
        public override string Subtitle { get; set; }

        [Display(Name = "Category text")]
        public override string Text { get; set; }

        [Display(Name = "Title image path")]
        public string TitleImagePath { get; set; }
    }
}
