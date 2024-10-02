using DataPersistence;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class MarcaAS
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;

            try
            {

                query.configSqlQuery("SELECT Id, Descripcion FROM MARCAS");
                query.configSqlConexion(conexion.obtenerConexion());

                conexion.abrirConexion();
                result = query.ejecutarConsulta();

                while (result.Read())
                {
                    Marca auxMarca = new Marca();
                    auxMarca.Id = (int)result["Id"];
                    auxMarca.Descripcion = (string)result["Descripcion"];

                    lista.Add(auxMarca);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }
    }


 }
