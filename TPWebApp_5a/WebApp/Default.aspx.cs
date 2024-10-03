using ApplicationService;
using Model;
using System;
using System.Collections.Generic;
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

                if (vch.FechCanje == null)
                {
                    Session.Add("Voucher", vch);
                }
                else
                {
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