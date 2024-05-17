
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
        
       

    }
}