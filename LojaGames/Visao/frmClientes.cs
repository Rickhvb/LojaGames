using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaGames.Modelo;
using System.IO;

namespace LojaGames.Visao
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaClientes.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbClientes.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaClientes.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbClientes.Enabled = true;
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            AtualizaGrid();
            controlaBotoes(true);
        }

        private void AtualizaGrid ()
        {
            try
            {
                dgvClientes.DataSource = clsCliente.recuperarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvClientes.DataSource = clsCliente.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvClientes.DataSource = clsCliente.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbClientes.Controls)
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
            if (validarDados() && verificaData() && (ValidarEmail(txtEmail.Text))
                && ValidarTelefone(txtTelefone.Text) && verificaCPF())
            {
                try
                {
                    clsCliente objCliente = new clsCliente();
                    objCliente.StrCPFCliente = txtCPF.Text;
                    objCliente.StrNomeCliente = txtNome.Text;
                    objCliente.StrTelefone = txtTelefone.Text;
                    objCliente.StrEmail = txtEmail.Text;
                    objCliente.StrNascimento = txtDatadeNascimento.Text;
                    objCliente.StrEndereco = txtEndereco.Text;
                    objCliente.StrNumero = txtNumero.Text;
                    objCliente.StrBairro = txtBairro.Text;
                    objCliente.StrCidade = txtCidade.Text;
                    objCliente.StrEstado = txtEstado.Text;

                    if ((String.IsNullOrEmpty(txtCodigo.Text)))
                    {
                        objCliente.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        objCliente.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                        objCliente.Alterar();
                        MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados do cliente não foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                this.Close();
            }
        }
                
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCPF.Text = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCodigo.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNome.Text = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDatadeNascimento.Text = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEndereco.Text = dgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNumero.Text = dgvClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBairro.Text = dgvClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCidade.Text = dgvClientes.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtEstado.Text = dgvClientes.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtEmail.Text = dgvClientes.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtTelefone.Text = dgvClientes.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(false);
            txtCPF.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            zeraDados();
            monthCalendar1.Visible = false;
            controlaBotoes(true);
        }

        private void zeraDados()
        {
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCPF.Text = "";
            txtDatadeNascimento.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtEstado.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtCodigo.Text = "";
            txtTelefone.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvClientes.Rows.Count > 0)
            {
                if (txtCPF.Text != "")
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvClientes.Rows.Count > 0)
            {
                if (txtCPF.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsCliente objCliente = new clsCliente();
                            objCliente.IntCodigo = Convert.ToInt32(txtCodigo.Text);
                            objCliente.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados do Cliente não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtDatadeNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
                MessageBox.Show("Data inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtDatadeNascimento.Focus();
            }
            if ((char.IsNumber(e.KeyChar) == true))
            {
                switch (txtDatadeNascimento.TextLength)
                {
                    case 0:
                        txtDatadeNascimento.Text = "";
                        break;
                    case 2:
                        txtDatadeNascimento.Text = txtDatadeNascimento.Text + "/";
                        txtDatadeNascimento.SelectionStart = 4;
                        break;
                    case 5:
                        txtDatadeNascimento.Text = txtDatadeNascimento.Text + "/";
                        txtDatadeNascimento.SelectionStart = 10;
                        break;
                }
            }  
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCPF.TextLength)
                {
                    case 0:
                        txtCPF.Text = "";
                        break;
                    case 1:
                        break;
                    case 3:
                        txtCPF.Text = txtCPF.Text + ".";
                        txtCPF.SelectionStart = 5;
                        break;
                    case 7:
                        txtCPF.Text = txtCPF.Text + ".";
                        txtCPF.SelectionStart = 9;
                        break;
                    case 11:
                        txtCPF.Text = txtCPF.Text + "-";
                        txtCPF.SelectionStart = 14;
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

        private Boolean verificaData()
        {
            if (txtDatadeNascimento.TextLength < 10 && txtDatadeNascimento.TextLength > 0 || txtDatadeNascimento.Text.Contains(" "))
            {
                MessageBox.Show("Data de Nascimento Inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errMsgErro.SetError(txtDatadeNascimento, "Data de Nascimento não preenchida corretamente\nFormato: dd/mm/aaaa");
                return false;
            }
            else
            {
                errMsgErro.SetError(txtDatadeNascimento, "");
                return true;                
            }
        }
           

        public static bool fgCpfCheck(string psCpf)//Verificador de CPF
        {
            string vsCpf = psCpf.Replace(".", "");
            vsCpf = vsCpf.Replace("-", "");

            if (vsCpf.Length != 11)
                return false;

            bool vbIgual = true;
            for (int i = 1; i < 11 && vbIgual; i++)
                if (vsCpf[i] != vsCpf[0])
                    vbIgual = false;

            if (vbIgual || vsCpf == "12345678909")
                return false;

            int[] vaNumeros = new int[11];

            for (int i = 0; i < 11; i++)
                vaNumeros[i] = int.Parse(
                vsCpf[i].ToString());

            int vnSoma = 0;
            for (int i = 0; i < 9; i++)
                vnSoma += (10 - i) * vaNumeros[i];

            int vnResultado = vnSoma % 11;

            if (vnResultado == 1 || vnResultado == 0)
            {
                if (vaNumeros[9] != 0)
                    return false;
            }
            else if (vaNumeros[9] != 11 - vnResultado)
                return false;

            vnSoma = 0;
            for (int i = 0; i < 10; i++)
                vnSoma += (11 - i) * vaNumeros[i];

            vnResultado = vnSoma % 11;

            if (vnResultado == 1 || vnResultado == 0)
            {
                if (vaNumeros[10] != 0)
                    return false;
            }
            else
                if (vaNumeros[10] != 11 - vnResultado)
                    return false;

            return true;
        }

        private Boolean verificaCPF()
        {
            if ((txtCPF.TextLength > 0) &&
                (fgCpfCheck(txtCPF.Text) == false))
            {
                MessageBox.Show("CPF Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtCPF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                verificaCPF();
            }
        }

        private void txtDatadeNascimento_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                verificaData();
                if (e.KeyCode == Keys.Tab)
                {
                    monthCalendar1.Visible = false;
                }
            }
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sfdExportaClientes.ShowDialog();
            if (!String.IsNullOrEmpty(sfdExportaClientes.FileName))
            {
                if (clsCliente.exportarTXT(sfdExportaClientes.FileName))
                {
                    MessageBox.Show(this, "Arquivo foi exportado com sucesso.\n" + sfdExportaClientes.FileName, "Confirmação");
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
            ofdImportaClientes.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaClientes.FileName))
            {
                if (clsCliente.importarTXT(ofdImportaClientes.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaClientes.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaClientes.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           txtDatadeNascimento.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void txtDatadeNascimento_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDatadeNascimento.Focused == true)
            {
                monthCalendar1.Visible = true;
            }
        }

        private void txtCPF_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtNome_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtEndereco_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtCidade_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtNumero_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtBairro_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtEstado_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtTelefone_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void btnSalvar_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void txtNome_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab )
            {
                monthCalendar1.Visible = true;
            }
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
