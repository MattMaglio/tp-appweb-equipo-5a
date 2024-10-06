<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherPage.aspx.cs" Inherits="WebApp.VoucherPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
     <div class="col-2"></div>
         <div class="col">
             <div class="mb-3">
                 <asp:Label ID="lblTitulo" runat="server" Text="Ingresa el codigo del voucher papa!"></asp:Label>
             </div>
             <div class="mb-3">
                 <asp:TextBox ID="txtVoucher" placeholder="  xxx xxx xxx xxx xxx"  runat="server"></asp:TextBox>
             </div>
             <div class="mb-3">
                   <asp:Button ID="btnVoucher" CssClass="btn btn-primary" OnClick="btnVoucher_Click" runat="server" Text="Validar!" />
                 </div>
         </div>
     <div class="col-2"></div>
</asp:Content>
