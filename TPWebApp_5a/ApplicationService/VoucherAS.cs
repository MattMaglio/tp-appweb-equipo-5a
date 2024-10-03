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

                query.configSqlProcedure("SearchVoucher");
                query.configSqlConexion(conexion.obtenerConexion());
                query.configSqlParams("@cod_voucher", codFiltrado);

                conexion.abrirConexion();
                result = query.ejecutarConsulta();

                while (result.Read())
                {
                    

                    if (result["FechaCanje"] is DBNull)
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
    }
}
