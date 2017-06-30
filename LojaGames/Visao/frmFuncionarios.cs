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
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            controlaBotoes(true);
            dgvFuncionarios.Columns[1].Visible = false;
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvFuncionarios.DataSource = clsFuncionario.recuperarTodos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
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

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaFuncionarios.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbFuncionarios.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaFuncionarios.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbFuncionarios.Enabled = true;
            }
        }

        private bool validarDados()
        {
            string strMensagem = "";
            foreach (Control c in gpbFuncionarios.Controls)
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
            if (validarDados() && verificaSenha() && verificaCPF())
            {
                try
                {
                    clsFuncionario objFuncionario = new clsFuncionario();
                    objFuncionario.StrEndereco = txtEndereco.Text;
                    objFuncionario.StrSenha = txtSenha.Text;
                    objFuncionario.StrNumero = txtNumero.Text;
                    objFuncionario.StrBairro = txtBairro.Text;
                    objFuncionario.StrCidade = txtCidade.Text;
                    objFuncionario.StrEstado = txtEstado.Text;
                    objFuncionario.StrCPF = txtCPF.Text;
                    objFuncionario.StrNome = txtNome.Text;

                    if (txtCodigo.Text == "")
                    {
                        objFuncionario.Salvar();
                        MessageBox.Show("Dados salvos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        DataTableReader Dados = new DataTableReader(clsFuncionario.recuperarSenha());
                        bool logado = false;
                        int login, correto;
                        login = Convert.ToInt16(txtCodigo.Text);
                        while (Dados.Read())
                        {
                            correto = Convert.ToInt16(Dados.GetValue(0));
                            if (correto == login
                                && String.Compare(Dados.GetString(1), Convert.ToString(txtSenha.Text)) == 0)
                            {
                                logado = true;
                                break;
                            }
                        }
                        if (logado)
                        {
                            objFuncionario.IntCodigo = Convert.ToInt16(txtCodigo.Text);
                            objFuncionario.Alterar();
                            MessageBox.Show("Dados alterados com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Senha Inválida", "Erro ao Autenticar",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSenha.Text = "";
                            txtSenha2.Text = "";
                            txtSenha.Focus();
                        }
                    }

                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dados do Funcionario não foram salvos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCPF.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNome.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEndereco.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNumero.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBairro.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCidade.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtEstado.Text = dgvFuncionarios.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraDados();
            controlaBotoes(false);
            txtSenha.Focus();
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
            txtCodigo.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtSenha.Text = "";
            txtSenha2.Text = "";
            txtNome.Text = "";
            txtEstado.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.dgvFuncionarios.Rows.Count > 0)
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


        public void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvFuncionarios.Rows.Count > 0)
            {
                if (txtCodigo.Text != "")
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.ShowDialog();
                    if ( frmAdmin.Ok == 1 )
                    {
                    DialogResult result = MessageBox.Show("Confirma a exclusão dos dados selecionados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsFuncionario objFuncionario = new clsFuncionario();
                            objFuncionario.IntCodigo = Convert.ToInt16(txtCodigo.Text);
                            objFuncionario.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Dados excluídos com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dados do Funcionario não foram excluídos. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        zeraDados();
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

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCPF.TextLength)
                {
                    case 0:
                        txtCPF.Text = "";
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

        private Boolean verificaSenha()
        {
            string strMensagem = "";
            if (txtSenha.Text != txtSenha2.Text)
            {
                strMensagem = strMensagem + "As senhas devem ser iguais.";
            }

            if (txtSenha.Text.Length < 6)
            {
                strMensagem = strMensagem + "A senha deve conter mais de 5 caracteres.";
            }
            if (strMensagem != "")
            {
                MessageBox.Show(strMensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = clsFuncionario.recuperarTodosFiltro(txtConsulta.Text);
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvFuncionarios.DataSource = clsFuncionario.recuperarTodosFiltro(txtConsulta.Text);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.ShowDialog();
                    if (frmAdmin.Ok == 1)
                    {
                        sfdExportaFuncionarios.ShowDialog();
                        if (!String.IsNullOrEmpty(sfdExportaFuncionarios.FileName))
                        {
                            if (clsFuncionario.exportarTXT(sfdExportaFuncionarios.FileName))
                            {
                                MessageBox.Show(this, "Arquivo foi exportado com sucesso.\n" + sfdExportaFuncionarios.FileName, "Confirmação");
                            }
                            else
                            {
                                MessageBox.Show(this, "Arquivo não foi exportado com sucesso.", "Atenção");
                            }
                        }
                        AtualizaGrid();
                    }
                    else
                    {
                        zeraDados();
                    }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ofdImportaFuncionarios.ShowDialog();
            if (!String.IsNullOrEmpty(ofdImportaFuncionarios.FileName))
            {
                if (clsFuncionario.importarTXT(ofdImportaFuncionarios.FileName))
                {
                    MessageBox.Show(this, "Importacao realizada com sucesso. \n" + ofdImportaFuncionarios.FileName, "Confirmação");
                }
                else
                {
                    MessageBox.Show(this, "Ocorreu um erro durante a importação do arquivo. \n" + ofdImportaFuncionarios.FileName, "Atenção");
                }
            }
            AtualizaGrid();
        }

        private void sfdExportaFuncionarios_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ofdImportaFuncionarios_FileOk(object sender, CancelEventArgs e)
        {

        }   
    }
}
