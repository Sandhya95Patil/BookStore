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
        public SqlConnection GetConnection(string connectionName)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:connectionDb"]);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Method for get command
        /// </summary>
        /// <param name="command">command parameter</param>
        /// <returns>return command</returns>
        public SqlCommand GetCommand(string command)
        {
            string connection = "";
            SqlConnection sqlConnection = GetConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        /// <summary>
        /// Stored Procedure Parameter Data class
        /// </summary>
        class StoredProcedureParameterData
        {
            public StoredProcedureParameterData(string name, dynamic value)
            {
                this.name = name;
                this.value = value;
            }

            public string name { get; set; }
            public dynamic value { get; set; }
        }

        /// <summary>
        /// Stored Procedure Execute Reader method
        /// </summary>
        /// <param name="spName">spName parameter</param>
        /// <param name="spParams">spParams parameter</param>
        /// <returns>return procedure name and parameters</returns>
        private async Task<DataTable> StoredProcedureExecuteReader(string spName, IList<StoredProcedureParameterData> spParams)
        {
            try
            {
                SqlCommand command = GetCommand(spName);
                for (int i = 0; i < spParams.Count; i++)
                {
                    command.Parameters.AddWithValue(spParams[i].name, spParams[i].value);
                }
                DataTable table = new DataTable();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
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
