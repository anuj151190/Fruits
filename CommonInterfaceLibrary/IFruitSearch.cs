using CommonModelLibrary;
using CommonModelLibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaceLibrary
{
    public interface IFruitSearch 
    {
        public Task<List<FruitsResponse>> allAsync();
        public Task<List<FruitsResponse>> getAsync(SearchFilter sf, string Operation);
    }
}
