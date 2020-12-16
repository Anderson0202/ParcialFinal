using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class Repository
    {

        private ConnectionManager connectionManager { get; }

        private SqlConnection connection;

        public Repository(ConnectionManager _connectionManager)
        {
            connectionManager = _connectionManager;
            connection = connectionManager._conexion;
        }

        

}
}
