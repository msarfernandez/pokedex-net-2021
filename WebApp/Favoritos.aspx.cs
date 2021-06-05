using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace WebApp
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Pokemon> favoritos;
        protected void Page_Load(object sender, EventArgs e)
        {
            favoritos = (List<Pokemon>)Session["listaFavoritos"];
            if (favoritos == null)
                favoritos = new List<Pokemon>();

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if(favoritos.Find(x => x.Id.ToString() == Request.QueryString["id"]) == null){
                        List<Pokemon> listadoOriginal = (List<Pokemon>)Session["listadoPokemons"];
                        favoritos.Add(listadoOriginal.Find(x => x.Id.ToString() == Request.QueryString["id"]));
                    }
                }

                //Repeater
                repetidor.DataSource = favoritos;
                repetidor.DataBind();
            }

            Session.Add("listaFavoritos", favoritos);

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
        }

        protected void btnEliminar2_Click(object sender, EventArgs e)
        {
            var argument = ((Button)sender).CommandArgument;
            List<Pokemon> favoritos = (List<Pokemon>)Session["listaFavoritos"];
            Pokemon elim = favoritos.Find(x => x.Id.ToString() == argument);
            favoritos.Remove(elim);
            Session.Add("listaFavoritos", favoritos);
            repetidor.DataSource = null;
            repetidor.DataSource = favoritos;
            repetidor.DataBind();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            lblEjemplo.Text = "El valor es: " + ((TextBox)sender).Text;
        }

        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argument = ((DropDownList)sender);
            lblDesplegable.Text = "El DDL tiene " + ((DropDownList)sender).Text + " y el ID del POKE es: " + argument;
        }
    }
}