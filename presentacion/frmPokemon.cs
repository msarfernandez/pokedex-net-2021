using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmPokemon : Form
    {
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPokemon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("De verad querés salir? Perderás los datos", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            Dispose();
        }

        private void frmPokemon_Load(object sender, EventArgs e)
        {

        }
    }
}
