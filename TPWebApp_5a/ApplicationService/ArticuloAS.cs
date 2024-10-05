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
        public Articulo buscarArt(string codFiltrado)
        {

            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            List<Articulo> lista = new List<Articulo>();
            Articulo auxArt = new Articulo();
            SqlDataReader result;


            try
            {

                query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,m.Id AS 'Id Marca', m.Descripcion AS 'Marca',c.Id AS 'Id Categoria', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria WHERE Codigo = @codArt");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@codArt", codFiltrado);

                conexion.abrirConexion();
                result = query.ejecutarConsulta();



                while (result.Read())
                {
                    auxArt.Id = (int)result["Id"];
                    auxArt.Codigo = (string)result["Codigo"];
                    auxArt.Nombre = (string)result["Nombre"];
                    auxArt.Descripcion = (string)result["Descripcion"];
                    auxArt.Marca = new Marca();
                    if (!(result["Id Marca"] is DBNull))
                    {
                        auxArt.Marca.Id = (int)result["Id Marca"];
                        auxArt.Marca.Descripcion = (string)result["Marca"];
                    }
                    else
                    {
                        auxArt.Marca.Descripcion = "Sin marca";
                    }
                    auxArt.Categoria = new Categoria();
                    if (!(result["Id Categoria"] is DBNull))
                    {
                        auxArt.Categoria.Id = (int)result["Id Categoria"];
                        auxArt.Categoria.Descripcion = (string)result["Categoria"];
                    }
                    else
                    {
                        auxArt.Categoria.Descripcion = "Sin categoria";
                    }

                    auxArt.Precio = (decimal)result["Precio"];


                    lista.Add(auxArt);
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

            return auxArt;
        }
        public List<Articulo> listar()
        {
            List <Articulo> lista = new List<Articulo>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;
            
            try
            {

                query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion AS 'Marca', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria");
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
                    auxArt.Marca = new Marca();
                    if (!(result.IsDBNull(result.GetOrdinal("Marca"))))
                    {
                        auxArt.Marca.Descripcion = (string)result["Marca"];
                    }
                    else 
                    {
                        auxArt.Marca.Descripcion = "Sin marca";
                    }
                    auxArt.Categoria = new Categoria();
                    if (!(result["Categoria"] is DBNull))
                    {
                        auxArt.Categoria.Descripcion = (string)result["Categoria"];
                    }
                    else
                    {
                        auxArt.Categoria.Descripcion = "Sin categoria";
                    }
                    auxArt.Precio = (decimal)result["Precio"];


                    lista.Add(auxArt);
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
         public void actualizarArticulo(Articulo art)
         {
             DataAccess conexion = new DataAccess();
             DataManipulator query = new DataManipulator();

             List<Articulo> lista = new List<Articulo>();
             Articulo auxArt = new Articulo();

             try
             {

                 query.configSqlQuery("UPDATE ARTICULOS SET Nombre = @nombre, Descripcion = @desc, IdCategoria = @idCat, IdMarca = @idMarca, Precio = @precio WHERE Codigo = @codArt");
                 query.configSqlConexion(conexion.obtenerConexion());
                 query.configSqlParams("@codArt", art.Codigo);
                 query.configSqlParams("@nombre", art.Nombre);
                 query.configSqlParams("@desc", art.Descripcion);
                 query.configSqlParams("@idCat", art.Categoria.Id);
                 query.configSqlParams("@idMarca", art.Marca.Id);
                 query.configSqlParams("@precio", Convert.ToDecimal(art.Precio));

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
        //***************************************************************************************************************
        public void borrarArticulo(Articulo art){

            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {

                query.configSqlQuery("DELETE FROM ARTICULOS WHERE Codigo = @codArt");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@codArt", art.Codigo);

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
        public List<Articulo> listarVersatil(int marca, int cate)
        {
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            List<Articulo> lista = new List<Articulo>();
            SqlDataReader result;

            try
            {
                if (marca <= 0 && cate <= 0)
                {
                    query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS 'Id Marca', m.Descripcion AS 'Marca', c.Id AS 'Id Categoria', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria");
                    query.configSqlConexion(conexion.obtenerConexion());
                    //query.configSqlParams("@codArt", codFiltrado);

                    conexion.abrirConexion();
                    result = query.ejecutarConsulta();
                }
                else if (marca > 0)
                {
                    query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS 'Id Marca', m.Descripcion AS 'Marca', c.Id AS 'Id Categoria', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria WHERE a.IdMarca = @Marca");
                    query.configSqlConexion(conexion.obtenerConexion());
                    query.configSqlParams("@Marca", marca);

                    conexion.abrirConexion();
                    result = query.ejecutarConsulta();
                }
                else if (cate > 0)
                {
                    query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS 'Id Marca', m.Descripcion AS 'Marca', c.Id AS 'Id Categoria', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria WHERE a.IdCategoria = @Categoria");
                    query.configSqlConexion(conexion.obtenerConexion());
                    query.configSqlParams("@Categoria", cate);

                    conexion.abrirConexion();
                    result = query.ejecutarConsulta();
                }
                else
                {
                    query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS 'Id Marca', m.Descripcion AS 'Marca', c.Id AS 'Id Categoria', c.Descripcion AS 'Categoria', a.Precio FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria WHERE a.IdMarca = @Marca AND a.IdCategoria = @Categoria");
                    query.configSqlConexion(conexion.obtenerConexion());
                    query.configSqlParams("@Categoria", cate);
                    query.configSqlParams("@Marca", marca);


                    conexion.abrirConexion();
                    result = query.ejecutarConsulta();
                }

                while (result.Read())
                {
                    Articulo auxArt = new Articulo();

                    auxArt.Id = (int)result["Id"];
                    auxArt.Codigo = (string)result["Codigo"];
                    auxArt.Nombre = (string)result["Nombre"];
                    auxArt.Descripcion = (string)result["Descripcion"];
                    auxArt.Marca = new Marca();
                    if (!(result["Id Marca"] is DBNull))
                    {
                        auxArt.Marca.Id = (int)result["Id Marca"];
                        auxArt.Marca.Descripcion = (string)result["Marca"];
                    }
                    else
                    {
                        auxArt.Marca.Descripcion = "Sin marca";
                    }
                    auxArt.Categoria = new Categoria();
                    if (!(result["Id Categoria"] is DBNull))
                    {
                        auxArt.Categoria.Id = (int)result["Id Categoria"];
                        auxArt.Categoria.Descripcion = (string)result["Categoria"];
                    }
                    else
                    {
                        auxArt.Categoria.Descripcion = "Sin categoria";
                    }
                    auxArt.Precio = (decimal)result["Precio"];


                    lista.Add(auxArt);
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

        //****************************************************************************************************************************
        public List<Articulo> listarFrmListado()
        {
            List<Articulo> lista = new List<Articulo>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;

            try
            {

                query.configSqlQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, a.IdCategoria, " +
                    "a.Precio, i.IdArticulo, i.ImagenUrl FROM ARTICULOS a JOIN IMAGENES i ON a.Id = i.IdArticulo");
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
                    auxArt.Precio = (decimal)result["Precio"];

                    auxArt.Marca = new Marca();
                    auxArt.Marca.Id = (int)result["IdMarca"];
                    auxArt.Marca.Descripcion = (string)result["Descripcion"];

                    auxArt.Categoria = new Categoria();
                    auxArt.Categoria.Id = (int)result["IdCategoria"];
                    auxArt.Categoria.Descripcion = (string)result["Descripcion"];

                    // traigo datos de la tabla imagenes
                    auxArt.Imagen = new Imagen();
                    if (!(result["IdArticulo"] is DBNull))
                    {
                        auxArt.Imagen.IdArticulo = (int)result["IdArticulo"];
                    }
                    if (!(result["ImagenUrl"] is DBNull))
                    {
                        auxArt.Imagen.ImagenUrl = (string)result["ImagenUrl"];
                    }



                    lista.Add(auxArt);
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
        public void eliminar(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                // Configura el comando para eliminar
                using (SqlCommand comando = new SqlCommand("DELETE FROM ARTICULOS WHERE Id = @id", datos.obtenerConexion()))
                {
                    // Agrega el parámetro al comando
                    comando.Parameters.AddWithValue("@id", id);

                    // Abre la conexión
                    datos.abrirConexion();

                    // Ejecuta el comando
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //*********************************************************************

        public int agregarArt(Articulo art)
        {
            // Validaciones de los datos que ingreso del artículo
            if (string.IsNullOrWhiteSpace(art.Codigo))
                throw new ArgumentException("El código del artículo es obligatorio.");

            if (string.IsNullOrWhiteSpace(art.Nombre))
                throw new ArgumentException("El nombre del artículo es obligatorio.");

            if (string.IsNullOrWhiteSpace(art.Descripcion))
                throw new ArgumentException("La descripción del artículo es obligatoria.");

            if (art.Marca == null || art.Marca.Id <= 0)
                throw new ArgumentException("La marca del artículo es inválida.");

            if (art.Categoria == null || art.Categoria.Id <= 0)
                throw new ArgumentException("La categoría del artículo es inválida.");

            if (art.Precio <= 0 || art.Precio == null)
                throw new ArgumentException("El precio del artículo debe ser mayor que cero.");

            // Validar la URL de la imagen si existe
            if (art.Imagen != null && !string.IsNullOrWhiteSpace(art.Imagen.ImagenUrl))
            {
                string urlPattern = @"^((https?|ftp):\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(:\d{1,5})?(\/\S*)?$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(art.Imagen.ImagenUrl, urlPattern))
                {
                    throw new ArgumentException("La URL de la imagen no es válida. Ingrese una URL en formato correcto.");
                }
            }

            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {
                // Configuro query de inserción y recuperación del ID insertado
                query.configSqlQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES(@codArt, @nombreArt, @descArt, @idMarca, @idCategoria, @precioArt); SELECT SCOPE_IDENTITY();");

                // Configuro conexión a DB
                query.configSqlConexion(conexion.obtenerConexion());

                // Abro la conexión
                conexion.abrirConexion();

                // Parámetros de la query
                query.configSqlParams("@codArt", art.Codigo);
                query.configSqlParams("@nombreArt", art.Nombre);
                query.configSqlParams("@descArt", art.Descripcion);
                query.configSqlParams("@idMarca", art.Marca.Id);
                query.configSqlParams("@idCategoria", art.Categoria.Id);
                query.configSqlParams("@precioArt", art.Precio);

                // Ejecutar la query y obtener el ID generado
                int idGenerado = Convert.ToInt32(query.ejecutarEscalar());

                return idGenerado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el artículo en la base de datos", ex);
            }
            finally
            {
                // Cierro la conexión
                conexion.cerrarConexion();
            }
        }

        public int modificarArt(Articulo art)
        {
            // Validaciones de los datos que ingreso del artículo
            if (string.IsNullOrWhiteSpace(art.Nombre))
                throw new ArgumentException("El nombre del artículo es obligatorio.");

            if (string.IsNullOrWhiteSpace(art.Descripcion))
                throw new ArgumentException("La descripción del artículo es obligatoria.");

            if (art.Marca == null || art.Marca.Id <= 0)
                throw new ArgumentException("La marca del artículo es inválida.");

            if (art.Categoria == null || art.Categoria.Id <= 0)
                throw new ArgumentException("La categoría del artículo es inválida.");

            if (art.Precio <= 0 || art.Precio == null)
                throw new ArgumentException("El precio del artículo debe ser mayor que cero.");

            // Validar la URL de la imagen si existe
            if (art.Imagen != null && !string.IsNullOrWhiteSpace(art.Imagen.ImagenUrl))
            {
                string urlPattern = @"^((https?|ftp):\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(:\d{1,5})?(\/\S*)?$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(art.Imagen.ImagenUrl, urlPattern))
                {
                    throw new ArgumentException("La URL de la imagen no es válida. Ingrese una URL en formato correcto.");
                }
            }

            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {
                query.configSqlQuery("UPDATE ARTICULOS SET Nombre = @nombre, Descripcion = @desc, IdCategoria = @idCat, IdMarca = @idMarca, Precio = @precio WHERE Codigo = @codArt");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@codArt", art.Codigo);
                query.configSqlParams("@nombre", art.Nombre);
                query.configSqlParams("@desc", art.Descripcion);
                query.configSqlParams("@idCat", art.Categoria.Id);
                query.configSqlParams("@idMarca", art.Marca.Id);
                query.configSqlParams("@precio", Convert.ToDecimal(art.Precio));

                conexion.abrirConexion();
                query.ejecutarAccion();

                // Ejecutar la query y obtener el ID generado
                int idGenerado = Convert.ToInt32(query.ejecutarEscalar());

                return idGenerado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el artículo en la base de datos", ex);
            }
            finally
            {
                // Cierro la conexión
                conexion.cerrarConexion();
            }
        }

        public List<Articulo> listarPremiosSp()
        {
           List<Articulo> lista = new List<Articulo>();
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();
            SqlDataReader result;
            try {     
                query.configSqlProcedure("ListarPremio");
                query.configSqlConexion(conexion.obtenerConexion());

                conexion.abrirConexion();
                result = query.ejecutarConsulta();
                while (result.Read())
                {
                    Articulo auxArt = new Articulo();

                    auxArt.Codigo = (string)result["Codigo"];
                    auxArt.Nombre = (string)result["Nombre"];
                    auxArt.Descripcion = (string)result["Descripcion"];



                    // traigo datos de la tabla imagenes
                    auxArt.Imagen = new Imagen();
                    if (!(result["IdArticulo"] is DBNull))
                    {
                        auxArt.Imagen.IdArticulo = (int)result["IdArticulo"];
                    }
                    if (!(result["ImagenUrl"] is DBNull))
                    {
                        auxArt.Imagen.ImagenUrl = (string)result["ImagenUrl"];
                    }
                    lista.Add(auxArt);
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