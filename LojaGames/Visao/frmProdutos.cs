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
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            zeraDados();
            AtualizaComboBox();
            controlaBotoes(true);
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

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaProdutos.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbProdutos.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaProdutos.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbProdutos.Enabled = true;
            }
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
            if (cmbCategoria.Text == "")
            {
                strMensagem = "Categoria não informada.";
            }
            if (cmbFornecedor.Text == "")
            {
                strMensagem = "Fornecedor não informado.";
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarDados())
            {

                try
                {
                    clsProduto objProduto = new clsProduto();
                    objProduto.IntCodCat = Convert.ToInt32(cmbCategoria.SelectedValue.ToString());
                    objProduto.IntCodForn = Convert.ToInt32(cmbFornecedor.SelectedValue.ToString());
                    objProduto.StrNome = txtNome.Text;
                    objProduto.StrMarca = txtMarca.Text;
                    objProduto.StrValor = txtValor.Text;
                    objProduto.StrDescricao = txtDescricao.Text;
                    
                    if (txtCodigo.Text == "")
                    {
                        objProduto.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objProduto.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                        objProduto.Alterar();
                        MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados do cliente não foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvProduto.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNome.Text = dgvProduto.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbCategoria.Text = dgvProduto.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbFornecedor.Text = dgvProduto.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMarca.Text = dgvProduto.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtValor.Text = dgvProduto.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDescricao.Text = dgvProduto.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text == "")
            {
                txtValor.Text = "0.00";
                txtValor.Focus();
            }
            txtValor.Text = Convert.ToDouble(txtValor.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
        }

        //evento KeyPress você precisa evitar que letras sejam digitadas, fazer com que o 
        //ponto seja substituido por virgula e que exista apenas uma virgula na string, 
        //da seguinte forma:
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8) && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!txtValor.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
        //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
        //(ex.: 'R$') por causa da formatação que já existe nele: 
        private void txtValor_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= txtValor.Text.Length - 1; i++)
            {
                if ((txtValor.Text[i] >= '0' &&
                    txtValor.Text[i] <= '9') ||
                    txtValor.Text[i] == ',')
                {
                    x += txtValor.Text[i];
                }
            }
            txtValor.Text = x;
            txtValor.SelectAll();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(false);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvProduto.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    controlaBotoes(false);
                }
                else
                {
                    MessageBox.Show(this, "Selecione um registro para alterar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem dados registrados para alterar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void zeraDados()
        {
            txtCodigo.Text = "";
            cmbCategoria.Text = null;
            txtNome.Text = "";
            txtMarca.Text = "";
            txtValor.Text = "";
            txtDescricao.Text = "";
            cmbFornecedor.Text = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(true);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvProduto.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsProduto objProduto = new clsProduto();
                            objProduto.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                            objProduto.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados do Produto não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        zeraDados();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Selecione um registro para excluir", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem dados registrados para excluir", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvProduto.DataSource = clsProduto.recuperarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }


        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvProduto.DataSource = clsProduto.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvProduto.DataSource = clsProduto.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sfdExportaProdutos.ShowDialog();
            if (!String.IsNullOrEmpty(sfdExportaProdutos.FileName))
            {
                if (clsProduto.exportarTXT(sfdExportaProdutos.FileName))
                {
                    MessageBox.Show("Arquivo foi exportado com sucesso.\n" + sfdExportaProdutos.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show("Arquivo não foi exportado com sucesso.", "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ofdImportaProdutos.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaProdutos.FileName))
            {
                if (clsProduto.importarTXT(ofdImportaProdutos.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaProdutos.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaProdutos.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void AtualizaComboBox()
        {
            cmbCategoria.DataSource = clsCategoria.recuperarTodos();
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "Codigo";

            cmbFornecedor.DataSource = clsFornecedor.recuperarTodos();
            cmbFornecedor.DisplayMember = "NOME";
            cmbFornecedor.ValueMember = "Codigo";
        }
    }
}
