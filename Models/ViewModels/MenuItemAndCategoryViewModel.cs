using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceApp.Models.ViewModels
{
    public class MenuItemAndCategoryViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<SubCategory> SubCategoryList { get; set; }
    }
}
