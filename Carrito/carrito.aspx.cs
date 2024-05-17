
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
                lblTotal.Text= Session["SubTotalArticulos"] != null ? Session["SubTotalArticulos"].ToString() : "0";
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
            Session.Add("ContadorArticulos", contadorArticulos);
            Session["SubTotalArticulos"] = Session["SubTotalArticulos"] != null ? auxArticulo.PrecioArticulo + Convert.ToDecimal(Session["SubTotalArticulos"]) : 0;
            Response.Redirect("carrito.aspx", false);
        }
    }
}