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
    public partial class frmNovaSenha : Form
    {
        public frmNovaSenha()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsFuncionario objFuncionario = new clsFuncionario();
            DataTableReader Dados = new DataTableReader(clsFuncionario.recuperarSenha());
            bool logado = false;
            while (Dados.Read())
            {
                if (String.Compare(txtCodigo.Text, Dados.GetString(0)) == 0 && String.Compare(txtSenhaAntiga.Text, Dados.GetString(1)) == 0)
                {
                    logado = true;
                    break;
                }
            }
            if (logado)
            {
                if ((txtNovaSenha.Text == txtConfirma.Text) && (txtNovaSenha.Text.Length >= 6))
                {
                    objFuncionario.IntCodigo = Convert.ToInt16(txtCodigo.Text);
                    objFuncionario.StrSenha = txtNovaSenha.Text;
                    objFuncionario.AlterarSenha();
                    MessageBox.Show("Senha alterada com sucesso.", "Confirmação",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else if (txtNovaSenha.Text != txtConfirma.Text)
                {
                    MessageBox.Show("Senhas devem ser iguais.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNovaSenha.Text = "";
                    txtConfirma.Text = "";
                    txtNovaSenha.Focus();
                }
                else
                {
                    MessageBox.Show("Senha deve possuir mais de 5 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNovaSenha.Text = "";
                    txtConfirma.Text = "";
                    txtNovaSenha.Focus();
                }
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválidos.","Erro.",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtNovaSenha.Text = "";
                txtConfirma.Text = "";
                txtCodigo.Text = "";
                txtSenhaAntiga.Text = "";
                txtCodigo.Focus();
            }
        }

        private void txtConfirma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnOK_Click(sender, e);
            }
        }
    }
}
