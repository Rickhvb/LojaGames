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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmCategorias_Load(object sender, EventArgs e)
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
                gpbRecuperaCategorias.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbCategorias.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaCategorias.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbCategorias.Enabled = true;
            }
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbCategorias.Controls)
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
                MessageBox.Show(strMensagem,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarDados())
            {
                try
                {
                    clsCategoria objCategoria = new clsCategoria();
                    //objCategoria.IntCodigo = Convert.ToInt16(txtCodigo.Text);
                    objCategoria.StrNome = txtNome.Text;
                    if (txtCodigo.Text == "")
                    {
                        objCategoria.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objCategoria.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                        objCategoria.Alterar();
                        MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    
                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados da Categoria nao foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvCategorias.DataSource = clsCategoria.recuperarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controlaBotoes(true);
            zeraDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvCategorias.Rows.Count > 0)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvCategorias.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsCategoria objCategoria = new clsCategoria();
                            objCategoria.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                            objCategoria.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados da Categoria não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNome.Text = dgvCategorias.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = clsCategoria.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvCategorias.DataSource = clsCategoria.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sfdExportaCategorias.ShowDialog();
            if (!String.IsNullOrEmpty(sfdExportaCategorias.FileName))
            {
                if (clsCategoria.exportarTXT(sfdExportaCategorias.FileName))
                {
                    MessageBox.Show(this, "Arquivo foi exportado com sucesso.\n" + sfdExportaCategorias.FileName, "Confirmação");
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
            ofdImportaCategorias.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaCategorias.FileName))
            {
                if (clsCategoria.importarTXT(ofdImportaCategorias.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaCategorias.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaCategorias.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void ofdImportaCategorias_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
