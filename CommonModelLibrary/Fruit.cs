using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModelLibrary
{
    public class Fruit
    {
        public int FruitId { get;set; }
        public string Genus { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Order { get; set; }
        public Nutritions Nutritions { get; set; }
        public int NutritionsID { get; set; }

    }
}
