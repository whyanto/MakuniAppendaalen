

using System.Configuration;
using System.Data.SqlClient;

namespace MakuniAppendaalen.Data
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;
        private readonly string _name;

        public ConnectionFactory(string connectionName)
        {
            var con = ConfigurationManager.ConnectionStrings[connectionName];
            if (con == null)
            {
                throw new ConfigurationErrorsException($"Failed to find connection named: {connectionName}");
            }
            _name = connectionName;
            _connectionString = con.ConnectionString;
        }

        public SqlConnection Create()
        {
            var connection = new SqlConnection(_connectionString);
            if (connection == null)
            {
                throw new ConfigurationErrorsException($"Failed to create connection named: {_name}");
            }
            connection.Open();
            return connection;
        }
    }
}
