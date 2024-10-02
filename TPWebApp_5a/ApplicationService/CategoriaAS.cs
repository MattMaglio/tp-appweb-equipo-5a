using DataPersistence;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public  class CategoriaAS
    {
        public List<Categoria> listar()
        {
            SqlDataReader result;
            List<Categoria> lista = new List<Categoria>();
            DataAccess data = new DataAccess();
            DataManipulator query = new DataManipulator();
            try
            {
                query.configSqlQuery("Select id, descripcion from Categorias");
                query.configSqlConexion(data.obtenerConexion());
                data.abrirConexion();
                result = query.ejecutarConsulta();
                while (result.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)result["Id"];
                    aux.Descripcion = (string)result["Descripcion"];
                    lista.Add(aux);
                }

             return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }
    }
}
