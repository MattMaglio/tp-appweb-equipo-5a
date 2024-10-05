using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           txtId.Enabled = false;   
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteNuevo = new Cliente();
                clienteNuevo.ClienteDNI = int.Parse(txtDNI.Text);
                clienteNuevo.ClienteNombre = txtNombre.Text;
                clienteNuevo.ClienteApellido = txtApellido.Text;
                clienteNuevo.ClienteEmail = txtEmail.Text;
                clienteNuevo.ClienteDireccion = txtDireccion.Text;
                clienteNuevo.ClienteCiudad = txtCiudad.Text;
                clienteNuevo.ClienteCP = int.Parse(txtCP.Text);
            }
            catch (Exception)
            {
                //Session.Add("error",ex);
                throw;
            }
        }
    }
}