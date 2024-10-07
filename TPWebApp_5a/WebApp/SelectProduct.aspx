<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectProduct.aspx.cs" Inherits="WebApp.SelectProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row"> 
            <!-- Repeater para los artículos -->
            <asp:Repeater ID="repPremios" runat="server">
                <ItemTemplate>
                    <!-- Cada tarjeta ocupará 4 columnas (de un total de 12) -->
                    <div class="col-md-4">
                        <div class="card" style="width: 18rem;">
                          <!-- Carousel dentro de la tarjeta -->
                          <div id="carousel<%# Eval("Codigo") %>" class="carousel slide">
                            <!-- Indicadores del carousel -->
                            <div class="carousel-indicators">
                              <asp:Repeater ID="repIndicators" runat="server" DataSource='<%# Eval("Imagen") %>'>
                                <ItemTemplate>
                                  <button type="button" data-bs-target="#carousel<%# Eval("Id") %>" 
                                          data-bs-slide-to='<%# Container.ItemIndex %>' 
                                          class='<%# Container.ItemIndex == 0 ? "active" : "" %>' 
                                          aria-current="true" aria-label="Slide <%# Container.ItemIndex + 1 %>'"></button>
                                </ItemTemplate>
                              </asp:Repeater>
                            </div>

                            <!-- Repeater para las imágenes del carousel -->
                            <div class="carousel-inner">
                              <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("Imagen") %>'>
                                <ItemTemplate>
                                  <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt="Imagen del artículo">
                                  </div>
                                </ItemTemplate>
                              </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Codigo") %>" data-bs-slide="prev">
                              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                              <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Codigo") %>" data-bs-slide="next">
                              <span class="carousel-control-next-icon" aria-hidden="true"></span>
                              <span class="visually-hidden">Next</span>
                            </button>
                          </div>

                          <!-- Contenido del cuerpo de la tarjeta -->
                          <div class="card-body">
                              <h5 class="card-title"><%# Eval("Nombre") %></h5>
                              <p class="card-text"><%# Eval("Descripcion") %></p>
                              <asp:Button ID="btnPickArt" CssClass="btn btn-primary" OnClick="btnPickArt_Click" CommandArgument='<%# Eval("Id") %>' CommandName="ArtId" runat="server" Text="¡Elegir este!" />
                          </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater> 
        </div>
    </div>
</asp:Content>
