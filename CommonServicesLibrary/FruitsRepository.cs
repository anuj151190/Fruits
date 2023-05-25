using CommonInterfaceLibrary;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesLibrary
{
    public class FruitsRepository
    {
        private readonly IFruitAdd _fruitAdd;
        private readonly IFruitSearch _fruitSearch;
        private readonly ISqlDataContext _sqlDataContext;
        private SqlConnection? _con;
        private SqlCommand? _cmd;
        private SqlDataReader? _dr;
        private readonly IConfiguration _configuration;
        public FruitsRepository(IConfiguration configuration, IFruitAdd fruitAdd,IFruitSearch fruitSearch,ISqlDataContext sqlDataContext)
        {
            _configuration = configuration;
            _fruitAdd = fruitAdd;
            _fruitSearch = fruitSearch;
            _sqlDataContext = sqlDataContext;
        }

        public async Task<bool> add() 
        {
            bool status = false;


            return await Task.FromResult(status);
        }
    }
}