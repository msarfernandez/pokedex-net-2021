using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace presentacion
{
    public partial class frmPokemon : Form
    {
        private Pokemon pokemon = null;
        public frmPokemon()
        {
            InitializeComponent();
        }
        public frmPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPokemon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("De verad querés salir? Perderás los datos", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            //    return;

            //Dispose();
        }

        private void frmPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Nombre";

                if(pokemon != null)
                {
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    RecargarImg(txtUrlImagen.Text);
                    numNumero.Value = pokemon.Numero;
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Pokemon nuevo = new Pokemon();
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.Numero = (int)numNumero.Value;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;

                if(pokemon.Id == 0)
                {
                    pokemonNegocio.agregar(pokemon);
                    MessageBox.Show("agregado sin problema");
                }
                else
                {
                    pokemonNegocio.modificar(pokemon);
                    MessageBox.Show("modificado sin problema");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RecargarImg(string img)
        {
            try
            {
                pbxPokemon.Load(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show("URL Imagen Inválida");
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            RecargarImg(txtUrlImagen.Text);
        }
    }
}
