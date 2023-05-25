using CommonModelLibrary;
using CommonModelLibrary.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaceLibrary
{
    public interface ISqlDataContext
    {
        Task<SqlConnection> createConnectionAsync();
        Task<SqlCommand> createSqlCommandAsync(SqlConnection con);
        Task<SqlCommand> addSqlCommandParametersAsync(SqlCommand _cmd, string operation, Fruit item, SearchFilter sf);
        Task<List<FruitsResponse>> runSqlDataReaderListAsync(SqlCommand cmd);
        Task<bool> runExecuteNonQueryAsync(SqlCommand cmd);
    }
}
