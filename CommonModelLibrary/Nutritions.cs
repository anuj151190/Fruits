using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CommonModelLibrary
{
    public class Nutritions
    {
        public int NutritionsID { get; set; }
        public float carbohydrates { get; set; }
        public float protein { get; set; }
        public float fat { get; set; } 
        public float calories { get; set; }
        public float sugar { get; set; }
    }
}
