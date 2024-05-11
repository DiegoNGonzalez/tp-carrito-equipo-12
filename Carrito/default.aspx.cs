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
        private List<Articulo> articulos = new List<Articulo>();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.ListarArticulos();
            dgvArticulos.DataBind();
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
    }
}