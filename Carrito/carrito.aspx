﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="Carrito.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <h1>Carrito de compras</h1>
        <p>Estos son los productos que has agregado al carrito de compras:</p>
        <div class="list-group">

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">Producto</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">SubTotal</th>
                        <th scope="col">Cantidad</th>
                    </tr>
                </thead>
                <asp:Repeater ID="rptArticulosEnCarrito" runat="server" OnItemDataBound="rptArticulosEnCarrito_ItemDataBound">
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <th scope="row">
                                    <div style="width: 150px; height: 150px; overflow: hidden; display: inline-block;">
                                        <img src="<%# Eval("Imagenes[0].URLImagen") %>" class="img-fluid" alt="...">
                                    </div>
                                </th>
                                <td>
                                    <h5 class="mb-1"><%# Eval("NombreArticulo") %></h5>
                                    <p class="mb-1"><%# Eval("DescripcionArticulo") %></p>
                                </td>
                                <td>
                                    <small>$<asp:Literal ID="litSubtotal" runat="server" Text='<%# Eval("Subtotal") %>'></asp:Literal></small>

                                </td>
                                <td>
                                    <p><%#Eval("Cantidad") %></p>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
                <tfoot>
                    <tr>
                        <td colspan="2">
                            <div class="d-flex w-100 justify-content-between">
                                <h5 class="mb-1">Total</h5>
                                <small class="text-right">$<%= Total %></small>
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>


        </div>

    </div>


</asp:Content>
