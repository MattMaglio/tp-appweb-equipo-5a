<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="WebApp.Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-auto">

                <div class="alert alert-primary d-flex align-items-center text-center" role="alert">

                    <div>
                        <h2>¡Felicitaciones!</h2>
                        <br />
                        <h5>Recibirás un mail cuando tu premio esté disponible para retirar</h5>
                        
                    </div>
                </div>
                <asp:Button Text="Validar otro voucher" ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click" runat="server" />

            </div>
        </div>
    </div>




</asp:Content>

