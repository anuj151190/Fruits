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
    public  class SqlDataContext : ISqlDataContext
    {
        private string _connectionString = string.Empty;
        private SqlConnection _con;
        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private readonly IConfiguration _configuration;
        public SqlDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        async Task<SqlConnection> ISqlDataContext.createConnectionAsync()
        {
            try
            {
                _connectionString = _configuration["DefaultConnection"].ToString();
                _con = new SqlConnection(_connectionString);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(_con); 
        }

        public async Task<SqlCommand> createSqlCommandAsync(SqlConnection con)
        {
            try
            {
                _cmd = new SqlCommand();
                _cmd.CommandText = "sp_fruitprocedure";
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.Connection = con;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(_cmd);
        }

        public async Task<List<FruitsResponse>> runSqlDataReaderListAsync(SqlCommand cmd)
        {
            List<FruitsResponse> list = new List<FruitsResponse>();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        FruitsResponse item = new FruitsResponse();
                        NutritionsResponse n = new NutritionsResponse();
                        item.Id = Convert.ToInt32(dr["fruitId"]);
                        item.Genus = Convert.ToString(dr["genus"]);
                        item.Name = Convert.ToString(dr["name"]);
                        item.Family = Convert.ToString(dr["family"]);
                        item.Order = Convert.ToString(dr["order"]);
                        n.carbohydrates = Convert.ToInt32(dr["carbohydrates"]);
                        n.calories = Convert.ToInt32(dr["calories"]);
                        n.sugar = Convert.ToInt32(dr["sugar"]);
                        n.protein = Convert.ToInt32(dr["protein"]);
                        n.fat = Convert.ToInt32(dr["fat"]);
                        item.Nutritions = n;
                        list.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.Run(list.ToList);
        }

        public async Task<bool> runExecuteNonQueryAsync(SqlCommand Cmd)
        {
            bool status = false;
            int i = await _cmd.ExecuteNonQueryAsync();
            if(i >= -1)
            {
                status = true;
            }
            return await Task.FromResult(status);
        }

        public async Task<SqlCommand> addSqlCommandParametersAsync(SqlCommand _cmd,string operation, Fruit item, SearchFilter sf)
        {
            switch(operation)
            {
                case "validatefruit":
                    _cmd.Parameters.AddWithValue("@choice", "validatefruit");
                    _cmd.Parameters.AddWithValue("@sugar", item.Nutritions.sugar);
                    _cmd.Parameters.AddWithValue("@calories", item.Nutritions.calories);
                    _cmd.Parameters.AddWithValue("@protein", item.Nutritions.protein);
                    _cmd.Parameters.AddWithValue("@carbohydrates", item.Nutritions.carbohydrates);
                    _cmd.Parameters.AddWithValue("@fat", item.Nutritions.fat);
                    _cmd.Parameters.AddWithValue("@name", item.Name);
                    _cmd.Parameters.AddWithValue("@genus", item.Genus);
                    _cmd.Parameters.AddWithValue("@family", item.Family);
                    _cmd.Parameters.AddWithValue("@order", item.Order);
                    break;

                case "insert":
                    _cmd.Parameters.AddWithValue("@choice", "insert");
                    _cmd.Parameters.AddWithValue("@sugar", item.Nutritions.sugar);
                    _cmd.Parameters.AddWithValue("@calories", item.Nutritions.calories);
                    _cmd.Parameters.AddWithValue("@protein", item.Nutritions.protein);
                    _cmd.Parameters.AddWithValue("@carbohydrates", item.Nutritions.carbohydrates);
                    _cmd.Parameters.AddWithValue("@fat", item.Nutritions.fat);
                    _cmd.Parameters.AddWithValue("@name", item.Name);
                    _cmd.Parameters.AddWithValue("@genus", item.Genus);
                    _cmd.Parameters.AddWithValue("@family", item.Family);
                    _cmd.Parameters.AddWithValue("@order", item.Order);
                    break;

                case "getall":
                    _cmd.Parameters.AddWithValue("@choice", "getall");
                    break;
                case "getnutritions":
                    _cmd.Parameters.AddWithValue("@choice", "getnutritions");
                    _cmd.Parameters.AddWithValue("@Min", sf.Min);
                    _cmd.Parameters.AddWithValue("@Max", sf.Max);
                    break;
                case "getfamily":
                    _cmd.Parameters.AddWithValue("@choice", "getfamily");
                    _cmd.Parameters.AddWithValue("@family", sf.NutritionFilter);
                    break;
                case "getgenus":
                    _cmd.Parameters.AddWithValue("@choice", "getgenus");
                    _cmd.Parameters.AddWithValue("@genus", sf.NutritionFilter);
                    break;
                case "getorder":
                    _cmd.Parameters.AddWithValue("@choice", "getorder");
                    _cmd.Parameters.AddWithValue("@order", sf.NutritionFilter);
                    break;
            }
            return await Task.FromResult(_cmd);
        }
    }
}
