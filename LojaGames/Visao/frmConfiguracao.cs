using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaGames.Util;
using LojaGames.ConexaoBD;

namespace LojaGames.Visao
{
    public partial class frmConfiguracao : Form
    {
        public frmConfiguracao()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool SalvarDados()
        {
            try
            {
                Registro objReg = new Registro();
                objReg.setValor("Servidor", txtServidor.Text);
                objReg.setValor("Porta", txtPorta.Text);
                objReg.setValor("Usuario", txtUsuario.Text);
                objReg.setValor("Senha", txtSenha.Text);
                objReg.setValor("Banco", txtBanco.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        

        private void frmConfiguracao_Load(object sender, EventArgs e)
        {

        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            string strMsg = "";
            SalvarDados();
            BancoOracle.GetInstancia().desconectar();
            if (BancoOracle.GetInstancia().TestaConexao())
            {
                strMsg = "Conexão estabelecida com sucesso!";
            }
            else
            {
                strMsg = "Conexão NÃO estabelecida com sucesso!\n" + BancoOracle.GetInstancia().GetErro();
            }

            MessageBox.Show(strMsg);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (SalvarDados())
            {
                MessageBox.Show("Dados de conexão com o banco de dados foram salvos!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
       
}
