namespace LojaGames.Visao
{
    partial class frmPagamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentos));
            this.gpbPagamentos = new System.Windows.Forms.GroupBox();
            this.txtDataVenda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtCodigoPagamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataPagamento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCodigoVenda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbRecuperaPagamentos = new System.Windows.Forms.GroupBox();
            this.txtCStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gpbPagamentos.SuspendLayout();
            this.gpbRecuperaPagamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbPagamentos
            // 
            this.gpbPagamentos.Controls.Add(this.txtDataVenda);
            this.gpbPagamentos.Controls.Add(this.label11);
            this.gpbPagamentos.Controls.Add(this.txtValorTotal);
            this.gpbPagamentos.Controls.Add(this.label7);
            this.gpbPagamentos.Controls.Add(this.monthCalendar1);
            this.gpbPagamentos.Controls.Add(this.txtCodigoPagamento);
            this.gpbPagamentos.Controls.Add(this.label1);
            this.gpbPagamentos.Controls.Add(this.txtNome);
            this.gpbPagamentos.Controls.Add(this.label10);
            this.gpbPagamentos.Controls.Add(this.txtDataPagamento);
            this.gpbPagamentos.Controls.Add(this.label9);
            this.gpbPagamentos.Controls.Add(this.label6);
            this.gpbPagamentos.Controls.Add(this.txtStatus);
            this.gpbPagamentos.Controls.Add(this.txtValorParcela);
            this.gpbPagamentos.Controls.Add(this.txtNumero);
            this.gpbPagamentos.Controls.Add(this.txtCodigoVenda);
            this.gpbPagamentos.Controls.Add(this.label5);
            this.gpbPagamentos.Controls.Add(this.label4);
            this.gpbPagamentos.Controls.Add(this.label3);
            this.gpbPagamentos.Controls.Add(this.label2);
            this.gpbPagamentos.Location = new System.Drawing.Point(58, 6);
            this.gpbPagamentos.Name = "gpbPagamentos";
            this.gpbPagamentos.Size = new System.Drawing.Size(673, 260);
            this.gpbPagamentos.TabIndex = 0;
            this.gpbPagamentos.TabStop = false;
            this.gpbPagamentos.Text = "Dados do Pagamento";
            this.gpbPagamentos.Enter += new System.EventHandler(this.gpbPagamentos_Enter);
            // 
            // txtDataVenda
            // 
            this.txtDataVenda.Location = new System.Drawing.Point(32, 134);
            this.txtDataVenda.Name = "txtDataVenda";
            this.txtDataVenda.ReadOnly = true;
            this.txtDataVenda.Size = new System.Drawing.Size(103, 20);
            this.txtDataVenda.TabIndex = 19;
            this.txtDataVenda.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data da Venda";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(154, 134);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(103, 20);
            this.txtValorTotal.TabIndex = 17;
            this.txtValorTotal.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Valor Total da Venda";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(347, 93);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.TabIndex = 15;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // txtCodigoPagamento
            // 
            this.txtCodigoPagamento.Location = new System.Drawing.Point(32, 32);
            this.txtCodigoPagamento.Name = "txtCodigoPagamento";
            this.txtCodigoPagamento.ReadOnly = true;
            this.txtCodigoPagamento.Size = new System.Drawing.Size(112, 20);
            this.txtCodigoPagamento.TabIndex = 13;
            this.txtCodigoPagamento.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Código da Venda";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(32, 73);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(295, 20);
            this.txtNome.TabIndex = 2;
            this.txtNome.Tag = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nome do Cliente";
            // 
            // txtDataPagamento
            // 
            this.txtDataPagamento.Location = new System.Drawing.Point(347, 72);
            this.txtDataPagamento.Name = "txtDataPagamento";
            this.txtDataPagamento.ReadOnly = true;
            this.txtDataPagamento.Size = new System.Drawing.Size(148, 20);
            this.txtDataPagamento.TabIndex = 3;
            this.txtDataPagamento.Tag = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Data do Pagamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.Location = new System.Drawing.Point(344, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Status do Pagamento";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Red;
            this.txtStatus.Location = new System.Drawing.Point(346, 31);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(148, 20);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.Tag = "";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(154, 190);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ReadOnly = true;
            this.txtValorParcela.Size = new System.Drawing.Size(116, 20);
            this.txtValorParcela.TabIndex = 5;
            this.txtValorParcela.Tag = "";
            this.txtValorParcela.Enter += new System.EventHandler(this.txtValor_Enter);
            this.txtValorParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValorParcela.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(32, 190);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(103, 20);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.Tag = "";
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtCodigoVenda
            // 
            this.txtCodigoVenda.Location = new System.Drawing.Point(179, 32);
            this.txtCodigoVenda.Name = "txtCodigoVenda";
            this.txtCodigoVenda.ReadOnly = true;
            this.txtCodigoVenda.Size = new System.Drawing.Size(103, 20);
            this.txtCodigoVenda.TabIndex = 1;
            this.txtCodigoVenda.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor da Parcela";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número de Parcelas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código do Pagamento";
            // 
            // btnSair
            // 
            this.btnSair.Image = global::LojaGames.Properties.Resources.fexar;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(516, 270);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 35);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "Sair      ";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::LojaGames.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(413, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 35);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gpbRecuperaPagamentos
            // 
            this.gpbRecuperaPagamentos.Controls.Add(this.txtCStatus);
            this.gpbRecuperaPagamentos.Controls.Add(this.label12);
            this.gpbRecuperaPagamentos.Controls.Add(this.txtConsulta);
            this.gpbRecuperaPagamentos.Controls.Add(this.label8);
            this.gpbRecuperaPagamentos.Controls.Add(this.dgvPagamentos);
            this.gpbRecuperaPagamentos.Location = new System.Drawing.Point(12, 311);
            this.gpbRecuperaPagamentos.Name = "gpbRecuperaPagamentos";
            this.gpbRecuperaPagamentos.Size = new System.Drawing.Size(786, 335);
            this.gpbRecuperaPagamentos.TabIndex = 26;
            this.gpbRecuperaPagamentos.TabStop = false;
            // 
            // txtCStatus
            // 
            this.txtCStatus.Location = new System.Drawing.Point(592, 20);
            this.txtCStatus.Name = "txtCStatus";
            this.txtCStatus.Size = new System.Drawing.Size(132, 20);
            this.txtCStatus.TabIndex = 15;
            this.txtCStatus.TextChanged += new System.EventHandler(this.txtCStatus_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(487, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Consulta por Status:";
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(179, 21);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(261, 20);
            this.txtConsulta.TabIndex = 13;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Consulta por Nome do Cliente:";
            // 
            // dgvPagamentos
            // 
            this.dgvPagamentos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPagamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPagamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPagamentos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentos.Location = new System.Drawing.Point(6, 56);
            this.dgvPagamentos.Name = "dgvPagamentos";
            this.dgvPagamentos.ReadOnly = true;
            this.dgvPagamentos.Size = new System.Drawing.Size(772, 273);
            this.dgvPagamentos.TabIndex = 0;
            this.dgvPagamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagamentos_CellClick);
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.Image = global::LojaGames.Properties.Resources.alterar1;
            this.btnAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualiza.Location = new System.Drawing.Point(203, 269);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(75, 36);
            this.btnAtualiza.TabIndex = 8;
            this.btnAtualiza.Text = "     Atualizar     Status";
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::LojaGames.Properties.Resources.save_icon1;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(307, 269);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 35);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "    Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 658);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gpbRecuperaPagamentos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAtualiza);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.gpbPagamentos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPagamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Pagamentos";
            this.Load += new System.EventHandler(this.frmPagamentos_Load);
            this.gpbPagamentos.ResumeLayout(false);
            this.gpbPagamentos.PerformLayout();
            this.gpbRecuperaPagamentos.ResumeLayout(false);
            this.gpbRecuperaPagamentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPagamentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCodigoVenda;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gpbRecuperaPagamentos;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPagamentos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataPagamento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.TextBox txtCodigoPagamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtDataVenda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCStatus;
        private System.Windows.Forms.Label label12;
    }
}