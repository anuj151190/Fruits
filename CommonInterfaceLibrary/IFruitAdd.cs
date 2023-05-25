using CommonModelLibrary;
using CommonModelLibrary.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaceLibrary
{
    public interface IFruitAdd
    {
        Task<bool> AddAsync(FruitRequest record, string Operation);
        Task<bool> validateFruitAsync(FruitRequest fruit, string Operation);
    }
}
