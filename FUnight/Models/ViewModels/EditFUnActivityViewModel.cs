using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUnight.Models.ViewModels
{
    public class EditFUnActivityViewModel
    {
        public FUnActivity FUnActivity { get; set; }

        public List<SelectListItem> ActivityTypeOptions { get; set; }

        public List<SelectListItem> UserGroupOptions { get; set; }

    }
}
