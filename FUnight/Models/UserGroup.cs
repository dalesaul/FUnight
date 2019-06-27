using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUnight.Models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ApplicationUser_Id { get; set; }

    }
}
