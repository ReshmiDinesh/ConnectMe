using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace ConnectMe.UserMicroService.Data.DataAccess

{
    public class DataAccessBase 
    {

        private string connectionString;
        private SqlConnection connection;

        public DataAccessBase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<SqlConnection> OpenConnectionAsync()
        {
            connection =new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public async Task<SqlDataReader> ExecuteReaderAsync (SqlConnection conn, CommandType commandType, string queryProcedure)
        {
            SqlDataReader reader = null;

            SqlCommand cmd = new SqlCommand(queryProcedure, conn);

            reader = await cmd.ExecuteReaderAsync();

            return reader;
         
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(SqlConnection conn, CommandType commandType, string queryProcedure, SqlParameter[] sqlParameter)
        {
            SqlDataReader reader = null;

            SqlCommand cmd = new SqlCommand(queryProcedure, conn);
            cmd.Parameters.Add(sqlParameter);
            reader = await cmd.ExecuteReaderAsync();

            return reader;

        }

        public async Task<bool> ExecuteNonQueryAsync(SqlConnection conn, CommandType commandType, string queryProcedure)
        {
            SqlCommand cmd = new SqlCommand(queryProcedure, conn);
             await cmd.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<bool> ExecuteNonQueryAsync(SqlConnection conn, CommandType commandType, string queryProcedure, SqlParameter[] sqlParameter)
        {
            SqlCommand cmd = new SqlCommand(queryProcedure, conn);
            cmd.Parameters.Add(sqlParameter);
            await cmd.ExecuteReaderAsync();
            return true;
        }

        public async Task<string> ExecuteNonQueryAsync(SqlConnection conn, CommandType commandType, string queryProcedure, SqlParameter[] sqlParameter, SqlParameter sqlParameterOutPut)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand(queryProcedure, conn);
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameter);
                cmd.Parameters.Add(sqlParameterOutPut);
              
                await cmd.ExecuteNonQueryAsync();


                string retunvalue =  (string)cmd.Parameters[sqlParameterOutPut.ParameterName].Value;

                return retunvalue;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Object> ExecuteScalarAsync(SqlConnection conn, CommandType commandType, string queryProcedure)
        {
            SqlCommand cmd = new SqlCommand(queryProcedure, conn);

            var Obj = await cmd.ExecuteScalarAsync();

            return Obj;
        }
    }
}
