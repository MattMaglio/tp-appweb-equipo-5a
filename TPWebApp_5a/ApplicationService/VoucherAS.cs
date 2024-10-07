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
    public class VoucherAS
    {
        public Voucher buscarVoucher(string codFiltrado)
        {

            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            List<Voucher> lista = new List<Voucher>();
            Voucher vchFiltrado = new Voucher();
            SqlDataReader result;

            try
            {

                query.configSqlQuery("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @cod_voucher");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@cod_voucher", codFiltrado);

                conexion.abrirConexion();
                result = query.ejecutarConsulta();

                while (result.Read())
                {
                    

                    if (result["FechaCanje"] is DBNull && !(result["CodigoVoucher"] is DBNull))
                    {
                        vchFiltrado.FechCanje = null;
                        vchFiltrado.IdArt = null;
                        vchFiltrado.IdCli = null;
                        vchFiltrado.CodVoucher = (string)result["CodigoVoucher"];
                    }
                    else 
                    { 
                        vchFiltrado.FechCanje = (DateTime)result["FechaCanje"];
                        vchFiltrado.IdArt = (int)result["IdArticulo"];
                        vchFiltrado.IdCli = (int)result["IdCliente"];
                        vchFiltrado.CodVoucher = (string)result["CodigoVoucher"];
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

            return vchFiltrado;
        }
        public void updateVoucher(Voucher vch)
        {
            DataAccess conexion = new DataAccess();
            DataManipulator query = new DataManipulator();

            List<Voucher> lista = new List<Voucher>();
            Voucher vchFiltrado = new Voucher();

            try
            {

                query.configSqlQuery("UPDATE Vouchers SET IdCliente = @id_cli, FechaCanje = @date, IdArticulo = @id_art WHERE CodigoVoucher = @cod_vch;");
                
                query.configSqlConexion(conexion.obtenerConexion());

                query.configSqlParams("@id_cli", vch.IdCli);
                query.configSqlParams("@date", vch.FechCanje);
                query.configSqlParams("@id_art", vch.IdArt);
                query.configSqlParams("@cod_vch", vch.CodVoucher);

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
    }
}
