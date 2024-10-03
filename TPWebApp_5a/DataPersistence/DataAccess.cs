using System.Data.SqlClient;

namespace DataPersistence
{
    public class DataAccess
    {
        private SqlConnection conexionDB;

        public DataAccess()
        {
            string connectionString = "Server=.\\PROGRAMACION_III;Database=PROMOS_DB;Trusted_Connection=True;";
            conexionDB = new SqlConnection(connectionString);
        }

        public SqlConnection obtenerConexion()
        {
            return conexionDB;
        }

        public void abrirConexion()
        {
            if (conexionDB.State == System.Data.ConnectionState.Closed)
            {
                conexionDB.Open();
            }
        }

        public void cerrarConexion()
        {
            if (conexionDB.State == System.Data.ConnectionState.Open)
            {
                conexionDB.Close();
            }
        }
    }
}
