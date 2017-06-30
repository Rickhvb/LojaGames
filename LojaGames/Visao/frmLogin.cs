using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaGames.Modelo;
using LojaGames.ConexaoBD;

namespace LojaGames.Visao
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int login, correto;
            login = Convert.ToInt16(txtLogin.Text);
            frmVendas frmVendas = new frmVendas();
            DataTableReader Dados = new DataTableReader(clsFuncionario.recuperarSenha());
            bool logado = false;
            while (Dados.Read())   
            {
                correto = Convert.ToInt16(Dados.GetValue(0));
                if(  correto == login
                    && String.Compare( Dados.GetString(1) , Convert.ToString(txtSenha.Text) ) == 0 )
            {
                logado = true;
                frmVendas.Ok = Convert.ToInt32(txtLogin.Text);
                break;
            }
            }
            if (logado)
            {
                frmVendas.ShowDialog();
                this.Visible = false;
                
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválidos", "Erro ao Autenticar",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Focus();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnEntrar_Click(sender, e);
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnEntrar_Click(sender, e);
            }
        }

        

        private void btnEsqueceu_Click(object sender, EventArgs e)
        {
            frmEsqueceuSenha frmEsqueceuSenha = new frmEsqueceuSenha();
            frmEsqueceuSenha.ShowDialog();             
        }       
    }
}
