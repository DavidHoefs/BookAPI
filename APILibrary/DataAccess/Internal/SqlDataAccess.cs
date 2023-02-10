using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace APILibrary.DataAccess.Internal
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SqlDataAccess" /> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        ///     Loads data from stored procedure
        /// </summary>
        /// <typeparam name="T">The return type</typeparam>
        /// <typeparam name="U">The parameter type (usually dynamic)</typeparam>
        /// <param name="storedProcedure">The stored procedure name to call</param>
        /// <param name="parameters">The parameters for the stored procedure</param>
        /// <param name="connectionStringName">The connection string name</param>
        /// <returns>List<typeparamref name="T"></typeparamref>containing the return records from stored procedure</returns>
        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            return rows;
        }

        /// <summary>
        ///     Save data to the database
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="storedProcedure">The stored procedure to call</param>
        /// <param name="parameters">Parameters for stored procedure</param>
        /// <param name="connectionStringName">The connection string name</param>
        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        ///     Loads data from stored procedure async
        /// </summary>
        /// <typeparam name="T">The return type</typeparam>
        /// <typeparam name="U">The parameter type (usually dynamic)</typeparam>
        /// <param name="storedProcedure">The stored procedure name to call</param>
        /// <param name="parameters">The parameters for the stored procedure</param>
        /// <param name="connectionStringName">The connection string name</param>
        /// <returns>List<typeparamref name="T" />containing the return records from stored procedure</returns>
        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return rows.ToList();
        }

        /// <summary>
        ///     Save data to the database async
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="storedProcedure">The stored procedure to call</param>
        /// <param name="parameters">Parameters for stored procedure</param>
        /// <param name="connectionStringName">The connection string name</param>
        public async void SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);

            var retVal =
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        ///     Inserts a Set of data in one transaction
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        public void InsertDataSet(string storedProcedure, DataTable parameters, string connectionStringName, string udtName)
        {
            var connectionString = GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            var p = new
            {
                data = parameters.AsTableValuedParameter(udtName)
            };
            var recordsAffected = connection.Execute(storedProcedure, p, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"Records Affected: {recordsAffected}");
        }

        private string GetConnectionString(string connectionStringName)
        {
            return _config.GetConnectionString(connectionStringName) ?? string.Empty;
        }
    }
}
