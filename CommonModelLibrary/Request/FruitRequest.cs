using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModelLibrary.Request
{
    public class FruitRequest
    {
        [Required(ErrorMessage ="Error: Body is missing")]
        public string Genus { get; set; }
        [Required(ErrorMessage = "Error: Body is missing")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Error: Body is missing")]
        public string Family { get; set; }
        [Required(ErrorMessage = "Error: Body is missing")]
        public string Order { get; set; }
        [Required(ErrorMessage = "Error: Body is missing")]
        public NutritionRequest Nutritions { get; set; }
    }
}
