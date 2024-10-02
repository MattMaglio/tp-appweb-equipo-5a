using System;
using System.Data.SqlClient;

namespace DataPersistence
{
    public class DataManipulator
    {
        public SqlCommand sqlQuery { get; set; }

        public DataManipulator()
        {
            sqlQuery = new SqlCommand();
        }

        public void configSqlQuery(string query)
        {
            sqlQuery = new SqlCommand();
            sqlQuery.CommandType = System.Data.CommandType.Text;
            sqlQuery.CommandText = query;
        }

        public void configSqlConexion(SqlConnection conexion)
        {
            if (sqlQuery == null)
            {
                sqlQuery = new SqlCommand();
            }

            sqlQuery.Connection = conexion;
        }

        public SqlDataReader ejecutarConsulta()
        {
            if (sqlQuery.Connection == null)
            {
                throw new InvalidOperationException("La conexión no ha sido configurada.");
            }

            SqlDataReader result = sqlQuery.ExecuteReader();
            return result;
        }

        public void ejecutarAccion()
        {
            if (sqlQuery.Connection == null)
            {
                throw new InvalidOperationException("La conexión no ha sido configurada.");
            }

            sqlQuery.ExecuteNonQuery();
             
        }

        public void configSqlParams(string nombre, object valor)
        {
            if (sqlQuery == null)
            {
                throw new InvalidOperationException("sqlQuery no está inicializado.");
            }

         
            sqlQuery.Parameters.AddWithValue(nombre, valor);
        }
        //*********************************************************************************************
        //EJECUTAR ESCALAR (SE USA PARA QUERIES QUE DEVUELVEN UN VALOR UNICO)
        public object ejecutarEscalar()
        {
            if (sqlQuery.Connection == null)
            {
                throw new InvalidOperationException("La conexión no ha sido configurada.");
            }

            object result = sqlQuery.ExecuteScalar();
            return result;
        }



    }
}
