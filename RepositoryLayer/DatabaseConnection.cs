using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class DatabaseConnection
    {
        IConfiguration configuration;
        public DatabaseConnection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method is for connection with database using connection string
        /// </summary>
        /// <param name="connectionName">connectionName parameter</param>
        /// <returns>return the connection</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(configuration["ConnectionStrings:connectionDb"]);

        }

        /// <summary>
        /// Method for get command
        /// </summary>
        /// <param name="command">command parameter</param>
        /// <returns>return command</returns>
        public SqlCommand GetCommand(string commandName, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(commandName, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        /// <summary>
        /// Stored Procedure Execute Reader method
        /// </summary>
        /// <param name="spName">spName parameter</param>
        /// <param name="spParams">spParams parameter</param>
        /// <returns>return procedure name and parameters</returns>
        public async Task<DataTable> StoredProcedureExecuteReader(string spName, IList<StoredProcedureParameterData> spParams)
        {
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand sqlCommand = GetCommand(spName, connection);
                for (int i = 0; i < spParams.Count; i++)
                {
                    sqlCommand.Parameters.AddWithValue(spParams[i].name, spParams[i].value);
                }
                DataTable table = new DataTable();
                SqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync();
                table.Load(dataReader);
                return table;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
