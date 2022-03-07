using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyRestaurant.BLL.ViewModels
{
    public class CategoryViewModel
    {
        public byte Id { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Category Name must be between 2 and 50 characters.")]
        public string Name { get; set; }
    }
}
