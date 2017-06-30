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
using System.IO;

namespace LojaGames.Visao
{
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            controlaBotoes(true);
            VerificaNovoOuAtualiza.Visible = false;
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            try
            {
                dgvProdutos.DataSource = clsEstoque.recuperarTodos();
                dgvProdutos.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void gpbCategorias_Enter(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controlaBotoes(true);
            zeraDados();
        }

        private void zeraDados()
        {
            txtCodigo.Text = "";
            txtConsulta.Text = "";
            txtNomeProduto.Text = "";
            nudQtde.Value = 0;
            VerificaNovoOuAtualiza.Text = "";
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbProdutos.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "" && c.Tag.ToString() != "n")
                    {
                        strMensagem = strMensagem + "O campo " + c.Tag.ToString() + " não foi inserido corretamente.\n";
                    }
                }
            }
            if (strMensagem == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(strMensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnAtualiza.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaProdutos.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbProdutos.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAtualiza.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaProdutos.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbProdutos.Enabled = true;
            }
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            if (this.dgvProdutos.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    controlaBotoes(false);
                }
                else
                {
                    MessageBox.Show("Selecione um registro para alterar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem dados registrados para alterar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RecuperarInfoProduto(txtCodigo.Text);
                plnProduto.Visible = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                txtNomeProduto.Text = "";
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            plnProduto.Location = new Point(124, 95);
            plnProduto.Visible = true;
            AtualizaListaProdutos();
        }

        private void AtualizaListaProdutos()
        {
            dgvProdutoConsulta.DataSource = clsProduto.recuperarTodos();
            dgvProdutoConsulta.Columns[2].Visible = false;
            dgvProdutoConsulta.Columns[3].Visible = false;
            dgvProdutoConsulta.Columns[4].Visible = false;
            dgvProdutoConsulta.Columns[5].Visible = false;
            dgvProdutoConsulta.Columns[6].Visible = false;
        }

        private void btnSairGrid_Click(object sender, EventArgs e)
        {
            plnProduto.Visible = false;
        }

        private void txtConsCliente_TextChanged(object sender, EventArgs e)
        {
            dgvProdutoConsulta.DataSource = clsProduto.recuperarTodosFiltro(txtConsProduto.Text);
            dgvProdutoConsulta.Columns[2].Visible = false;
            dgvProdutoConsulta.Columns[3].Visible = false;
            dgvProdutoConsulta.Columns[4].Visible = false;
            dgvProdutoConsulta.Columns[5].Visible = false;
            dgvProdutoConsulta.Columns[6].Visible = false;
        }

        private void RecuperarInfoProduto(string codigoNaoVerificado)
        {
            try
            {
                int codigo = Convert.ToInt16(codigoNaoVerificado);
                DataTable dtApoio = clsProduto.recuperarCodigo(codigo);
                if (dtApoio.Rows.Count > 0)
                {
                    txtCodigo.Text = codigoNaoVerificado;
                    txtNomeProduto.Text = dtApoio.Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("Código do Produto inválido", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                }

            }
            catch (Exception)
            {
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarDados())
            {
                try
                {
                    clsEstoque objEstoque = new clsEstoque();
                    objEstoque.IntCodProduto = Convert.ToInt16(txtCodigo.Text);
                    objEstoque.IntQtde = Convert.ToInt16(nudQtde.Value);
                    if (VerificaNovoOuAtualiza.Text == "")
                    {
                        objEstoque.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objEstoque.Alterar();
                        MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    controlaBotoes(true);
                    atualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados da Categoria nao foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            controlaBotoes(false);
            txtCodigo.Focus();
            zeraDados();
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = clsEstoque.recuperarTodosFiltro(txtConsulta.Text);
            dgvProdutos.Columns[3].Visible = false;

        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNomeProduto.Text = dgvProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudQtde.Value = Convert.ToInt16(dgvProdutos.Rows[e.RowIndex].Cells[2].Value.ToString());
                VerificaNovoOuAtualiza.Text = dgvProdutos.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void dgvProdutoConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecuperarInfoProduto(dgvProdutoConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                plnProduto.Visible = false;
            }
        }
    }
}
