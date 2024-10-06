<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectProduct.aspx.cs" Inherits="WebApp.SelectProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card" runat="server" ID="card1">
                    <img runat="server" ID="img1" class="card-img-top" alt="Imagen 1" />
                    <div class="card-body">
                        <h5 runat="server" ID="title1" class="card-title"></h5>
                        <p runat="server" ID="description1" class="card-text"></p>
                        <asp:Button ID="btnSelect1" runat="server" Text="Seleccionar" CommandArgument="1" OnClick="btnSelect1_Click" CssClass="btn btn-outline-warning" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card" runat="server" ID="card2">
                    <img runat="server" ID="img2" class="card-img-top" alt="Imagen 2" />
                    <div class="card-body">
                        <h5 runat="server" ID="title2" class="card-title"></h5>
                        <p runat="server" ID="description2" class="card-text"></p>
                        <asp:Button ID="btnSelect2" runat="server" Text="Seleccionar" CommandArgument="2" OnClick="btnSelect2_Click" CssClass="btn btn-outline-warning" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card" runat="server" ID="card3">
                    <img runat="server" ID="img3" class="card-img-top" alt="Imagen 3" />
                    <div class="card-body">
                        <h5 runat="server" ID="title3" class="card-title"></h5>
                        <p runat="server" ID="description3" class="card-text"></p>
                        <asp:Button ID="btnselec3" runat="server" OnClick="btnselec3_Click" Text="Seleccionar" CommandArgument="3"  CssClass="btn btn-outline-warning" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
