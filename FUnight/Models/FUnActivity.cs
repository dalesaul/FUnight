using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUnight.Models
{
    public class FUnActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SuggestedDate { get; set; }

        [Required]
        public bool FoodAvailable { get; set; }

        [Required]
        public double CostEstimate { get; set; }

        public int? Rating { get; set; }

        public int ApplicationUser_Id { get; set; }
        public int ActivityType_Id { get; set; }
        public int UserGroup_Id { get; set; }





    }
}
