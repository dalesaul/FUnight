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
        [Display(Name = "Suggested Date")]
        public DateTime SuggestedDate { get; set; }

        [Required]
        [Display(Name = "Is Food Available?")]
        public bool FoodAvailable { get; set; }

        [Required]
        [Display(Name = "Cost Estimate")]
        public double CostEstimate { get; set; }

        public int? Rating { get; set; }

        public string ApplicationUserId { get; set; }

        [Display(Name = "Activity Type")]
        public int ActivityTypeId { get; set; }

        [Display(Name = "User Group")]
        public int UserGroupId { get; set; }

        [Display(Name = "Additional Comments")]
        public string ActyTypeComment { get; set; }

        [Display(Name = "Activity Type")]
        public ActivityType ActivityType { get; set; }

        [Display(Name = "User Group")]
        public UserGroup UserGroup { get; set; }




    }
}
