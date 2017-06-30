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
    public partial class frmFormaPagamentos : Form
    {
        public frmFormaPagamentos()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmFormaPagamentos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            controlaBotoes(true);
        }

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSair.Enabled = true;
                gpbRecFormPag.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbFormaPagamento.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecFormPag.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbFormaPagamento.Enabled = true;
            }
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbFormaPagamento.Controls)
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            controlaBotoes(false);
            txtNome.Focus();
            zeraDados();
        }

        private void zeraDados()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controlaBotoes(true);
            zeraDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvFormPag.Rows.Count > 0)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvFormPag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvFormPag.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNome.Text = dgvFormPag.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvFormPag.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsFormaPagamento objFormaPagamento = new clsFormaPagamento();
                            objFormaPagamento.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                            objFormaPagamento.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados da Forma de Pagamento não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarDados())
            {
                try
                {
                    clsFormaPagamento objFormaPagamento = new clsFormaPagamento();
                    //objCategoria.IntCodigo = Convert.ToInt16(txtCodigo.Text);
                    objFormaPagamento.StrNome = txtNome.Text;
                    if (txtCodigo.Text == "")
                    {
                        objFormaPagamento.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objFormaPagamento.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                        objFormaPagamento.Alterar();
                        MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados da Forma de Pagamento não foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvFormPag.DataSource = clsFormaPagamento.recuperarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvFormPag.DataSource = clsFormaPagamento.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvFormPag.DataSource = clsFormaPagamento.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sfdExportaFormaPagamentos.ShowDialog();
            if (!String.IsNullOrEmpty(sfdExportaFormaPagamentos.FileName))
            {
                if (clsFormaPagamento.exportarTXT(sfdExportaFormaPagamentos.FileName))
                {
                    MessageBox.Show(this, "Arquivo foi exportado com sucesso.\n" + sfdExportaFormaPagamentos.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Arquivo não foi exportado com sucesso.", "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ofdImportaFormaPagamentos.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaFormaPagamentos.FileName))
            {
                if (clsFormaPagamento.importarTXT(ofdImportaFormaPagamentos.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaFormaPagamentos.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaFormaPagamentos.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }
     }
}
