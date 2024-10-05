using DataPersistence;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ApplicationService
{
    public class ClienteAS
    {
        public int agregarCliente(Cliente clienteNuevo)
        {
            // Validaciones de los datos que ingreso del cliente
            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteDNI.ToString()))
                throw new ArgumentException("El DNI del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteNombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteApellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteEmail))
                throw new ArgumentException("El email del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteDireccion))
                throw new ArgumentException("La dirección del clinete es obligatoria.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteCiudad))
                throw new ArgumentException("La ciudad del cliente es obligatoria.");

            if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteCP.ToString()))
                throw new ArgumentException("El código postal del cliente es obligatorio.");


            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            try
            {
                // Configuro query de inserción y recuperación del ID insertado
                query.configSqlQuery("INSERT INTO CLIENTES ( Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES( @DNICliente, @nombreCliente, @ApellidoCliente, @EmailCliente, @DireccionCliente, @CiudadCliente, @CPCliente); SELECT SCOPE_IDENTITY();");

                // Configuro conexión a DB
                query.configSqlConexion(conexion.obtenerConexion());

                // Abro la conexión
                conexion.abrirConexion();

                // Parámetros de la query
                query.configSqlParams("@DNICliente", clienteNuevo.ClienteDNI);
                query.configSqlParams("@nombreCliente", clienteNuevo.ClienteNombre);
                query.configSqlParams("@apellidoCliente", clienteNuevo.ClienteApellido);
                query.configSqlParams("@EmailCliente", clienteNuevo.ClienteEmail);
                query.configSqlParams("@DireccionCliente",clienteNuevo.ClienteDireccion);
                query.configSqlParams("@CiudadCliente", clienteNuevo.ClienteCiudad);
                query.configSqlParams("@CPCliente", clienteNuevo.ClienteCP);

                // Ejecutar la query y obtener el ID generado
               int idGenerado = Convert.ToInt32(query.ejecutarEscalar());

               return idGenerado;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el cliente en la base de datos", ex);
            }
            finally
            {
                // Cierro la conexión
                conexion.cerrarConexion();
            }
            return -1; // Valor indicando que no se insertó correctamente
        }


    }
}
