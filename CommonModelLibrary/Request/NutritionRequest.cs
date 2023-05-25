using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModelLibrary.Request
{
    public class NutritionRequest
    {
        public float carbohydrates { get; set; }
        public float protein { get; set; }
        public float fat { get; set; }
        public float calories { get; set; }
        public float sugar { get; set; }
    }
}
