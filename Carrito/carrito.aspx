<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="Carrito.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles.css" rel="stylesheet" />
    <div class="container carritoContainer">

        <h1 class="text-center mb-4 text-decoration-underline text-white fw-normal">Carrito de compras</h1>
        <p class="mb-4 txtBlanco">Estos son los productos que has agregado al carrito de compras:</p>
        <div class="table-responsive">

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col" class="fondotabla">
                            <div class="centrar txtBlanco">Producto</div>
                        </th>
                        <th scope="col" class="fondotabla">
                            <div class="centrar txtBlanco">Descripcion</div>
                        </th>
                        <th scope="col" class="fondotabla">
                            <div class="centrar txtBlanco">SubTotal</div>
                        </th>
                        <th scope="col" class="fondotabla">
                            <div class="centrar txtBlanco">Cantidad</div>
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="rptArticulosEnCarrito" runat="server">
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th scope="row" class="fondotabla centrar">
                                    <div style="width: 120px; height: 120px; overflow: hidden; display: inline-block;">
                                        <img src="<%# Eval("Imagenes[0].URLImagen") %>" class="img-fluid" alt="..." onerror="this.onerror=null; this.src='https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg?w=826';">
                                    </div>
                                </th>
                                <td class="fondotabla">
                                    <h5 class="mb-1 centrar txtBlanco"><%# Eval("NombreArticulo") %></h5>
                                    <p class="mb-1 centrar txtBlanco"><%# Eval("DescripcionArticulo") %></p>
                                </td>
                                <td class="fondotabla">
                                    <p class="fs-5 centrar txtBlanco">$<asp:Label ID="lblSubtotal" runat="server" Text='<%# Eval("Subtotal") %>'></asp:Label></p>
                                </td>
                                <td class="fondotabla">
                                    <div class="d-flex flex-column align-items-center">
                                        <div class="d-flex justify-content-center mb-2">
                                            <asp:Button ID="BtnRestar" Text="-" CssClass="btn btn-primary mx-1" CommandArgument='<%# Eval("IDArticulo") %>' CommandName="ArticuloRestar" OnClick="BtnRestar_Click" runat="server" />
                                            <p class="text-center my-auto txtBlanco"><%# Eval("Cantidad") %></p>
                                            <asp:Button ID="btnSumar" Text="+" CssClass="btn btn-primary mx-1" CommandArgument='<%# Eval("IDArticulo") %>' CommandName="ArticuloID" OnClick="btnSumar_Click" runat="server" />
                                        </div>
                                        <asp:Button ID="btnBorrar" Text="Borrar" CssClass="btn btn-danger btn-block" CommandArgument='<%# Eval("IDArticulo") %>' CommandName="ArticuloBorrar" OnClick="btnBorrar_Click" runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
                <tfoot>
                    <tr>
                        <td colspan="2" class="fondotabla">
                            <div class="d-flex justify-content-between">
                                <h5 class="mb-1 txtBlanco">Total</h5>
                                <asp:Label ID="lblTotal" CssClass="fs-5 txtBlanco" runat="server" Text="">$</asp:Label>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>

        </div>

    </div>



</asp:Content>
