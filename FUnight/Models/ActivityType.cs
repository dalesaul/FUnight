using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUnight.Models
{
    public class ActivityType
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
