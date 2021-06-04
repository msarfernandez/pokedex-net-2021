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
    public partial class CardsPokemons : System.Web.UI.Page
    {
        public List<Pokemon> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                lista = negocio.listar3();

                //Session.Add("nombre", "maxi");
                //Session["algo"] = "ñañañ";

                Session.Add("listadoPokemons", lista);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}