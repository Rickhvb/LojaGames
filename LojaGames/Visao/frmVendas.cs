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
using LojaGames.ConexaoBD;

namespace LojaGames.Visao
{
    public partial class frmVendas : Form
    {
        public frmVendas()
        {
            InitializeComponent();//Inicializa o componente
        }
        
        //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
        private void txtValor_Leave(object sender, EventArgs e)
        {
            {
                if (txtValor.Text == "")
                {
                    txtValor.Text = "0";
                }
                txtValor.Text = Convert.ToDouble(txtValor.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
            }
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

        private void txtValor_Enter(object sender, EventArgs e)
        {
            //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
            //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
            //(ex.: 'R$') por causa da formatação que já existe nele: 
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
        
        private void txtData_KeyPress(object sender, KeyPressEventArgs e) //Formata o campo Data 'dd/mm/aaaa'
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
                MessageBox.Show("Data inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtData.Text = "";
                txtData.Focus();
            }
            if ((char.IsNumber(e.KeyChar) == true))
            {
                switch (txtData.TextLength)
                {
                    case 0:
                        txtData.Text = "";
                        break;
                    case 1:
                        if ((Convert.ToInt16(txtData.Text) > 3))
                        {
                            MessageBox.Show("Data inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtData.Text = "";
                            txtData.Focus();
                        }
                        break;
                    case 2:
                        txtData.Text = txtData.Text + "/";
                        txtData.SelectionStart = 4;
                        break;
                    case 5:
                        txtData.Text = txtData.Text + "/";
                        txtData.SelectionStart = 10;
                        break;
                }
            }

        }

        /*private void txtData_Validating(object sender, CancelEventArgs e) //Valida se a data foi preenchida corretamente
        {
            if (txtData.TextLength < 10 && txtData.TextLength > 0)
            {
                MessageBox.Show("Data Inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //btnSalvar.Enabled = false;
            }
            else
            {
                if ((txtCPF.TextLength > 0) && (fgCpfCheck(txtCPF.Text) == true))
                {
                    btnSalvar.Enabled = true;
                }
                else
                {
                    btnSalvar.Enabled = false;
                }
            }

            if (((txtData.Text.Contains(" ")) || (txtData.Text.Length != 10)) && (txtData.Text != ""))
            {
                errMsgErro.SetError(txtData, "Data da Compra não preenchida corretamente\nFormato: dd/mm/aaaa");
            }
            else
            {
                errMsgErro.SetError(txtData, "");
            }
        }*/

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e) //Nome recebe apenas letras
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

       /* public static bool fgCpfCheck(string psCpf)//Verificador de CPF
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

        /*private void txtCPF_Validating(object sender, CancelEventArgs e) //Verifica o CPF
        {
            if ((txtCPF.TextLength > 0) &&
                (fgCpfCheck(txtCPF.Text) == false))
            {
                MessageBox.Show("CPF Inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSalvar.Enabled = false;
            }
            else
            {
                if (txtData.TextLength == 10 || txtData.TextLength == 0)
                {
                    btnSalvar.Enabled = true;
                }
                else
                {
                    btnSalvar.Enabled = false;
                }
            }
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

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e) //Formata o CPF para 111.111.111-11
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
        }*/

        private void controlaBotoes(bool booLiberaBtNovo) //Controla botoes salvar, excluir, etc
        {
            if (booLiberaBtNovo == true)
            {
                btnNovo.Enabled = true;
                btnExcluir.Enabled = true;
                btnSair.Enabled = true;
                gpbRecuperaVendas.Enabled = true;

                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                gpbVendas.Enabled = false;

            }
            else
            {
                btnNovo.Enabled = false;
                btnExcluir.Enabled = false;
                btnSair.Enabled = false;
                gpbRecuperaVendas.Enabled = false;

                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                gpbVendas.Enabled = true;
            }
        }

        private void zeraComboBox()
        {
            cmbCartao.SelectedItem = null;
            cmbPagamento.SelectedItem = null;
            cmbParcela.SelectedIndex = 0;
        }

        private void frmVendas_Load(object sender, EventArgs e) //Carrega o Form com os produtos na list
        {
            gpbDetalheCompra.Visible = false;
            monthCalendar1.Visible = false;
            dgvLista.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);
            dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Bold);
            dgvProdutos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
            dgvLista.Enabled = false;
            dgvProdutos.Enabled = false;
            PreencheComboBox();
            gpbCartao.Visible = false;
            gpbParcelas.Visible = false;
            controlaBotoes(true);
            zeraComboBox();
            AtualizaGrid();
        }

        
        
        private bool validarDados() //Verifica os dados osbrigatorios
        {
            string strMensagem = "";
            foreach (Control c in gpbVendas.Controls)
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

        private bool verificaPagamento() //Verifica se as formas de pagamentos estao corretas
        {
            string strMensagem = "";
            if (cmbPagamento.Text == "")
            {
                strMensagem = "Informe uma forma de pagamento!";
            }
            else if ((cmbCartao.Text == "" && cmbPagamento.Text == "Cartão"))
            {
                strMensagem = "Informe o tipo de cartão!";
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

        private void AtualizaGrid()
        {
            try
            {
                dgvVendas.DataSource = clsVenda.recuperarTodos();
                //C.CODIGO as Código_Venda, C.DATACOMPRA, C.VALOR, CLI.CODIGO, 
                //CLI.CPF, CLI.NOME as Cliente, F.NOME, C.NUMPARCELAS, P.NOME, C.DESCONTO
                dgvVendas.Columns[3].Visible = false;
                dgvVendas.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível recuperar os dados.  \nContate o administrador. \n\n" + ex.Message);
            }
        }

        /*
        private bool verificaParcelas() //Verifica se as parcelas estao corretas
        {
            string strMensagem = "";

            string valor1Final; //armazena o preço em uma string
            string valor2Parcelas; //armazena o preço em uma string
            string compararFinal;
            float vl1Final, vl2Final, resFinal; // armazenar valores para realizar conta

            valor1Final = txtValorFinal.Text.Replace("R", ""); //extraindo da string o R
            valor1Final = valor1Final.Replace("$", ""); //extraindo da string o $
            valor1Final = valor1Final.Replace(" ", ""); //extraindo da string o "espaço"
            vl1Final = float.Parse(valor1Final); // transformando essa string em um valor
            
            valor2Parcelas = txtParcelas.Text.Replace(" ", "");
            vl2Final = float.Parse(valor2Parcelas);
            resFinal = vl1Final / vl2Final; // calculando o resultado
            compararFinal = (resFinal.ToString("C")); // voltando o resultado para string

            if ((rbtCredito.Checked == true) && ((txtValorParcela.Text != (compararFinal)) ||
                (txtValor.Text != txtValorFinal.Text) || (txtParcelas.Text == "")))
                    {
                        strMensagem = strMensagem + "Valor da Parcela incorreto.";
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
        }*/

        private bool verificaValores()
        {
            string strMensagem = "";
            
            string valor1Total; //armazena o preço em uma string
            string valor2Descontos; //armazena o preço em uma string
            string compararTotal;
            double vl1Total, vl2Total, resTotal; // armazenar valores para realizar conta

            valor1Total = txtValor.Text.Replace("R", ""); //extraindo da string o R
            valor1Total = valor1Total.Replace("$", ""); //extraindo da string o $
            valor1Total = valor1Total.Replace(" ", ""); //extraindo da string o "espaço"
            valor2Descontos = txtDescontos.Text.Replace("R", ""); //extraindo da string o R
            valor2Descontos = valor2Descontos.Replace("$", ""); //extraindo da string o $
            valor2Descontos = valor2Descontos.Replace(" ", ""); //extraindo da string o "espaço"
            vl1Total = double.Parse(valor1Total); // transformando essa string em um valor
            vl2Total = double.Parse(valor2Descontos); // transformando essa string em um valor
            resTotal = vl1Total - vl2Total; // calculando o resultado
            compararTotal = (resTotal.ToString("C")); // voltando o resultado para string

            if (((vl2Total >= vl1Total) && vl2Total > 0))
            {
                strMensagem = strMensagem + "Valor de desconto incorreto";
            }
            else if ((txtValorFinal.Text == "0.00" || txtValorFinal.Text == "R$ 0,00"/*!= (compararTotal)*/))
            {
                strMensagem = strMensagem + "Valor Final incorreto!";
            }
            /*else if (lstProduto.Items.Count == 0)
            {
                strMensagem = "Selecione pelo menos um item.";
            }*/
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

        public int ok;

        public int Ok
        {
            get { return ok; }
            set { ok = value; }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            gpbDetalheCompra.Visible = false;
            zeraDados();
            PreencheList();
            dgvProdutos.Rows.Clear();
            dgvLista.Enabled = true;
            dgvProdutos.Enabled = true;
            frmLogin frmLogin = new frmLogin();
            txtCodigoVendedor.Text = Convert.ToString(ok);
            controlaBotoes(false);
            txtData.Text = DateTime.Now.ToShortDateString();
            txtData.Focus();
            gpbCartao.Visible = false;
            gpbParcelas.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
              atualizaCampos();
            
                if (validarDados() && verificaData() && 
                    verificaValores() && verificaPagamento() )
                {
                    try
                    {
                        clsVenda objVenda = new clsVenda();
                        objVenda.StrDataV = txtData.Text;
                        objVenda.StrValorCompra = txtValorFinal.Text;
                        objVenda.IntCodCli = Convert.ToInt16(txtCodigoCliente.Text);
                        objVenda.IntCodigoVendedor = Convert.ToInt16(txtCodigoVendedor.Text);
                        objVenda.StrValorDesconto = txtDescontos.Text;
                        objVenda.IntFormaPag = Convert.ToInt16(cmbPagamento.SelectedValue.ToString());
                        objVenda.IntNumParcela = Convert.ToInt16(cmbParcela.Text);
                        if (txtCodigoVenda.Text == "")
                        {
                            objVenda.Salvar();
                            salvarProdutos();
                            salvarPagamento();
                            atualizaEstoque();
                            MessageBox.Show("Venda concluída com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Venda não concluída.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }


                        controlaBotoes(true);
                        AtualizaGrid();
                        plnCliente.Visible = false;
                        zeraDados();
                        zeraComboBox();
                        DataTable lista = (DataTable)dgvLista.DataSource;
                        dgvLista.Columns.Remove("Qtde");
                        dgvLista.Columns.Remove("VlTo");
                        if (lista != null)
                        {
                            lista.Clear();
                        }
                        monthCalendar1.Visible = false;
                        gpbDetalheCompra.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Venda não concluída. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }

        private void salvarProdutos()
        {
            foreach (DataGridViewRow prod in dgvProdutos.Rows)
            {
                DataTable codigocompra = clsCompraProduto.recuperaCodigoCompra();
                clsCompraProduto objCompraProduto = new clsCompraProduto();
                objCompraProduto.IntCodCompra = Convert.ToInt16(codigocompra.Rows[0][0].ToString());
                objCompraProduto.IntCodProduto = Convert.ToInt16(prod.Cells[0].Value);
                objCompraProduto.IntQtde = Convert.ToInt16(prod.Cells[3].Value);
                objCompraProduto.Salvar();
            }
        }

        private void salvarPagamento()
        {
            clsPagamento objPagamento = new clsPagamento();
            DataTable codigocompra = clsCompraProduto.recuperaCodigoCompra();
            string status = "Pago";
            string data = txtData.Text;
            if ((cmbPagamento.Text != "Dinheiro" && cmbPagamento.Text != "Cartão"))
            {
                status = "Aguardando";
                data = "";
            }
            objPagamento.StrValorParcela = valorparcela;
            objPagamento.StrStatus = status;
            objPagamento.StrDataP = data;
            objPagamento.IntCodigoVenda = Convert.ToInt16(codigocompra.Rows[0][0].ToString());
            objPagamento.Salvar();
        }

        private void atualizaEstoque()
        {
            foreach (DataGridViewRow prod in dgvProdutos.Rows)
            {
                clsEstoque objEstoque = new clsEstoque();
                int codigo = Convert.ToInt16(prod.Cells[0].Value);
                DataTable dtApoio = clsEstoque.recuperarQtdeProduto(codigo);
                int qtde = Convert.ToInt16(dtApoio.Rows[0][0]) - Convert.ToInt16(prod.Cells[3].Value);
                objEstoque.IntQtde = qtde;
                objEstoque.IntCodProduto = codigo;
                objEstoque.Alterar();
            }
        }

        private void zeraDados()
        {
            txtCodigoVenda.Text = "";
            txtCodigoCliente.Text = "";
            cmbPagamento.SelectedItem = null;
            txtCodigoVendedor.Text = "";
            txtData.Text = "";
            txtCodigoCliente.Text = "";
            txtCPF.Text = "";
            txtValor.Text = "R$ 0,00";
            txtUnitario.Text = "R$ 0,00";
            txtDescontos.Text = "R$ 0,00";
            txtValorFinal.Text = "R$ 0,00";
            txtProduto.Text = "";
            gpbCartao.Visible = false;
            gpbParcelas.Visible = false;
            nudQtde.Value = 1;
            dgvProdutos.Rows.Clear();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            zeraDados();
            plnCliente.Visible = false;
            gpbCartao.Visible = false;
            gpbParcelas.Visible = false;
            controlaBotoes(true);
            zeraComboBox();
            DataTable lista = (DataTable)dgvLista.DataSource;
            dgvLista.Columns.Remove("Qtde");
            dgvLista.Columns.Remove("VlTo");
            if (lista != null)
            {
                lista.Clear();
            }
            monthCalendar1.Visible = false;
            gpbDetalheCompra.Visible = false;
        }
        
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigoVenda.Text != "")
            {
                controlaBotoes(false);
            }
            else
            {
                MessageBox.Show(this, "Selecione um registro para alterar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.dgvVendas.Rows.Count > 0)
            { 
                if ( txtCodigoVenda.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão da venda selecionada?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            clsVenda objVenda = new clsVenda();
                            objVenda.IntCodigoVenda = Convert.ToInt16(txtCodigoVenda.Text);
                            objVenda.Excluir();
                            controlaBotoes(true);
                            AtualizaGrid();
                            zeraDados();
                            MessageBox.Show("Venda excluída com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Venda não foi excluída. \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //Limpar ou atualizar lista
                        gpbDetalheCompra.Visible = false;
                    }
                    else
                    {
                        //Limpar ou atualizar lista
                        gpbDetalheCompra.Visible = false;
                        zeraDados();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Selecione uma venda para excluir", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem vendas para excluir", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dgvVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //C.CODIGO, C.DATACOMPRA, C.VALOR, CLI.CODIGO, CLI.CPF, CLI.NOME, F.NOME, C.NUMPARCELAS, P.NOME, C.DESCONTO
                txtCodigoVenda.Text = dgvVendas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtData.Text = dgvVendas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtValorFinal.Text = dgvVendas.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCodigoCliente.Text = dgvVendas.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCPF.Text = dgvVendas.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNomeCliente.Text =  dgvVendas.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbParcela.Text =  dgvVendas.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbPagamento.Text = dgvVendas.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtDescontos.Text = dgvVendas.Rows[e.RowIndex].Cells[9].Value.ToString();
                                
                string valor1, valor2;//armazena o preço em uma string
                double vl1, vl2, res; // armazenar valores para realizar conta
                valor1 = dgvVendas.Rows[e.RowIndex].Cells[2].Value.ToString();
                valor1 =  valor1.Replace("R", ""); //extraindo da string o R
                valor1 = valor1.Replace("$", ""); //extraindo da string o $
                valor1 = valor1.Replace(" ", ""); //extraindo da string o "espaço"
                valor2 = dgvVendas.Rows[e.RowIndex].Cells[9].Value.ToString();
                valor2 = valor2.Replace("R", ""); //extraindo da string o R
                valor2 = valor2.Replace("$", ""); //extraindo da string o $
                valor2 = valor2.Replace(" ", ""); //extraindo da string o "espaço"
                vl1 = double.Parse(valor1); // transformando essa string em um valor
                vl2 = double.Parse(valor2); //transformando essa string em um valor
                res = vl1 + vl2; // calculando o resultado
                txtValor.Text = (res.ToString()); // voltando o resultado para string
                //transformando o resultado de volta em Reais:
                txtValor.Text = double.Parse(txtValor.Text).ToString("C");     
                
                if (txtCodigoVenda.Text != "")
                {
                    DataTable dtApoio = clsVenda.RecuperarCodigo(Convert.ToInt16(txtCodigoVenda.Text));
                    if (dtApoio.Rows.Count > 0)
                    {
                        txtCodigoVendedor.Text = Convert.ToString(dtApoio.Rows[0][4]);
                    }
                }

                if (dgvVendas.RowCount > 0)
                {
                    int codigo;
                    codigo = Convert.ToInt16(dgvVendas.CurrentRow.Cells[0].Value);
                    gpbDetalheCompra.Visible = true;
                    dgvDetalheCompra.DataSource = clsCompraProduto.recuperaDetalhes(codigo);
                }
                else
                {
                    MessageBox.Show("Sem vendas para exibir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
        private void txtUnitario_Leave(object sender, EventArgs e)
        {
            {
                if (txtUnitario.Text == "")
                {
                    txtUnitario.Text = "0";
                    txtUnitario.Focus();
                }
                txtUnitario.Text = Convert.ToDouble(txtUnitario.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
            }
        }

        private void txtUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txtUnitario.Text.Contains(','))
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

        /*private void txtUnitario_Enter(object sender, EventArgs e)
        {
            //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
            //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
            //(ex.: 'R$') por causa da formatação que já existe nele: 
            String x = "";
            for (int i = 0; i <= txtUnitario.Text.Length - 1; i++)
            {
                if ((txtUnitario.Text[i] >= '0' &&
                    txtUnitario.Text[i] <= '9') ||
                    txtUnitario.Text[i] == ',')
                {
                    x += txtUnitario.Text[i];
                }
            }
            txtUnitario.Text = x;
            txtUnitario.SelectAll();
        }*/    

        private void addItenLista()
        {
            decimal somafinal = 0M;
            int qtde;
            qtde = Convert.ToInt32(nudQtde.Value);
            if (qtde > 0)
            {
                dgvProdutos.Rows.Add(adicionar(dgvLista.CurrentRow));
                foreach (DataGridViewRow dgv in dgvProdutos.Rows)
                {
                    somafinal += Convert.ToDecimal(dgv.Cells[4].Value);
                }
                txtValor.Text = somafinal.ToString("C");
                atualizaCampos();
            }
            else
            {
                MessageBox.Show("Quantidade inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQtde.Focus();
            }
        }

        private void txtParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
        }
        
        //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
        private void txtDescontos_Leave(object sender, EventArgs e)
        {
            {
                if (txtDescontos.Text == "")
                {
                    txtDescontos.Text = "0";
                }
                //txtValor.Text = "R$ " + txtValor.Text;
                txtDescontos.Text = Convert.ToDouble(txtDescontos.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
            }
        }

        private void txtDescontos_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txtDescontos.Text.Contains(','))
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

        private void txtDescontos_Enter(object sender, EventArgs e)
        {
            //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
            //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
            //(ex.: 'R$') por causa da formatação que já existe nele: 
            String x = "";
            for (int i = 0; i <= txtDescontos.Text.Length - 1; i++)
            {
                if ((txtDescontos.Text[i] >= '0' &&
                    txtDescontos.Text[i] <= '9') ||
                    txtDescontos.Text[i] == ',')
                {
                    x += txtDescontos.Text[i];
                }
            }
            txtDescontos.Text = x;
            txtDescontos.SelectAll();
        }

        private string valorparcela;

        public string Valorparcela
        {
            get { return valorparcela; }
            set { valorparcela = value; }
        }

        //Leave do textBox você converte para o formato monerário com o R$ da seguinte forma:
        private void txtValorFinal_Leave(object sender, EventArgs e)
        {
            string valor1;//armazena o preço em uma string
            string valor2;//armazena o preço em uma string
            double vl1, vl2, res; // armazenar valores para realizar conta
            if (txtValor.Text == "")
            {
                txtValor.Text = "R$ 0,00";
            }
            if (txtDescontos.Text == "")
            {
                txtDescontos.Text = "R$ 0,00";
            }
            valor1 = txtValor.Text.Replace("R", ""); //extraindo da string o R
            valor1 = valor1.Replace("$", ""); //extraindo da string o $
            valor1 = valor1.Replace(" ", ""); //extraindo da string o "espaço"
            valor2 = txtDescontos.Text.Replace("R", ""); //extraindo da string o R
            valor2 = valor2.Replace("$", ""); //extraindo da string o $
            valor2 = valor2.Replace(" ", ""); //extraindo da string o "espaço"
            vl1 = double.Parse(valor1); // transformando essa string em um valor
            vl2 = double.Parse(valor2); //transformando essa string em um valor
            res = vl1 - vl2; // calculando o resultado
            txtValorFinal.Text = (res.ToString()); // voltando o resultado para string
            //transformando o resultado de volta em Reais:
            txtValorFinal.Text = double.Parse(txtValorFinal.Text).ToString("C");// está C, colocar "F" qdo conectar com o BD
        }

        private void txtValorFinal_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txtValorFinal.Text.Contains(','))
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

        private void txtValorFinal_Enter(object sender, EventArgs e)
        {
            //evento Enter é preciso tirar a formatação para que não gere nenhuma excessão 
            //quando o textBox receber e perder o focu novamente contendo caracteres inválidos
            //(ex.: 'R$') por causa da formatação que já existe nele: 
            String x = "";
            for (int i = 0; i <= txtValorFinal.Text.Length - 1; i++)
            {
                if ((txtValorFinal.Text[i] >= '0' &&
                    txtValorFinal.Text[i] <= '9') ||
                    txtValorFinal.Text[i] == ',')
                {
                    x += txtValorFinal.Text[i];
                }
            }
            txtValorFinal.Text = x;
            txtValorFinal.SelectAll();
        }

        private void txtDescontos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                atualizaCampos();
            }
        }

        private void txtValor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtValorFinal_Leave(sender,e);
            }
        }
                

        private void removeItemAtualizaValorTotal()
        {
            string valor = "", valorfinal = "";
            decimal novovalor = 0M, novofinal = 0M, resultado = 0M;
            valor = Convert.ToString(txtValor.Text);
            valor = valor.Replace("R", "");
            valor = valor.Replace("$", "");
            valor = valor.Replace(" ", "");
            novovalor = Decimal.Parse(valor);
            valorfinal = Convert.ToString(dgvProdutos.CurrentRow.Cells[4].Value);
            valorfinal = valorfinal.Replace("R", "");
            valorfinal = valorfinal.Replace("$", "");
            valorfinal = valorfinal.Replace(" ", "");
            novofinal = Decimal.Parse(valorfinal);
            resultado = novovalor - novofinal;
            txtValor.Text = resultado.ToString("C");
            atualizaCampos();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value) == 0)
                {
                    dgvLista.Rows[e.RowIndex].Cells[0].Value = 1;
                }
                else
                {
                    dgvLista.Rows[e.RowIndex].Cells[0].Value = 0;
                }
            }*/
        }

        private DataGridViewRow adicionar(DataGridViewRow row)
        {
                string valorUnit = "";
                decimal valorUnitario = 0M, valorfinal = 0M;
                valorUnit = Convert.ToString(dgvLista.CurrentRow.Cells[2].Value).Replace("R", "");
                valorUnit = valorUnit.Replace("$", "");
                valorUnit = valorUnit.Replace(" ", "");
                valorUnitario = decimal.Parse(valorUnit);
                valorfinal = valorUnitario * nudQtde.Value;
                DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                newRow.Cells[0].Value = row.Cells[0].Value;
                newRow.Cells[1].Value = row.Cells[1].Value;
                newRow.Cells[2].Value = row.Cells[2].Value;
                newRow.Cells[3].Value = nudQtde.Value;
                row.Cells[4].Value = valorfinal;
                newRow.Cells[4].Value = row.Cells[4].Value;
                return newRow;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                if (verificaEstoque() == true)
                {
                    int sim = 0;
                    foreach (DataGridViewRow prod in dgvProdutos.Rows)
                    {
                        if (Convert.ToInt16(dgvLista.CurrentRow.Cells[0].Value) == Convert.ToInt16(prod.Cells[0].Value))
                        {
                            sim = 1;
                            break;
                        }
                    }
                    if (sim == 0)
                    {
                        addItenLista();
                    }
                    else
                    {
                        MessageBox.Show("O item que você deseja adicionar já existe na lista!\nAltere a coluna Quantidade para o valor desejado.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Quantidade indisponível em estoque.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem produtos na lista!","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

       
        private void btnRem_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.Rows.Count > 0)
            {
                removeItemAtualizaValorTotal();
                dgvProdutos.Rows.Remove(dgvProdutos.CurrentRow);
            }
            else
            {
                MessageBox.Show("Sem produtos na lista!","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        private void atualizaCampos() //Atualiza os Campos ValorFinal e ValorParcelas
        {
            string svalor, sdesconto;
            decimal final, valor, desconto, valorfinal;
            if (txtDescontos.Text == "")
            {
                txtDescontos.Text = "0"; 
            }
            svalor = txtValor.Text.Replace("R", "");
            svalor = svalor.Replace("$", "");
            svalor = svalor.Replace(" ", "");
            sdesconto = txtDescontos.Text.Replace("R", "");
            sdesconto = sdesconto.Replace("$", "");
            sdesconto = sdesconto.Replace(" ", "");
            valor = Decimal.Parse(svalor);
            desconto = Decimal.Parse(sdesconto);
            final = valor - desconto;
            valorfinal = final / Convert.ToInt16(cmbParcela.Text);
            valorparcela = valorfinal.ToString("C");
            txtValorFinal.Text = final.ToString("C");
        }


        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8 && e.KeyChar != (Char)9)
            {
                e.KeyChar = (Char)0;
            }
        }


        private void PreencheComboBox()
        {
            cmbPagamento.DataSource = clsFormaPagamento.recuperarTodos();
            cmbPagamento.DisplayMember = "nome";
            cmbPagamento.ValueMember = "Codigo";

            cmbCartao.Items.Add("Débito");
            cmbCartao.Items.Add("Crédito");

            cmbParcela.Items.Add("1");
            cmbParcela.Items.Add("2");
            cmbParcela.Items.Add("3");
            cmbParcela.Items.Add("4");
            cmbParcela.Items.Add("5");
            cmbParcela.Items.Add("6");
            cmbParcela.Items.Add("7");
            cmbParcela.Items.Add("8");
            cmbParcela.Items.Add("9");
            cmbParcela.Items.Add("10");
            cmbParcela.Items.Add("11");
            cmbParcela.Items.Add("12");

        }

        private void PreencheList()
        {
            dgvLista.DataSource = clsVenda.recuperaProdutos();
            dgvLista.Columns[3].Visible = false;
            //adiciona nova coluna na tabela
            DataGridViewColumn col2 = new DataGridViewColumn();
            col2.HeaderText = "VlTo";
            col2.Name = "VlTo";
            col2.CellTemplate = new DataGridViewTextBoxCell();
            dgvLista.Columns.Insert(4, col2);
            dgvLista.Columns[4].Visible = false;
        }

        private void txtData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                verificaData();
            }
        }

        private Boolean verificaData()
        {
            if (txtData.TextLength < 10 && txtData.TextLength > 0 || txtData.Text.Contains(" "))
            {
                MessageBox.Show("Data da Venda Inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errMsgErro.SetError(txtData, "Data da Venda não preenchida corretamente\nFormato: dd/mm/aaaa");
                return false;
            }
            else
            {
                errMsgErro.SetError(txtData, "");
                return true;
            }
        }

        private void cmbPagamento_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbPagamento.Text == "Cartão")
            {
                gpbCartao.Visible = true;
            }
            else if(cmbPagamento.Text == "Cheque")
            {
                gpbCartao.Visible = false;
                gpbParcelas.Visible = true;
            }
            else
            {
                gpbCartao.Visible = false;
                gpbParcelas.Visible = false;
                cmbCartao.SelectedItem = null;
                cmbParcela.SelectedIndex = 0;
            }

        }

        private void cmbCartao_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbCartao.Text == "Crédito")
            {
                gpbParcelas.Visible = true;
            }
            else
            {
                gpbParcelas.Visible = false;
                cmbParcela.SelectedIndex = 0;
            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtUnitario.Text = dgvLista.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            PesquisaVendaCadastro();
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {

        }

        private bool verificaEstoque()
        {
            if ( Convert.ToInt16(dgvLista.CurrentRow.Cells[3].Value) >= nudQtde.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                if (verificaEstoque() == true)
                {
                    int sim = 0;
                    foreach (DataGridViewRow prod in dgvProdutos.Rows)
                    {
                        if (Convert.ToInt16(dgvLista.CurrentRow.Cells[0].Value) == Convert.ToInt16(prod.Cells[0].Value))
                        {
                            sim = 1;
                            break;
                        }
                    }
                    if (sim == 0)
                    {
                        addItenLista();
                    }
                    else
                    {
                        MessageBox.Show("O item que você deseja adicionar já existe na lista!\nAltere a coluna Quantidade para o valor desejado.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Quantidade indisponível em estoque.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sem produtos na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            removeItemAtualizaValorTotal();
            dgvProdutos.Rows.Remove(dgvProdutos.CurrentRow);
            
        }

        private void atualizaQtde()
        {
            decimal somafinal = 0M, valorfinal = 0M;
            int qtde;
            string valorUnit;
            decimal valorUnitario;
            qtde = Convert.ToInt16(dgvProdutos.CurrentRow.Cells[3].Value);
            if (qtde > 0)
            {
                valorUnit = Convert.ToString(dgvProdutos.CurrentRow.Cells[2].Value);
                valorUnit = valorUnit.Replace("R", "");
                valorUnit = valorUnit.Replace("$", "");
                valorUnit = valorUnit.Replace(" ", "");
                valorUnitario = decimal.Parse(valorUnit);
                valorfinal = valorUnitario * qtde;
                dgvProdutos.CurrentRow.Cells[4].Value = valorfinal;
                foreach (DataGridViewRow dgv in dgvProdutos.Rows)
                {
                    somafinal += Convert.ToDecimal(dgv.Cells[4].Value);
                }
                
                txtValor.Text = somafinal.ToString("C");
                atualizaCampos();
            }
            else
            {
                MessageBox.Show("Quantidade inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQtde.Focus();
            }
        }

       /* private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvProdutos.CurrentRow != null)
            {
                atualizaQtde();
                }
                else
                {
                    MessageBox.Show("Quantidade inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQtde.Focus();
                }
        }*/

        private void dgvProdutos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {

                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);

            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (Char)8 )

                e.Handled = true;

        }

        private void dgvProdutos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[3].Value == null)
            {
                e.Row.Cells[3].Value = 1;
            }
        }

        private bool verificaEstoqueComProdutoLista()
        {
            int codigo = Convert.ToInt16(dgvProdutos.CurrentRow.Cells[0].Value);
            DataTable dtApoio = clsEstoque.recuperarQtdeProduto(codigo);
            if (Convert.ToInt16(dgvProdutos.CurrentRow.Cells[3].Value) <= Convert.ToInt16(dtApoio.Rows[0][0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
            if ( Convert.ToInt16(dgvProdutos.CurrentRow.Cells[3].Value) > 0)
            {
                if (verificaEstoqueComProdutoLista() == true)
                {
                    atualizaQtde();
                }
                else
                {
                    MessageBox.Show("Quantidade indisponível em estoque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvProdutos.CurrentRow.Cells[3].Value = 1;
                }
            }
            else
            {
                MessageBox.Show("Quantidade inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvProdutos.CurrentRow.Cells[3].Value = 1;
            }
            }
        }

        private void PesquisaVendaCadastro()
        {
            DataTable lista = (DataTable)dgvLista.DataSource;
            dgvLista.Columns.Remove("VlTo");
            if (lista != null)
            {
                lista.Clear();
            }
            dgvLista.DataSource = clsVenda.recuperaTodosProdutos(txtProduto.Text);
            //adiciona nova coluna na tabela
            DataGridViewColumn col2 = new DataGridViewColumn();
            col2.HeaderText = "VlTo";
            col2.Name = "VlTo";
            col2.CellTemplate = new DataGridViewTextBoxCell();
            dgvLista.Columns.Insert(4, col2);
            dgvLista.Columns[4].Visible = false;
        }

        private void txtVenda_TextChanged(object sender, EventArgs e)
        {
            dgvVendas.DataSource = clsVenda.recuperarTodosFiltro(txtVenda.Text);
            dgvVendas.Columns[3].Visible = false;
            dgvVendas.Columns[4].Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtData.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private void txtVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvVendas.DataSource = clsVenda.recuperarTodosFiltro(txtVenda.Text);
        }

        private void gpbVendas_Enter(object sender, EventArgs e)
        {

        }


        private void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text == "")
            {
                txtNomeCliente.Text = "";
            }
        }


        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RecuperarInfoCliente(txtCodigoCliente.Text);
                plnCliente.Visible = false;
            }
        }


        private void btnProcurar_Click(object sender, EventArgs e)
        {
            plnCliente.Location = new Point(121, 121);
            plnCliente.Visible = true;
            AtualizaListaClientes();
        }

        private void AtualizaListaClientes()
        {
            dgvCliente.DataSource = clsCliente.recuperarTodos();
            dgvCliente.Columns[3].Visible = false;
            dgvCliente.Columns[4].Visible = false;
            dgvCliente.Columns[5].Visible = false;
            dgvCliente.Columns[6].Visible = false;
            dgvCliente.Columns[7].Visible = false;
            dgvCliente.Columns[8].Visible = false;
            dgvCliente.Columns[9].Visible = false;
            dgvCliente.Columns[10].Visible = false;
        }

        private void btnSairGrid_Click(object sender, EventArgs e)
        {
            plnCliente.Visible = false;
        }

        private void txtConsCliente_TextChanged(object sender, EventArgs e)
        {
            dgvCliente.DataSource = clsCliente.recuperarTodosFiltro(txtConsCliente.Text);
            dgvCliente.Columns[3].Visible = false;
            dgvCliente.Columns[4].Visible = false;
            dgvCliente.Columns[5].Visible = false;
            dgvCliente.Columns[6].Visible = false;
            dgvCliente.Columns[7].Visible = false;
            dgvCliente.Columns[8].Visible = false;
            dgvCliente.Columns[9].Visible = false;
            dgvCliente.Columns[10].Visible = false;
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecuperarInfoCliente(dgvCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
                plnCliente.Visible = false;
            }
        }

        private void RecuperarInfoCliente(string codigoNaoVerificado)
        {
            try
            {
                int codigo = Convert.ToInt16(codigoNaoVerificado);
                DataTable dtApoio = clsCliente.recuperarCodigo(codigo);
                if (dtApoio.Rows.Count > 0)
                {
                    txtCodigoCliente.Text = codigoNaoVerificado;
                    txtNomeCliente.Text = dtApoio.Rows[0][2].ToString();
                    txtCPF.Text = dtApoio.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Código de Cliente inválido","Aviso.",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtCodigoCliente.Text = "";
                    txtCodigoCliente.Focus();
                    txtCPF.Text = "";
                }

            }
            catch (Exception)
            {
            }
        }

        private void plnCliente_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigoCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                RecuperarInfoCliente(txtCodigoCliente.Text);
                plnCliente.Visible = false;
            }
        }

        private void txtUnitario_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= txtUnitario.Text.Length - 1; i++)
            {
                if ((txtUnitario.Text[i] >= '0' &&
                    txtUnitario.Text[i] <= '9') ||
                    txtUnitario.Text[i] == ',')
                {
                    x += txtUnitario.Text[i];
                }
            }
            txtUnitario.Text = x;
            txtUnitario.SelectAll();
        }

    }
}
