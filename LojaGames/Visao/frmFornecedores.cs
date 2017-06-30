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
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }

        private void frmFornecedores_Load(object sender, EventArgs e)
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
                gpbRecuperaFornecedores.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbFornecedores.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaFornecedores.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbFornecedores.Enabled = true;
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

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvFornecedores.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCNPJ.Text = dgvFornecedores.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNome.Text = dgvFornecedores.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRazaoSocial.Text = dgvFornecedores.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEndereco.Text = dgvFornecedores.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNumero.Text = dgvFornecedores.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBairro.Text = dgvFornecedores.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCidade.Text = dgvFornecedores.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtEstado.Text = dgvFornecedores.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtTelefone.Text = dgvFornecedores.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtEmail.Text = dgvFornecedores.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbFornecedores.Controls)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarDados() && ValidarTelefone(txtTelefone.Text)
                && ValidarEmail(txtEmail.Text) && verificaCNPJ())
            {
                try
                {
                    clsFornecedor objFornecedor = new clsFornecedor();
                    objFornecedor.StrCNPJ = txtCNPJ.Text;
                    objFornecedor.StrNome = txtNome.Text;
                    objFornecedor.StrRazaoSocial = txtRazaoSocial.Text;
                    objFornecedor.StrEndereco = txtEndereco.Text;
                    objFornecedor.StrNumero = txtNumero.Text;
                    objFornecedor.StrBairro = txtBairro.Text;
                    objFornecedor.StrCidade = txtCidade.Text;
                    objFornecedor.StrEstado = txtEstado.Text;
                    objFornecedor.StrTelefone = txtTelefone.Text;
                    objFornecedor.StrEmail = txtEmail.Text;

                    if (txtCodigo.Text == "")
                    {
                        objFornecedor.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objFornecedor.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                        objFornecedor.Alterar();
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
                dgvFornecedores.DataSource = clsFornecedor.recuperarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(false);
            txtCNPJ.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(true);
        }

        private void zeraDados()
        {
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCNPJ.Text = "";
            txtCodigo.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtEstado.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtRazaoSocial.Text = "";
            txtTelefone.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvFornecedores.Rows.Count > 0)
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
            if (this.dgvFornecedores.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsFornecedor objFornecedor = new clsFornecedor();
                            objFornecedor.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                            objFornecedor.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados do Fornecedor não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
            if ((char.IsNumber(e.KeyChar) == true))// || e.KeyChar == (Char)8)
            {
                switch (txtCNPJ.TextLength)
                {
                    case 0:
                        txtCNPJ.Text = "";
                        break;
                    case 2:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 4;
                        break;
                    case 6:
                        txtCNPJ.Text = txtCNPJ.Text + ".";
                        txtCNPJ.SelectionStart = 8;
                        break;
                    case 10:
                        txtCNPJ.Text = txtCNPJ.Text + "/";
                        txtCNPJ.SelectionStart = 12;
                        break;
                    case 15:
                        txtCNPJ.Text = txtCNPJ.Text + "-";
                        txtCNPJ.SelectionStart = 17;
                        break;
                }
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            string txt = "(";
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
            if ((char.IsNumber(e.KeyChar) == true))
            {
                switch (txtTelefone.TextLength)
                {
                    case 0:
                        txtTelefone.Text = "";
                        break;
                    case 2:
                        txtTelefone.Text = txt + txtTelefone.Text + ")";
                        txtTelefone.SelectionStart = 15;
                        break;
                }
            }
        }

        public static bool fgCnpjCheck(string psCnpj) //-- Validação de CNPJ. 66.281.674/0001-10
        {
            string vsCnpj = psCnpj.Replace(".", "");
            vsCnpj = vsCnpj.Replace("/", "");
            vsCnpj = vsCnpj.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] vbCnpjOK;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            vbCnpjOK = new bool[2];
            vbCnpjOK[0] = false;
            vbCnpjOK[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                    vsCnpj.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(
                        nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(
                        nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                    resultado[nrDig] == 1))
                        vbCnpjOK[nrDig] = (
                        digitos[12 + nrDig] == 0);
                    else
                        vbCnpjOK[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (vbCnpjOK[0] && vbCnpjOK[1]);
            }
            catch
            {
                return false;
            }
        }

        private Boolean verificaCNPJ()
        {
            if ((txtCNPJ.TextLength > 0) && 
                (fgCnpjCheck(txtCNPJ.Text) == false))
            {
                MessageBox.Show(this,"CNPJ Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtCNPJ_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                verificaCNPJ();
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvFornecedores.DataSource = clsFornecedor.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = clsFornecedor.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sfdExportaFornecedores.ShowDialog();
            if (!String.IsNullOrEmpty(sfdExportaFornecedores.FileName))
            {
                if (clsFornecedor.exportarTXT(sfdExportaFornecedores.FileName))
                {
                    MessageBox.Show(this, "Arquivo foi exportado com sucesso.\n" + sfdExportaFornecedores.FileName, "Confirmação");
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
            ofdImportaFornecedores.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaFornecedores.FileName))
            {
                if (clsFornecedor.importarTXT(ofdImportaFornecedores.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaFornecedores.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaFornecedores.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }

        /*private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("E-mail com formato incorreto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                MessageBox.Show("E-mail com formato incorreto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /*private void txtTelefone_Leave(object sender, EventArgs e)
        {
            if (ValidarTelefone(txtTelefone.Text) == false)
            {
                MessageBox.Show("Telefone com formato incorreto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        public static bool ValidarTelefone(string telefone)
        {
            if (telefone.Length >= 12)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Telefone com formato incorreto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

    }
}
