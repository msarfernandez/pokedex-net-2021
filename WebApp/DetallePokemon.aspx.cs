using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace WebApp
{
    public partial class DetallePokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            List<Pokemon> listado = (List<Pokemon>)Session["listadoPokemons"];
            Pokemon seleccionado = listado.Find(x => x.Id == id);
            

            lblSeleccionado.Text = seleccionado.Nombre;
            lblUrlImagen.Text = seleccionado.UrlImagen;
        }
    }
}