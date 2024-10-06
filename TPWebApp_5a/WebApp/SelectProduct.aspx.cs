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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloAS articuloAS = new ArticuloAS();
            if (!IsPostBack)
            {
                List<Articulo> premios = articuloAS.listarPremiosSp(); // listado con procedure
                if(premios.Count > 3)
                {
                    premios.Take(3).ToList(); // limita a 3 mostrar 3 articulos 
                }
                // Asignamos los valores a cada tarjeta
                if (premios.Count > 0)
                {
                    img1.Attributes["src"] = premios[0].Imagen.ImagenUrl; // Asignamos la URL de la imagen
                    title1.InnerText = premios[0].Nombre; // nombre
                    description1.InnerText = premios[0].Descripcion; // descripción
                }

                if (premios.Count > 1)
                {
                    img2.Attributes["src"] = premios[1].Imagen.ImagenUrl;
                    title2.InnerText = premios[1].Nombre;
                    description2.InnerText = premios[1].Descripcion;
                }

                if (premios.Count > 2)
                {
                    img3.Attributes["src"] = premios[2].Imagen.ImagenUrl;
                    title3.InnerText = premios[2].Nombre;
                    description3.InnerText = premios[2].Descripcion;
                }
            }
            
        }

        protected void btnSelect1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //obtengo el boton que se disparo
            string id = btn.CommandArgument; // le paso el id del btn

            Response.Redirect($"ClientForm.aspx?id={id}"); // se lo paso a la pagina siguente
        }
        protected void btnSelect2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; 
            string id = btn.CommandArgument; 

            Response.Redirect($"ClientForm.aspx?id={id}"); 
        }
        protected void btnselec3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect($"ClientForm.aspx?id={id}"); 
        }


    }
}