using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using AccesoDataBase;
using Negocio;
using System.Web.UI.HtmlControls;

namespace Carrito
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> articulos = new List<Articulo>();
        public List<ArticuloEnCarrito> articulosEnCarrito = new List<ArticuloEnCarrito>();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public Label contadorCarrito = new Label();
        public int contadorArticulos = 0;
        public List<Marca> marcas = new List<Marca>();
        public List<Categoria> categorias = new List<Categoria>();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                negocio = new ArticuloNegocio();
                marcaNegocio = new MarcaNegocio();
                categoriaNegocio = new CategoriaNegocio();
                marcas = marcaNegocio.ListarMarcas();
                categorias = categoriaNegocio.listarCategorias();
                articulos = negocio.ListarArticulos();
                rptArticulos.DataSource = articulos;
                rptArticulos.DataBind();
                Session.Add("articulos", articulos);
                Filtrado.Visible = false;
                cargarDropDowns();


            }
            contadorCarrito = (Label)Master.FindControl("contadorCarrito");
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            List<Articulo> lista = (List<Articulo>)Session["articulos"];
            int idMarca = Convert.ToInt32(ddlMarcas.SelectedValue);
            int idCategoria = Convert.ToInt32(ddlCategorias.SelectedValue);


            if (idMarca == 0 && idCategoria == 0)
            {
                rptArticulos.DataSource = lista;
                rptArticulos.DataBind();
                return;
            }
            else if (idMarca == 0)
            {
                List<Articulo> listaFiltrada = lista.FindAll(x => x.CategoriaArticulo.IDCategoria == idCategoria);
                rptArticulos.DataSource = listaFiltrada;
                rptArticulos.DataBind();
                if (listaFiltrada.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron resultados";
                }
                return;
            }
            else if (idCategoria == 0)
            {
                List<Articulo> listaFiltrada = lista.FindAll(x => x.MarcaArticulo.IDMarca == idMarca);
                rptArticulos.DataSource = listaFiltrada;
                rptArticulos.DataBind();
                if (listaFiltrada.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron resultados";
                }
                return;
            }
            else if (idMarca != 0 && idCategoria != 0)
            {

                List<Articulo> listaFiltrada = lista.FindAll(x => x.MarcaArticulo.IDMarca == idMarca && x.CategoriaArticulo.IDCategoria == idCategoria);
                rptArticulos.DataSource = listaFiltrada;
                rptArticulos.DataBind();
                if (listaFiltrada.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron resultados";
                }
                return;
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            ddlCategorias.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
            rptArticulos.DataSource = (List<Articulo>)Session["articulos"];
            rptArticulos.DataBind();
            lblMensaje.Text = "";
        }

        protected void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkFiltrar.Checked)
            {
                Filtrado.Visible = true;
            }
            else
            {
                Filtrado.Visible = false;
                rptArticulos.DataSource = (List<Articulo>)Session["articulos"];
                rptArticulos.DataBind();
            }

        }
        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                string idArticulo = e.CommandArgument.ToString();
                Response.Redirect("VerDetalle.aspx?idArticulo=" + idArticulo, false);
            }
            else if (e.CommandName == "Agregar")
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
                //en este if verifica si el articulo ya esta en el carrito y si es asi aumenta la cantidad y el subtotal
                if (existe)
                {
                    ArticuloEnCarrito auxArticuloEnCarrito = articulosEnCarrito.Find(x => x.IDArticulo == id);
                    auxArticuloEnCarrito.Cantidad++;
                    auxArticuloEnCarrito.Subtotal = auxArticuloEnCarrito.Cantidad * auxArticuloEnCarrito.PrecioArticulo;
                    Session.Add("articulosEnCarrito", articulosEnCarrito);
                    Decimal subTotalEnSession = Convert.ToDecimal(Session["SubTotalArticulos"]);
                    Session["SubTotalArticulos"] = subTotalEnSession + auxArticuloEnCarrito.PrecioArticulo;


                    return;
                }
                else //si no esta en el carrito lo agrega
                {
                    ArticuloEnCarrito articuloEnCarrito = new ArticuloEnCarrito(auxArticuloId);
                    articulosEnCarrito.Add(articuloEnCarrito);
                    Session.Add("articulosEnCarrito", articulosEnCarrito);

                    Decimal auxSubtotal = articuloEnCarrito.Subtotal;
                    Decimal subTotalEnSession = Convert.ToDecimal(Session["SubTotalArticulos"]);
                    Session["SubTotalArticulos"] = subTotalEnSession + auxSubtotal;

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

                Decimal auxSubtotal = articuloEnCarrito.Subtotal;
                Session.Add("SubTotalArticulos", auxSubtotal);
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            List<Articulo> lista = (List<Articulo>)Session["articulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.NombreArticulo.ToUpper().Contains(busqueda.ToUpper()) || x.DescripcionArticulo.ToUpper().Contains(busqueda.ToUpper()) || x.MarcaArticulo.NombreMarca.Contains(busqueda.ToUpper()) || x.CategoriaArticulo.NombreCategoria.Contains(busqueda.ToUpper()));
            if (listaFiltrada.Count == 0)
            {
                lblMensaje.Text = "No se encontraron resultados";
            }
            else
            {
                rptArticulos.DataSource = listaFiltrada;

            }
            rptArticulos.DataBind();

        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            List<Articulo> lista = (List<Articulo>)Session["articulos"];
            rptArticulos.DataSource = lista;
            rptArticulos.DataBind();
            lblMensaje.Text = "";
        }
        public void cargarDropDowns()
        {
            Marca aux = new Marca();
            aux.IDMarca = 0;
            aux.NombreMarca = "Todas";
            marcas.Insert(0, aux);
            Categoria aux2 = new Categoria();
            aux2.IDCategoria = 0;
            aux2.NombreCategoria = "Todas";
            categorias.Insert(0, aux2);
            ddlCategorias.DataSource = categorias;
            ddlCategorias.DataTextField = "NombreCategoria";
            ddlCategorias.DataValueField = "IDCategoria";
            ddlCategorias.DataBind();
            ddlMarcas.DataSource = marcas;
            ddlMarcas.DataTextField = "NombreMarca";
            ddlMarcas.DataValueField = "IDMarca";
            ddlMarcas.DataBind();
        }
        
    }
}