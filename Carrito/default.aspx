<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Carrito.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-primary" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CodigoArticulo" HeaderText="Codigo" />
                <asp:BoundField DataField="NombreArticulo" HeaderText="Nombre" />
                <asp:BoundField DataField="PrecioArticulo" HeaderText="Precio" />
                <asp:BoundField DataField="MarcaArticulo" HeaderText="Marca" />
                <asp:BoundField DataField="CategoriaArticulo" HeaderText="Categoria" />
                </Columns>
        </asp:GridView>

    </div>
</asp:Content>
