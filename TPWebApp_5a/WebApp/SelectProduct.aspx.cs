using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataPersistence;
using Model;
using ApplicationService;
using System.Web.Compilation;


namespace WebApp
{
    public partial class SelectProduct : System.Web.UI.Page
    {

        public List<Articulo> ListArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloAS articuloAS = new ArticuloAS();
            ListArticulos = articuloAS.listarPremios();
           if(!IsPostBack)
            {
                repPremios.DataSource = ListArticulos;
                repPremios.DataBind();
            }
        }

        protected void btnPickArt_Click(object sender, EventArgs e)
        {
            try
            {
                string idArt = ((Button)sender).CommandArgument;
                    
                Voucher vch = new Voucher();

                vch = (Voucher)Session["Voucher"];
                vch.IdArt = int.Parse(idArt);

                if (vch.FechCanje == null)
                {
                    Session.Add("Voucher", vch);
                    Response.Redirect("ClientForm.aspx", false);
                }

            }
            catch (Exception ex)
                {
                    throw ex; // Definir error handler
                }

        }

    }
}