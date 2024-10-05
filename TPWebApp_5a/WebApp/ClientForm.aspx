<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="WebApp.ClientForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <h1>Ingresá tus datos</h1>
            <br>
             <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
 <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label2" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
            </div>
            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label6" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label8" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label10" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
            </div>
            <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label12" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
            </div>
            <asp:Label ID="Label13" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label14" runat="server" ForeColor="Green"></asp:Label>


            <div class="mb-3">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
            </div>
            <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label16" runat="server" ForeColor="Green"></asp:Label>



            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                <label class="form-check-label" for="flexCheckDefault">
                    Acepto los términos y condiciones
                </label>
            </div>

        </div>




        <div class="mb-3">
            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
        </div>
       







    </div>



    </div>







</asp:Content>
