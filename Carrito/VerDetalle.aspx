<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="Carrito.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <asp:Label Text="Detalle del Producto" runat="server" CssClass="h2" />
        <div class="row">

            <div class="card" style="width:400px; height: 205px;">
                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptImagenes" runat="server" >
                            <ItemTemplate>
                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <img src='<%# Eval("UrlImagen") %>' class="d-block mx-auto card-img-top"  style="width:200px; height:200px; object-fit:cover;" alt="Problemas al cargar imagen" onerror="this.onerror=null; this.src='https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg?w=826';" >
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon bg-primary" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                        <span class="carousel-control-next-icon bg-primary" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>


            </div>
            <div class="col-md-6">
                <h3>
                    <asp:Label ID="lblNombre" runat="server" /></h3>
                <p>
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <p>
                    <asp:Label ID="lblMarca" runat="server" />
                </p>
                <p>
                    <asp:Label ID="lblPrecio" runat="server" />
                </p>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
            </div>

        </div>
</asp:Content>
