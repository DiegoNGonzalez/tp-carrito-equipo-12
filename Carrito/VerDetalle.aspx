<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="Carrito.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <asp:Label Text="Detalle del Producto" runat="server" CssClass="h2" />
        <div class="row">
            <div class="col-md-6">
                <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid" />
            </div>
            <div class="col-md-6">
                <h3>
                    <asp:Label ID="lblNombre" runat="server" /></h3>
                <p>
                    <asp:Label ID="lblDescripcion" runat="server" /></p>
                <p>
                    <asp:Label ID="lblMarca" runat="server" /></p>
                <p>
                    <asp:Label ID="lblPrecio" runat="server" /></p>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
            </div>

        </div>
</asp:Content>
