using System.Data;
using System.Data.SqlClient;

namespace Common.Interfaces
{
    public interface IContext
    {
        void CloseConnection(SqlConnection connection);

        SqlParameter CreateParameter(string name, object value, DbType dbType);

        SqlParameter CreateParameter(string name, int size, object value, DbType dbType);

        SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction);

        DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        DataSet GetDataSet(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        void Delete(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        void Insert(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        void Update(string commandText, CommandType commandType, SqlParameter[] parameters);
    }
}
