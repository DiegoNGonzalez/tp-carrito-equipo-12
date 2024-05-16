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
        public List<ArticuloEnCarrito> articulosEnCarrito = new List<ArticuloEnCarrito>();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public Label contadorCarrito = new Label();
        public int contadorArticulos = 0;
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
                AgregarAlCarrito();
                contadorArticulos = Session["ContadorArticulos"] != null ? Convert.ToInt32(Session["ContadorArticulos"]) + 1 : 1;
                Session.Add("ContadorArticulos", contadorArticulos);
                Response.Redirect("default.aspx", false);
            }
        }
        public void AgregarAlCarrito()
        {
            if (Session["articulosEnCarrito"] != null)
            {
                articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
                articulos = (List<Articulo>)Session["articulos"];
                int id = Convert.ToInt32(Session["idArticuloAgregar"]);
                Articulo auxArticuloId = articulos.Find(x => x.IDArticulo == id);
                bool existe = ExisteEnCarrito(id);
                if (existe)
                {
                    ArticuloEnCarrito auxArticuloEnCarrito = articulosEnCarrito.Find(x => x.IDArticulo == id);
                    auxArticuloEnCarrito.Cantidad++;
                    auxArticuloEnCarrito.Subtotal = auxArticuloEnCarrito.Cantidad * auxArticuloEnCarrito.PrecioArticulo;
                    Session.Add("articulosEnCarrito", articulosEnCarrito);
                    return;
                }
                else
                {
                    ArticuloEnCarrito articuloEnCarrito = new ArticuloEnCarrito(auxArticuloId);
                    articulosEnCarrito.Add(articuloEnCarrito);
                    Session.Add("articulosEnCarrito", articulosEnCarrito);
                }
                   


            }else
            {
                articulos = (List<Articulo>)Session["articulos"];
                int id = Convert.ToInt32(Session["idArticuloAgregar"]);
                Articulo auxArticuloId = articulos.Find(x => x.IDArticulo == id);

                ArticuloEnCarrito articuloEnCarrito = new ArticuloEnCarrito(auxArticuloId);
                articulosEnCarrito.Add(articuloEnCarrito);
                Session.Add("articulosEnCarrito", articulosEnCarrito);
            }
            

        }
        public bool ExisteEnCarrito(int id)
        {
            if (Session["articulosEnCarrito"] != null)
            {
                articulosEnCarrito = (List<ArticuloEnCarrito>)Session["articulosEnCarrito"];
                if (articulosEnCarrito.Find(x => x.IDArticulo == id) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}