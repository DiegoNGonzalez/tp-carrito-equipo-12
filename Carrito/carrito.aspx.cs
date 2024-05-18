
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using AccesoDataBase;
using Negocio;
using System.Data.SqlTypes;

namespace Carrito
{
    public partial class carrito : System.Web.UI.Page
    {
        public decimal Total { get; set; } = 0;
        public List<ArticuloEnCarrito> articulosEnCarrito = new List<ArticuloEnCarrito>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
                rptArticulosEnCarrito.DataSource = articulosEnCarrito;
                rptArticulosEnCarrito.DataBind();
            }
            decimal subtotal = Session["SubTotalArticulos"] != null ? Convert.ToDecimal(Session["SubTotalArticulos"]) : 0;
            string total = subtotal.ToString("F2");
            lblTotal.Text = "$"+ total;
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            int contadorArticulos;
            string valor = ((Button)sender).CommandArgument;
            articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
            ArticuloEnCarrito auxArticulo = articulosEnCarrito.Find(articulosEnCarrito => articulosEnCarrito.IDArticulo == Convert.ToInt32(valor));
            auxArticulo.Cantidad = auxArticulo.Cantidad + 1;
            auxArticulo.Subtotal = auxArticulo.PrecioArticulo * auxArticulo.Cantidad;
            contadorArticulos = Session["ContadorArticulos"] != null ? Convert.ToInt32(Session["ContadorArticulos"]) + 1 : 1;
            Session["ContadorArticulos"] = contadorArticulos;
            Session["SubTotalArticulos"] = Session["SubTotalArticulos"] != null ? auxArticulo.PrecioArticulo + Convert.ToDecimal(Session["SubTotalArticulos"]) : 0;
            Response.Redirect("carrito.aspx", false);
        }

        protected void BtnRestar_Click(object sender, EventArgs e)
        {
            int contadorArticulos;
            string valor = ((Button)sender).CommandArgument;
            articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
            ArticuloEnCarrito auxArticulo = articulosEnCarrito.Find(articulosEnCarrito => articulosEnCarrito.IDArticulo == Convert.ToInt32(valor));
            if (auxArticulo.Cantidad > 1)
            {
                auxArticulo.Cantidad = auxArticulo.Cantidad - 1;
                auxArticulo.Subtotal = auxArticulo.PrecioArticulo * auxArticulo.Cantidad;
                contadorArticulos = Session["ContadorArticulos"] != null ? Convert.ToInt32(Session["ContadorArticulos"]) - 1 : 1;
                Session["ContadorArticulos"] = contadorArticulos;
                Session["SubTotalArticulos"] = Session["SubTotalArticulos"] != null ? Convert.ToDecimal(Session["SubTotalArticulos"]) - auxArticulo.PrecioArticulo : 0;
                Response.Redirect("carrito.aspx", false);
            }
            
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
            ArticuloEnCarrito auxArticulo = articulosEnCarrito.Find(articulosEnCarrito => articulosEnCarrito.IDArticulo == Convert.ToInt32(valor));
            Session["ContadorArticulos"] = Session["ContadorArticulos"] != null ? Convert.ToInt32(Session["ContadorArticulos"]) - auxArticulo.Cantidad : 1;
            Session["SubTotalArticulos"] = Session["SubTotalArticulos"] != null ? Convert.ToDecimal(Session["SubTotalArticulos"]) - auxArticulo.Subtotal : 0;
            articulosEnCarrito.RemoveAll(art => art.IDArticulo == Convert.ToInt32(valor));
            Response.Redirect("carrito.aspx", false);
        }
    }
}