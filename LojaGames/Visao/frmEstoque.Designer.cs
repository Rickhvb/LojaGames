namespace LojaGames.Visao
{
    partial class frmEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoque));
            this.gpbProdutos = new System.Windows.Forms.GroupBox();
            this.VerificaNovoOuAtualiza = new System.Windows.Forms.Label();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQtde = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.gpbRecuperaProdutos = new System.Windows.Forms.GroupBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.plnProduto = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSairGrid = new System.Windows.Forms.Button();
            this.txtConsProduto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvProdutoConsulta = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.gpbProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtde)).BeginInit();
            this.gpbRecuperaProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.plnProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbProdutos
            // 
            this.gpbProdutos.Controls.Add(this.VerificaNovoOuAtualiza);
            this.gpbProdutos.Controls.Add(this.btnProcurar);
            this.gpbProdutos.Controls.Add(this.txtNomeProduto);
            this.gpbProdutos.Controls.Add(this.label3);
            this.gpbProdutos.Controls.Add(this.nudQtde);
            this.gpbProdutos.Controls.Add(this.label2);
            this.gpbProdutos.Controls.Add(this.label1);
            this.gpbProdutos.Controls.Add(this.txtCodigo);
            this.gpbProdutos.Location = new System.Drawing.Point(163, 30);
            this.gpbProdutos.Name = "gpbProdutos";
            this.gpbProdutos.Size = new System.Drawing.Size(387, 103);
            this.gpbProdutos.TabIndex = 1;
            this.gpbProdutos.TabStop = false;
            this.gpbProdutos.Text = "Produto";
            this.gpbProdutos.Enter += new System.EventHandler(this.gpbCategorias_Enter);
            // 
            // VerificaNovoOuAtualiza
            // 
            this.VerificaNovoOuAtualiza.AutoSize = true;
            this.VerificaNovoOuAtualiza.Location = new System.Drawing.Point(296, 74);
            this.VerificaNovoOuAtualiza.Name = "VerificaNovoOuAtualiza";
            this.VerificaNovoOuAtualiza.Size = new System.Drawing.Size(0, 13);
            this.VerificaNovoOuAtualiza.TabIndex = 111;
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(281, 35);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(62, 23);
            this.btnProcurar.TabIndex = 110;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Enabled = false;
            this.txtNomeProduto.Location = new System.Drawing.Point(104, 37);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.ReadOnly = true;
            this.txtNomeProduto.Size = new System.Drawing.Size(169, 20);
            this.txtNomeProduto.TabIndex = 109;
            this.txtNomeProduto.Tag = "n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Nome do Produto";
            // 
            // nudQtde
            // 
            this.nudQtde.Location = new System.Drawing.Point(184, 66);
            this.nudQtde.Name = "nudQtde";
            this.nudQtde.Size = new System.Drawing.Size(85, 20);
            this.nudQtde.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código*";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(37, 38);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(57, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Tag = "n";
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnSair
            // 
            this.btnSair.Image = global::LojaGames.Properties.Resources.fexar1;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(499, 166);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(70, 36);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sair      ";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::LojaGames.Properties.Resources.cancelar1;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(410, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 36);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::LojaGames.Properties.Resources.save_icon2;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(322, 166);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 36);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar   ";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.Image = global::LojaGames.Properties.Resources.alterar1;
            this.btnAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualiza.Location = new System.Drawing.Point(220, 166);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(86, 36);
            this.btnAtualiza.TabIndex = 14;
            this.btnAtualiza.Text = "     Atualizar         Quantidade";
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // gpbRecuperaProdutos
            // 
            this.gpbRecuperaProdutos.Controls.Add(this.dgvProdutos);
            this.gpbRecuperaProdutos.Controls.Add(this.txtConsulta);
            this.gpbRecuperaProdutos.Controls.Add(this.label4);
            this.gpbRecuperaProdutos.Location = new System.Drawing.Point(135, 222);
            this.gpbRecuperaProdutos.Name = "gpbRecuperaProdutos";
            this.gpbRecuperaProdutos.Size = new System.Drawing.Size(434, 241);
            this.gpbRecuperaProdutos.TabIndex = 15;
            this.gpbRecuperaProdutos.TabStop = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(31, 53);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(381, 179);
            this.dgvProdutos.TabIndex = 9;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellClick);
            this.dgvProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(187, 19);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(172, 20);
            this.txtConsulta.TabIndex = 8;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Consulta por Nome:";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::LojaGames.Properties.Resources.Files_New_File_icon2;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(135, 166);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(69, 36);
            this.btnNovo.TabIndex = 16;
            this.btnNovo.Text = "Novo    Produto ";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // plnProduto
            // 
            this.plnProduto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plnProduto.Controls.Add(this.label17);
            this.plnProduto.Controls.Add(this.btnSairGrid);
            this.plnProduto.Controls.Add(this.txtConsProduto);
            this.plnProduto.Controls.Add(this.label16);
            this.plnProduto.Controls.Add(this.dgvProdutoConsulta);
            this.plnProduto.Controls.Add(this.shapeContainer1);
            this.plnProduto.Location = new System.Drawing.Point(124, 95);
            this.plnProduto.Name = "plnProduto";
            this.plnProduto.Size = new System.Drawing.Size(468, 368);
            this.plnProduto.TabIndex = 33;
            this.plnProduto.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(68, 61);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(226, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Duplo clique abaixo para adicionar um produto";
            // 
            // btnSairGrid
            // 
            this.btnSairGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairGrid.Location = new System.Drawing.Point(349, 30);
            this.btnSairGrid.Name = "btnSairGrid";
            this.btnSairGrid.Size = new System.Drawing.Size(63, 23);
            this.btnSairGrid.TabIndex = 7;
            this.btnSairGrid.Text = "Sair";
            this.btnSairGrid.UseVisualStyleBackColor = true;
            this.btnSairGrid.Click += new System.EventHandler(this.btnSairGrid_Click);
            // 
            // txtConsProduto
            // 
            this.txtConsProduto.Location = new System.Drawing.Point(39, 32);
            this.txtConsProduto.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsProduto.Name = "txtConsProduto";
            this.txtConsProduto.Size = new System.Drawing.Size(303, 20);
            this.txtConsProduto.TabIndex = 6;
            this.txtConsProduto.Tag = "n";
            this.txtConsProduto.TextChanged += new System.EventHandler(this.txtConsCliente_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(40, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Consulta por nome:";
            // 
            // dgvProdutoConsulta
            // 
            this.dgvProdutoConsulta.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProdutoConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdutoConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutoConsulta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvProdutoConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoConsulta.Location = new System.Drawing.Point(81, 87);
            this.dgvProdutoConsulta.Name = "dgvProdutoConsulta";
            this.dgvProdutoConsulta.ReadOnly = true;
            this.dgvProdutoConsulta.Size = new System.Drawing.Size(309, 260);
            this.dgvProdutoConsulta.TabIndex = 0;
            this.dgvProdutoConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoConsulta_CellDoubleClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(468, 368);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(467, 367);
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 488);
            this.Controls.Add(this.plnProduto);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.gpbRecuperaProdutos);
            this.Controls.Add(this.btnAtualiza);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gpbProdutos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Estoque";
            this.Load += new System.EventHandler(this.frmEstoque_Load);
            this.gpbProdutos.ResumeLayout(false);
            this.gpbProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtde)).EndInit();
            this.gpbRecuperaProdutos.ResumeLayout(false);
            this.gpbRecuperaProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.plnProduto.ResumeLayout(false);
            this.plnProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.GroupBox gpbRecuperaProdutos;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudQtde;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plnProduto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSairGrid;
        private System.Windows.Forms.TextBox txtConsProduto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvProdutoConsulta;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label VerificaNovoOuAtualiza;
    }
}