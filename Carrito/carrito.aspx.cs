using Dominio;
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
    public partial class carrito : System.Web.UI.Page
    {
        public List<ArticuloEnCarrito> articulosEnCarrito = new List<ArticuloEnCarrito>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["articulosEnCarrito"] != null)
                {
                    articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
                }
                else
                {
                    List<Articulo> listArticulos = (List<Articulo>)Session["articulos"];

                    int id = Convert.ToInt32(Session["idArticuloAgregar"]);
                    Articulo auxArticuloId = listArticulos.Find(x => x.IDArticulo == id); 

                    ArticuloEnCarrito articuloEnCarrito = new ArticuloEnCarrito(auxArticuloId);

                    articulosEnCarrito = new List<ArticuloEnCarrito>();
                    articulosEnCarrito.Add(articuloEnCarrito);
                    //Falta agregar en Session los ArticulosEnCarrito.
                }
                rptArticulosEnCarrito.DataSource = articulosEnCarrito;
                rptArticulosEnCarrito.DataBind();
            }
        }
    }
}