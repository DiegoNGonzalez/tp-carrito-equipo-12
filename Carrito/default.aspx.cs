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
        public Label contadorCarrito= new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio();
            articulos = negocio.ListarArticulos();
            CargarGrid();
            contadorCarrito= (Label)Master.FindControl("contadorCarrito");
        }

        private void CargarGrid()
        {
            try
            {
                articulos = negocio.ListarArticulos();
                if (articulos.Count == 0)
                {
                    dgvArticulos.DataSource = null;
                    //pBoxArticulosFormArticulos.Load("https://i0.wp.com/static.vecteezy.com/system/resources/previews/005/337/799/original/icon-image-not-found-free-vector.jpg?ssl=1");
                }
                else
                {
                    dgvArticulos.DataSource = articulos;
                    dgvArticulos.DataBind();
                    Session.Add("listaArticulos", articulos);
                    //dgvArticulos.Columns["IdArticulo"].Visible = false;
                    //dgvArticulos.Columns["DescripcionArticulo"].Visible = false;
                    //dgvArticulos.Columns["CategoriaArticulo"].Visible = false;
                    //dgvArticulos.Columns["PrecioArticulo"].DataGridView.Columns["PrecioArticulo"].DefaultCellStyle.Format = "$0.00";
                    //pBoxArticulosFormArticulos.Load(listaArticulos[0].Imagenes[0].URLImagen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            contadorCarrito.Text = (Convert.ToInt32(contadorCarrito.Text) + 1).ToString();
        }
    }
}