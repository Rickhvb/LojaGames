using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaGames.Modelo;

namespace LojaGames.Visao
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }


        private int ok = 0;

        public int Ok
        {
            get { return ok; }
            set { ok = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ok = 0;
            this.Close();
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {
            frmFuncionarios ObjFuncionarios = new frmFuncionarios();
            string admin = "admin";
            string senha = "admin";
            if (txtUsuario.Text == admin && txtSenha.Text == senha)
            {
                this.Visible = false;
                this.Close();
                ok = 1;
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Erro ao autenticar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtSenha.Text = "";
                txtUsuario.Text = "";
                txtUsuario.Focus();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnOK_Click(sender, e);
            }
        }
    }
}
