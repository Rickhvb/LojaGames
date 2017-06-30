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
    public partial class frmPagamentos : Form
    {
        public frmPagamentos()
        {
            InitializeComponent();
        }

        private void gpbPagamentos_Enter(object sender, EventArgs e)
        {

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //evento KeyPress você precisa evitar que letras sejam digitadas, fazer com que o 
            //ponto seja substituido por virgula e que exista apenas uma virgula na string, 
            //da seguinte forma:
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
                    if (!txtValorParcela.Text.Contains(','))
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

        private void txtValor_Leave(object sender, EventArgs e)
        {
            //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
            if (txtValorParcela.Text == "")
            {
                txtValorParcela.Text = "0.00";
                txtValorParcela.Focus();
            }
            txtValorParcela.Text = Convert.ToDouble(txtValorParcela.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
            //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
            //(ex.: 'R$') por causa da formatação que já existe nele: 
            String x = "";
            for (int i = 0; i <= txtValorParcela.Text.Length - 1; i++)
            {
                if ((txtValorParcela.Text[i] >= '0' &&
                    txtValorParcela.Text[i] <= '9') ||
                    txtValorParcela.Text[i] == ',')
                {
                    x += txtValorParcela.Text[i];
                }
            }
            txtValorParcela.Text = x;
            txtValorParcela.SelectAll();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
        }

        private void dgvPagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoPagamento.Text = dgvPagamentos.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCodigoVenda.Text = dgvPagamentos.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNome.Text = dgvPagamentos.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDataPagamento.Text = dgvPagamentos.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDataVenda.Text = dgvPagamentos.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtValorTotal.Text = dgvPagamentos.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtNumero.Text = dgvPagamentos.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtValorParcela.Text = dgvPagamentos.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtStatus.Text = dgvPagamentos.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void controlaBotoes(bool booLiberaBtNovo)
        {
            if (booLiberaBtNovo == true)
            {
                btnAtualiza.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaPagamentos.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbPagamentos.Enabled = false;

            }
            else
            {
                btnAtualiza.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaPagamentos.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbPagamentos.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text != "")
            {
                try
                {
                    clsPagamento objPagamento = new clsPagamento();
                    objPagamento.StrStatus = txtStatus.Text;
                    objPagamento.StrDataP = txtDataPagamento.Text;
                    objPagamento.IntPagamento = Convert.ToInt16(txtCodigoPagamento.Text);
                    objPagamento.Alterar();
                    MessageBox.Show("Status alterado com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    monthCalendar1.Visible = false;
                    controlaBotoes(true);
                    AtualizaGrid();
                    zeraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Status não atualizado. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Informe o status.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStatus.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            controlaBotoes(true);
            zeraDados();
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

        private void frmPagamentos_Load(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            zeraDados();
            controlaBotoes(true);
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            try
            {
                dgvPagamentos.DataSource = clsPagamento.recuperarTodos();
                dgvPagamentos.Columns[0].Visible = false;
                dgvPagamentos.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        private void zeraDados()
        {
            txtCodigoPagamento.Text = "";
            txtCodigoVenda.Text = "";
            txtConsulta.Text = "";
            txtCStatus.Text = "";
            txtDataPagamento.Text = "";
            txtStatus.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtValorParcela.Text = "";
        }


        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            if (this.dgvPagamentos.Rows.Count > 0)
            {
                if (txtCodigoPagamento.Text != "")
                {
                    monthCalendar1.Visible = true;
                    txtStatus.ReadOnly = false;
                    controlaBotoes(false);
                }
                else
                {
                    MessageBox.Show(this, "Selecione um pagamento para atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem pagamentos para atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            dgvPagamentos.DataSource = clsPagamento.recuperarTodosfiltro(txtConsulta.Text);
            dgvPagamentos.Columns[0].Visible = false;
            dgvPagamentos.Columns[1].Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDataPagamento.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        
        }

        private void txtCStatus_TextChanged(object sender, EventArgs e)
        {
            dgvPagamentos.DataSource = clsPagamento.recuperarTodosfiltroStatus(txtCStatus.Text);
            dgvPagamentos.Columns[0].Visible = false;
            dgvPagamentos.Columns[1].Visible = false;
        }
    }
}
