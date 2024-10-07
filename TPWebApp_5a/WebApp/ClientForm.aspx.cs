using ApplicationService;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApp
{
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fx dni para llenar form
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(txtDNI.Text) && int.TryParse(txtDNI.Text, out int dni))
                {
                    ClienteAS clienteAS = new ClienteAS();
                    var cliente = clienteAS.ObtenerClientePorDNI(dni);
                    if (cliente != null)
                    {
                        // Autocompletar el formulario
                        txtNombre.Text = cliente.ClienteNombre;
                        txtApellido.Text = cliente.ClienteApellido;
                        txtEmail.Text = cliente.ClienteEmail;
                        txtDireccion.Text = cliente.ClienteDireccion;
                        txtCiudad.Text = cliente.ClienteCiudad;
                        txtCP.Text = cliente.ClienteCP.ToString();
                    }
                    else
                    {
                        lblError.Text = "Cliente no encontrado.";
                    }
                }
            }
        }
        public bool EsEmailValido(string email)
        {
            return email.Contains("@") && email.Contains(".") && email.IndexOf('@') < email.LastIndexOf('.');
        }
        // manejo el evento de cambio en el TextBox de DNI
        public void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {
                ClienteAS clienteAS = new ClienteAS();
                var cliente = clienteAS.ObtenerClientePorDNI(dni);
                if (cliente != null)
                {
                    // Autocompleto el formulario
                    txtNombre.Text = cliente.ClienteNombre;
                    txtApellido.Text = cliente.ClienteApellido;
                    txtEmail.Text = cliente.ClienteEmail;
                    txtDireccion.Text = cliente.ClienteDireccion;
                    txtCiudad.Text = cliente.ClienteCiudad;
                    txtCP.Text = cliente.ClienteCP.ToString();
                }
                else
                {
                    lblError.Text = "Cliente no encontrado.";
                }
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!chkTerminos.Checked)
            {
                lblError.Text = "Debes aceptar los términos y condiciones para continuar.";
                return;
            }


            try
            {

                ClienteAS clienteAS = new ClienteAS();
                VoucherAS vchAS = new VoucherAS();

                if (!int.TryParse(txtDNI.Text, out int dni))
                {
                    lblError.Text = "El DNI debe ser un número válido.";
                    return;
                }

                // Verifico si el cliente ya existe
                var clienteExistente = clienteAS.ObtenerClientePorDNI(dni);
                if (clienteExistente != null)
                {
                    // Si el cliente ya existe,autocompleto y me voy a success

                    Voucher sessionVch = new Voucher();

                    sessionVch = (Voucher)Session["Voucher"];
                    sessionVch.IdCli = clienteAS.ObtenerIdCliente(dni);
                    sessionVch.FechCanje = DateTime.Now;

                    Session.Add("Voucher", sessionVch);
                    vchAS.updateVoucher(sessionVch);

                    Response.Redirect("success.aspx");
                    return;
                }

                // Si no existe, creo un new client
                Cliente clienteNuevo = new Cliente();
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

                Voucher vch = new Voucher();

                vch = (Voucher)Session["Voucher"];
                vch.IdCli = clienteAS.ObtenerIdCliente(dni);
                vch.FechCanje = DateTime.Now;

                Session.Add("Voucher", vch);
                vchAS.updateVoucher(vch);

                Response.Redirect("success.aspx");


            }
            catch (Exception)
            {
                lblError.Text = "Ocurrió un error al agregar el cliente: ";
                //Session.Add("error",ex);
                throw;
            }
        }
        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            // Vacio los campos del form
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = string.Empty;
            chkTerminos.Checked = false;

            // Limpiar etiquetas de error y success
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

    }

}