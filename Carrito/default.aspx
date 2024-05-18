<%@ Page Title="" Language="C#" MasterPageFile="~/Carrito.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Carrito.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosDefault.css" rel="stylesheet" />
    <div class="container">
        <div class="text-center mb-4">
            <h1 class="fs-1">Articulos</h1>
        </div>
        <div class="row mb-5 text-center justify-content-center">
            <div class="col-md-3">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Busqueda de articulos..." />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <asp:CheckBox ID="chkFiltrar" runat="server" Text="Filtrar" OnCheckedChanged="chkFiltrar_CheckedChanged" AutoPostBack="True" />
        <div class="row mb-5 text-center justify-content-center" id="Filtrado" runat="server">
            
                <div class="col-md-4">

                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-select mb-1">
                        <asp:ListItem Text="Todas" Value="0" />
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-select mb-1">
                        <asp:ListItem Text="Todas" Value="0" />
                    </asp:DropDownList>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar" CssClass="btn btn-primary" OnClick="btnLimpiarFiltro_Click" />
                </div>
            </div>
            <div class="row row-cols-1 row-cols-md-3 g-4 mb-4">

                <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="rptArticulos_ItemCommand">
                    <ItemTemplate>
                        <div class="card card-lev text-center shadow-lg p-3 mb-3 bg-body-tertiary rounded" style="width: 18rem; margin-right: auto; margin-left: auto; display: flex; flex-direction: column;">
                            <img src='<%# Eval("Imagenes[0].URLImagen") %>'onerror="this.onerror=null; this.src='https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg?w=826';" class="card-img-top" alt="...">
                            <div class="card-body" style="flex: 1 0 auto; display: flex; flex-direction: column; justify-content: flex-End;">
                                <div>
                                    <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                    <p class="card-text"><%# Eval("DescripcionArticulo") %></p>
                                    <p class="card-text">$<%# Eval("PrecioArticulo") %></p>
                                </div>
                            </div>
                            <div class="card-footer shadow p-3 bg-body-tertiary rounded" style="display: flex; justify-content: space-around;">
                                <asp:LinkButton ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-primary" CommandName="Agregar" CommandArgument='<%# Eval("IDArticulo") %>' />
                                <asp:LinkButton ID="btnVerDetalle" Text="Ver Detalle" runat="server" CssClass="btn btn-primary" CommandName="VerDetalle" CommandArgument='<%# Eval("IDArticulo") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>




            </div>

        </div>
</asp:Content>
