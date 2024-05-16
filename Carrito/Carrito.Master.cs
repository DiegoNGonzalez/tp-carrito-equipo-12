using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contadorCarrito.Text = Session["ContadorArticulos"] != null ? Session["ContadorArticulos"].ToString() : "0";
        }
    }
}