<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Carrito.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container">
            <div>
                <h1>Articulos</h1>
            </div>
            <div class="row row-cols-1 row-cols-md-3 g-4">



                <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="rptArticulos_ItemCommand">
                    <ItemTemplate>
                        <div class="card" style="width: 18rem;">
                            <img src="<%# Eval("Imagenes[0].URLImagen") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                <p class="card-text"><%# Eval("DescripcionArticulo") %></p>
                                <p class="card-text">$<%# Eval("PrecioArticulo") %></p>
                                <asp:LinkButton ID="btnAgregar" Text="agregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                                <asp:LinkButton ID="btnVerDetalle" Text="Ver Detalle" runat="server" CssClass="btn btn-primary" CommandName="VerDetalle" CommandArgument='<%# Eval("IDArticulo") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</asp:Content>
