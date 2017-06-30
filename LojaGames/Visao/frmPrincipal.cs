using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace LojaGames.Visao
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()//construtor
        {
            InitializeComponent();
            this.Hide();
            Thread t = new Thread((new ThreadStart(ExibirSplash)));
            //inicializando a thread
            t.Start();
            //pedindo para o frmPrincipal "dormir" 3 segundos
            Thread.Sleep(3000);//3000
            //abortar (fechar) a thread t (frmSplash)
            t.Abort();
            this.Show();            
        }

        private void ExibirSplash()
        {
            frmSplash formSplash = new frmSplash();
            formSplash.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "GameSystem",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFornecedores frmFornecedores = new frmFornecedores();
            frmFornecedores.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFuncionarios frmFuncionarios = new frmFuncionarios();
            frmFuncionarios.ShowDialog();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProdutos frmProduto = new frmProdutos();
            frmProduto.ShowDialog();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.ShowDialog();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            /*frmVendas frmVendas = new frmVendas();
            frmVendas.ShowDialog();*/
        }

        private void pagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagamentos frmPagamentos = new frmPagamentos();
            frmPagamentos.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
                
        }

        private void dadosDeConexãoComBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracao frmConfiguracao = new frmConfiguracao();
            frmConfiguracao.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmSobre = new frmSobre();
            frmSobre.ShowDialog();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormaPagamentos frmFormaPagamentos = new frmFormaPagamentos();
            frmFormaPagamentos.ShowDialog();
        }

        private void alterarSenhaFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovaSenha frmNovaSenha = new frmNovaSenha();
            frmNovaSenha.ShowDialog();
        }

        private void controleDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque frmEstoque = new frmEstoque();
            frmEstoque.ShowDialog();
        }

        private void produtosCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio objRel = new frmRelatorio();
            objRel.ShowDialog();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
