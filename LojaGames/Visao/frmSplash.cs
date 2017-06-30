using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LojaGames.Visao
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            tmrStatus.Enabled = true;
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            if (prbStatus.Value < 100)
            {
                prbStatus.Value = prbStatus.Value + 5;
            }
            else
            {
                tmrStatus.Enabled = false;
                this.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void frmSplash_Load(object sender, EventArgs e)
        {

        }
    }
}
