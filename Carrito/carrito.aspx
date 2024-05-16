<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="Carrito.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <h1>Carrito de compras</h1>
        <p>Estos son los productos que has agregado al carrito de compras:</p>
        <div class="list-group">

            <asp:Repeater ID="rptArticulosEnCarrito" runat="server">
                <ItemTemplate>
                    <a href="#" class="list-group-item list-group-item-action" aria-current="true">
                        <div class="d-flex w-100 justify-content-between">
                            <img src="<%# Eval("Imagenes[0].URLImagen") %>" class="img-fluid" alt="...">
                            <h5 class="mb-1"><%# Eval("NombreArticulo") %></h5>
                            <p>x<%#Eval("Cantidad") %></p>
                            <small>$<%#Eval("Subtotal") %></small>
                        </div>
                        <p class="mb-1"><%# Eval("DescripcionArticulo") %></p>
                        <small>And some small print.</small>
                    </a>

                </ItemTemplate>
            </asp:Repeater>


        </div>

    </div>


</asp:Content>
