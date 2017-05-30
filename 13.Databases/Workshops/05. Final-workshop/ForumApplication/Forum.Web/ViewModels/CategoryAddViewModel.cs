using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.ViewModels
{
    public class CategoryAddViewModel 
    {
        [MinLength(5, ErrorMessage = "The length must be at least 5 letters long!")]
        public string Name { get; set; }

        public string ParentCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}