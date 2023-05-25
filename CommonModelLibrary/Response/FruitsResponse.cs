using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModelLibrary.Response
{
    public class FruitsResponse
    {
        public string Genus { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Family { get; set; }
        public string Order { get; set; }
        public NutritionsResponse Nutritions { get; set; }
    }
}
