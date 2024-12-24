using System;
using System.ComponentModel.DataAnnotations;

namespace MealRecorder.Models
{
    public class Meal
    {
        public int MealId { get; set; }

        [Required(ErrorMessage = "日付は必須です")]
        [Display(Name = "日付")]
        [DataType(DataType.Date)]
        public DateTime MealDate { get; set; }

        [Required(ErrorMessage = "食事の種類は必須です")]
        [Display(Name = "食事の種類")]
        public string MealType { get; set; }

        [Display(Name = "内容")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } // Nullable DateTime
    }
}