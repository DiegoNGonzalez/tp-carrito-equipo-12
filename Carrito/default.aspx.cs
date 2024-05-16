using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using AccesoDataBase;
using Negocio;

namespace Carrito
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> articulos = new List<Articulo>();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public Label contadorCarrito = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            negocio = new ArticuloNegocio();
            articulos = negocio.ListarArticulos();
            rptArticulos.DataSource = articulos;
            rptArticulos.DataBind();
            Session.Add("articulos", articulos);
            }
            contadorCarrito = (Label)Master.FindControl("contadorCarrito");
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                string idArticulo = e.CommandArgument.ToString();
                Response.Redirect("VerDetalle.aspx?idArticulo=" + idArticulo, false);
            } else if(e.CommandName == "Agregar")
            {
                string idArticulo = e.CommandArgument.ToString();
                Session.Add("idArticuloAgregar", idArticulo);
            }
        }

    }
}