using ApplicationService;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        public bool EsEmailValido(string email)
        {
            return email.Contains("@") && email.Contains(".") && email.IndexOf('@') < email.LastIndexOf('.');
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                Cliente clienteNuevo = new Cliente();
                ClienteAS clienteAS = new ClienteAS();
               
                if (!int.TryParse(txtDNI.Text, out int dni))
                {
                    lblError.Text = "El DNI debe ser un número válido.";
                    return;
                }
                clienteNuevo.ClienteDNI = dni;

                // Validar Nombre
                clienteNuevo.ClienteNombre = txtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteNombre))
                {
                    lblError.Text = "El nombre del cliente es obligatorio.";
                    return;
                }

                if (clienteNuevo.ClienteNombre.Any(char.IsDigit))
                {
                    lblError.Text = "El nombre del cliente no puede contener números.";
                    return;
                }

                // Validar Apellido
                clienteNuevo.ClienteApellido = txtApellido.Text.Trim();
                if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteApellido))
                {
                    lblError.Text = "El apellido del cliente es obligatorio.";
                    return;
                }

                if (clienteNuevo.ClienteApellido.Any(char.IsDigit))
                {
                    lblError.Text = "El apellido del cliente no puede contener números.";
                    return;
                }

                // Validar Email
                clienteNuevo.ClienteEmail = txtEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteEmail))
                {
                    lblError.Text = "El email del cliente es obligatorio.";
                    return;
                }

                // Validar formato de Email
                if (!EsEmailValido(clienteNuevo.ClienteEmail))
                {
                    lblError.Text = "El email del cliente no tiene un formato válido.";
                    return;
                }

                // Validar Dirección
                clienteNuevo.ClienteDireccion = txtDireccion.Text.Trim();
                if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteDireccion))
                {
                    lblError.Text = "La dirección del cliente es obligatoria.";
                    return;
                }

                // Validar Ciudad
                clienteNuevo.ClienteCiudad = txtCiudad.Text.Trim();
                if (string.IsNullOrWhiteSpace(clienteNuevo.ClienteCiudad))
                {
                    lblError.Text = "La ciudad del cliente es obligatoria.";
                    return;
                }

                if (clienteNuevo.ClienteCiudad.Any(char.IsDigit))
                {
                    lblError.Text = "La ciudad del cliente no puede contener números.";
                    return;
                }

                // Validar Código Postal
                if (!int.TryParse(txtCP.Text, out int cp))
                {
                    lblError.Text = "El código postal debe ser un número válido.";
                    return;
                }
                clienteNuevo.ClienteCP = cp;




                clienteAS.agregarCliente(clienteNuevo);
                lblSuccess.Text = "Cliente agregado exitosamente.";
                lblError.Text = ""; 


            }
            catch (Exception)
            {
                lblError.Text = "Ocurrió un error al agregar el cliente: ";
                //Session.Add("error",ex);
                throw;
            }
        }
    }
}