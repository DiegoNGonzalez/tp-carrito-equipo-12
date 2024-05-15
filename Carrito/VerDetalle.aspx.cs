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

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        imgArticulo.ImageUrl = articulo.Imagenes[0].URLImagen;
                    }
                    else
                    {
                        imgArticulo.ImageUrl = "~/Images/imagen_por_defecto.jpg"; 
                    }
                }
            }
        }
                    protected void btnAgregar_Click(object sender, EventArgs e)
                    {
                        //contadorCarrito.Text = (Convert.ToInt32(contadorCarrito.Text) + 1).ToString();
                    }
                }
            }