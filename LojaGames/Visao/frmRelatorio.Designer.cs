namespace LojaGames.Visao
{
    partial class frmRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorio));
            this.crvRelatorioGenerico = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRelatorioGenerico
            // 
            this.crvRelatorioGenerico.ActiveViewIndex = -1;
            this.crvRelatorioGenerico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRelatorioGenerico.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRelatorioGenerico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRelatorioGenerico.Location = new System.Drawing.Point(0, 0);
            this.crvRelatorioGenerico.Name = "crvRelatorioGenerico";
            this.crvRelatorioGenerico.Size = new System.Drawing.Size(492, 343);
            this.crvRelatorioGenerico.TabIndex = 0;
            // 
            // frmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 343);
            this.Controls.Add(this.crvRelatorioGenerico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSystem - Relatório de Produtos Cadastrados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelatorio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRelatorioGenerico;
    }
}