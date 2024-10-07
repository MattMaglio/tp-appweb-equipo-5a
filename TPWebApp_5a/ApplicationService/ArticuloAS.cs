using System;
using System.Collections.Generic;
using Model;
using DataPersistence;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections;


namespace ApplicationService
{
    public class ArticuloAS
    {
        public List<Articulo> listarPremios()
        {
            List<Articulo> lista = new List<Articulo>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;
            try
            {
                query.configSqlQuery("SELECT a.id, a.Codigo, a.Nombre, a.Descripcion FROM ARTICULOS a;");
                query.configSqlConexion(conexion.obtenerConexion());

                conexion.abrirConexion();
                result = query.ejecutarConsulta();
                while (result.Read())
                {
                    Articulo auxArt = new Articulo();

                    auxArt.Id = (int)result["Id"];
                    auxArt.Codigo = (string)result["Codigo"];
                    auxArt.Nombre = (string)result["Nombre"];
                    auxArt.Descripcion = (string)result["Descripcion"];
                    
                    lista.Add(auxArt);
                }

                conexion.cerrarConexion();

                foreach(Articulo art in lista)
                {
                    query.configSqlQuery("SELECT i.ImagenUrl, i.IdArticulo FROM IMAGENES i INNER JOIN ARTICULOS a ON a.Id = i.IdArticulo WHERE a.Id = @id_art;");
                    query.configSqlParams("@id_art", art.Id);
                    query.configSqlConexion(conexion.obtenerConexion());

                    conexion.abrirConexion();
                    result = query.ejecutarConsulta();

                    List<Imagen> listImg = new List<Imagen>();

                    while (result.Read())
                    { 
                    
                        Imagen img = new Imagen();

                        if (!(result["IdArticulo"] is DBNull))
                        {
                            img.IdArticulo = (int)result["IdArticulo"];
                        }
                        if (!(result["ImagenUrl"] is DBNull))
                        {
                            img.ImagenUrl = (string)result["ImagenUrl"];
                        }

                        listImg.Add(img);
                    }

                    conexion.cerrarConexion();

                    art.Imagen = listImg;
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar premios: " + ex.Message, ex);
            }
            finally
            {
                conexion.cerrarConexion();
            }


        }
       
    }
}