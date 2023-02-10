using System.Data;

namespace APILibrary.DataAccess.Internal;

public interface ISqlDataAccess
{
    /// <summary>
    ///     Loads data from stored procedure
    /// </summary>
    /// <typeparam name="T">The return type</typeparam>
    /// <typeparam name="U">The parameter type (usually dynamic)</typeparam>
    /// <param name="storedProcedure">The stored procedure name to call</param>
    /// <param name="parameters">The parameters for the stored procedure</param>
    /// <param name="connectionStringName">The connection string name</param>
    /// <returns>List<typeparamref name="T"></typeparamref>containing the return records from stored procedure</returns>
    List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);

    /// <summary>
    ///     Save data to the database
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="storedProcedure">The stored procedure to call</param>
    /// <param name="parameters">Parameters for stored procedure</param>
    /// <param name="connectionStringName">The connection string name</param>
    void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);

    /// <summary>
    ///     Loads data from stored procedure async
    /// </summary>
    /// <typeparam name="T">The return type</typeparam>
    /// <typeparam name="U">The parameter type (usually dynamic)</typeparam>
    /// <param name="storedProcedure">The stored procedure name to call</param>
    /// <param name="parameters">The parameters for the stored procedure</param>
    /// <param name="connectionStringName">The connection string name</param>
    /// <returns>List<typeparamref name="T" />containing the return records from stored procedure</returns>
    Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);

    /// <summary>
    ///     Save data to the database async
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="storedProcedure">The stored procedure to call</param>
    /// <param name="parameters">Parameters for stored procedure</param>
    /// <param name="connectionStringName">The connection string name</param>
    void SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);

    /// <summary>
    ///     Inserts a Set of data in one transaction
    /// </summary>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionStringName"></param>
    void InsertDataSet(string storedProcedure, DataTable parameters, string connectionStringName, string udtName);
}