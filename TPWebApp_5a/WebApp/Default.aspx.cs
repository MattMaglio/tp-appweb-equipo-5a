using ApplicationService;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // txtVoucher.Text = "Codigo del voucher...";
            }
        }

        protected void btnVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                string codVch = txtVoucher.Text;
                
                Voucher vch = new Voucher();
                VoucherAS vchAS = new VoucherAS();

                vch = vchAS.buscarVoucher(codVch);
                
                    if (vch.FechCanje == null && vch.CodVoucher != null)
                    {
                        Session.Add("Voucher", vch);
                        Response.Redirect("SelectProduct.aspx", false);

                    }
                    else if (vch.FechCanje != null && vch.CodVoucher != null)
                    {
                        Response.Redirect("vchCanjeado.aspx", false);
                    }
                    else {
                        Response.Redirect("ErrorPage.aspx", false);
                    }

            }
            catch (Exception ex)
            {
                throw ex; // Definir error handler
            }

        }
    }
}