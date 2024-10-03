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
    public class ImagenAS
    {
        public void eliminarImagen(Imagen img)
        {
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {

                query.configSqlQuery("DELETE FROM IMAGENES WHERE Id = @Id");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@Id", img.Id);

                conexion.abrirConexion();
                query.ejecutarAccion();
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
        public void agegarImagenesArtNuevo(List<Imagen> listImg, Articulo art)
        {
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {
                query.configSqlQuery("SELECT Id FROM ARTICULOS where Codigo = @art");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@art", art.Codigo);

                conexion.abrirConexion();
                int idGenerado = Convert.ToInt32(query.ejecutarEscalar());

                foreach (var img in listImg)
                {
                    try
                    {
                        query.configSqlQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArt, @UrlImg)");
                        query.configSqlConexion(conexion.obtenerConexion());
                        query.configSqlParams("@IdArt", idGenerado);
                        query.configSqlParams("@UrlImg", img.ImagenUrl);

                        conexion.abrirConexion();
                        query.ejecutarAccion();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
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
        public void agregarImagen(Imagen img)
        {
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {

                query.configSqlQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES(@IdArt, @UrlImg)");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@IdArt", img.IdArticulo);
                query.configSqlParams("@UrlImg", img.ImagenUrl);
                
                conexion.abrirConexion();
                query.ejecutarAccion();
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
        public List<Imagen> listarFiltrado(string codFiltrado)
        {
            List<Imagen> lista = new List<Imagen>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;

            try
            {

                query.configSqlQuery("SELECT i.Id, a.Id AS IdArticulo, i.ImagenUrl FROM ARTICULOS a LEFT JOIN IMAGENES i ON a.Id = i.IdArticulo WHERE Codigo = @codArt AND i.Id IS NOT NULL");
                query.configSqlParams("@codArt", codFiltrado);
                query.configSqlConexion(conexion.obtenerConexion());

                conexion.abrirConexion();
                result = query.ejecutarConsulta();

                while (result.Read())
                {
                    Imagen auxImg = new Imagen();

                    
                    auxImg.IdArticulo = (int)result["IdArticulo"];
                    auxImg.Id = (int)result["Id"];
                    auxImg.ImagenUrl = (string)result["ImagenUrl"];

                        
                    lista.Add(auxImg);
                    

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
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;

            try
            {

                query.configSqlQuery("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                query.configSqlConexion(conexion.obtenerConexion());

                conexion.abrirConexion();
                result = query.ejecutarConsulta();

                while (result.Read())
                {
                    Imagen auxImg = new Imagen();
                    auxImg.Id = (int)result["Id"];
                    auxImg.IdArticulo = (int)result["IdArticulo"];
                    auxImg.ImagenUrl = (string)result["ImagenUrl"];


                    lista.Add(auxImg);
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
