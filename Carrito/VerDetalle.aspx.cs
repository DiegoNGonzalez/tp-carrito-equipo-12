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
    public partial class VerDetalle : System.Web.UI.Page
    {
        public List<Articulo> articulos = new List<Articulo>();
        public List<ArticuloEnCarrito> articulosEnCarrito = new List<ArticuloEnCarrito>();
        public List<Imagen> imagenes = new List<Imagen>();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public int contadorArticulos = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = negocio.encontrarArticuloXid(idArticulo);
                if (articulo != null)
                {
                    lblNombre.Text = articulo.NombreArticulo;
                    lblDescripcion.Text = articulo.DescripcionArticulo;
                    lblMarca.Text = articulo.MarcaArticulo.NombreMarca;
                    lblPrecio.Text = articulo.PrecioArticulo.ToString();
                    imagenes = articulo.Imagenes;
                    rptImagenes.DataSource = imagenes;
                    rptImagenes.DataBind();
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //contadorCarrito.Text = (Convert.ToInt32(contadorCarrito.Text) + 1).ToString
            string idArticulo = Request.QueryString["idArticulo"];
            Session.Add("idArticuloAgregar", idArticulo);
            AgregarAlCarrito();
            contadorArticulos = Session["ContadorArticulos"] != null ? Convert.ToInt32(Session["ContadorArticulos"]) + 1 : 1;
            Session.Add("ContadorArticulos", contadorArticulos);
            Response.Redirect("default.aspx", false);
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



            }
            else
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