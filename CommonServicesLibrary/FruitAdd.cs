using CommonInterfaceLibrary;
using CommonModelLibrary;
using CommonModelLibrary.Request;
using CommonModelLibrary.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesLibrary
{
    public class FruitAdd : IFruitAdd
    {
        private readonly ISqlDataContext _sqlDataContext;
        private SqlConnection _con;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private readonly IConfiguration _configuration;
        public FruitAdd(IConfiguration configuration, ISqlDataContext sqlDataContext)
        {
            _configuration = configuration;
            _sqlDataContext = sqlDataContext;
        }

        public async Task<bool> AddAsync(FruitRequest fruit, string Operation)
        {
            Fruit item = new Fruit();
            Nutritions n = new Nutritions();
            item.Genus = fruit.Genus;
            item.Name = fruit.Name;
            item.Family = fruit.Family;
            item.Order = fruit.Order;
            n.carbohydrates = fruit.Nutritions.carbohydrates;
            n.calories = fruit.Nutritions.calories;
            n.sugar = fruit.Nutritions.sugar;
            n.protein = fruit.Nutritions.protein;
            n.fat = fruit.Nutritions.fat;
            item.Nutritions = n;

            using (_con = await _sqlDataContext.createConnectionAsync())
            {
                _con.Open();
                _cmd = await _sqlDataContext.createSqlCommandAsync(_con);
                _cmd = await _sqlDataContext.addSqlCommandParametersAsync(_cmd, Operation, item, null);
                return await _sqlDataContext.runExecuteNonQueryAsync(_cmd);
            }
        }

        public async Task<bool> validateFruitAsync(FruitRequest fruit, string Operation)
        {
            bool status = false;
            Fruit item = new Fruit();
            Nutritions n = new Nutritions();
            item.Genus = fruit.Genus;
            item.Name = fruit.Name;
            item.Family = fruit.Family;
            item.Order = fruit.Order;
            n.carbohydrates = fruit.Nutritions.carbohydrates;
            n.calories = fruit.Nutritions.calories;
            n.sugar = fruit.Nutritions.sugar;
            n.protein = fruit.Nutritions.protein;
            n.fat = fruit.Nutritions.fat;
            item.Nutritions = n;

            List<FruitsResponse> list = new List<FruitsResponse>();
            using (_con = await _sqlDataContext.createConnectionAsync())
            {
                _con.Open();
                _cmd = await _sqlDataContext.createSqlCommandAsync(_con);
                _cmd = await _sqlDataContext.addSqlCommandParametersAsync(_cmd, Operation, item, null);
                list = await _sqlDataContext.runSqlDataReaderListAsync(_cmd);
                if (list.Count > 0 )
                {
                    status = true;
                }
            }
            return await Task.FromResult(status);
        }
    }
}
