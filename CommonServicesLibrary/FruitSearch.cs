using Azure;
using CommonInterfaceLibrary;
using CommonModelLibrary;
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
    public class FruitSearch : IFruitSearch
    {
        private readonly ISqlDataContext _sqlDataContext;
        private SqlConnection? _con;
        private SqlCommand? _cmd;
        private SqlDataReader? _dr;
        private readonly IConfiguration _configuration;
        public FruitSearch(IConfiguration configuration, ISqlDataContext sqlDataContext)
        {
            _configuration = configuration;
            _sqlDataContext = sqlDataContext;
        }


        public async Task<List<FruitsResponse>> allAsync()
        {
            List<FruitsResponse> list = new List<FruitsResponse>();
            try
            {
                using (_con = await _sqlDataContext.createConnectionAsync())
                {
                    _con.Open();
                    _cmd = await _sqlDataContext.createSqlCommandAsync(_con);
                    _cmd = await _sqlDataContext.addSqlCommandParametersAsync(_cmd, "getall", null,null);
                     list= await _sqlDataContext.runSqlDataReaderListAsync(_cmd);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(list.ToList());
        }

        public async Task<List<FruitsResponse>> getAsync(SearchFilter sf,string Operation)
        {
            List<FruitsResponse> list = new List<FruitsResponse>();
            try
            {
                using (_con = await _sqlDataContext.createConnectionAsync())
                {
                    _con.Open();
                    _cmd = await _sqlDataContext.createSqlCommandAsync(_con);
                    _cmd = await _sqlDataContext.addSqlCommandParametersAsync(_cmd, Operation, null,sf);
                    list = await _sqlDataContext.runSqlDataReaderListAsync(_cmd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(list.ToList());
        }
    }
}
