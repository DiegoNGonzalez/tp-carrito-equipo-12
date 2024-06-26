﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="Carrito.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container detalleContainer mt-4 text-center">
        <asp:Label Text="Detalle del Producto" runat="server" CssClass="h1 text-white " />
        <div class="row mt-4 d-flex align-items-center justify-content-center ">

            <div class="col-6">
                <div class="card" style="max-width: 40rem; margin: auto;">

                    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Repeater ID="rptImagenes" runat="server">
                                <ItemTemplate>
                                    <div class="carousel-item mt-2 <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                        <img src='<%# Eval("UrlImagen") %>' class="d-block mx-auto card-img-top" style="width: 200px; height: 200px; object-fit: cover;" alt="Problemas al cargar imagen" onerror="this.onerror=null; this.src='https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg?w=826';">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev " type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon " aria-hidden="true">  </span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next " type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                            <span class="carousel-control-next-icon  " aria-hidden="true">  </span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>


                    <div class="card-body">
                        <h3 class="card-title">
                            <asp:Label ID="lblNombre" runat="server" /></h3>
                        <p class="card-text fs-5">
                            <asp:Label ID="lblDescripcion" runat="server" />.</p>
                    </div>
                    <ul class="list-group list-group-flush fs-5 ">
                        <li class="list-group-item fondoCard liMedio">
                            <asp:Label ID="lblMarca" runat="server" /></li>
                        <li class="list-group-item fondoCard liMedio">
                            <asp:Label ID="lblCategoria" runat="server" /></li>
                        <li class="list-group-item fondoCard">
                            <asp:Label ID="lblPrecio" runat="server" /></li>
                    </ul>
                    <div class="card-body fondoCard">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary " OnClick="btnAgregar_Click" />
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
