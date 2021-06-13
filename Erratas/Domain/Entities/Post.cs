using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Post : EntityBase
    {
        [Display(Name = "Title image path")]
        public string TitleImagePath { get; set; }

        [Required(ErrorMessage = "Please, specify the post title.")]
        [Display(Name = "Post Title")]
        public override string Title { get; set; }

        [Display(Name = "Post Subtitle")]
        public override string Subtitle { get; set; }

        [Display(Name = "Post contents")]
        public override string Text { get; set; }

        [Display(Name = "Amount of likes")]
        public int AmountOfLikes { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}
