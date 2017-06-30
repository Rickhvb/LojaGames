using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LojaGames.Modelo;
using LojaGames.Relatorio;

namespace LojaGames.Visao
{
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            DataTable dtApoio = clsProduto.recuperarTodos();
            rptProduto objRelatorio = new rptProduto();
            objRelatorio.SetDataSource(dtApoio);
            crvRelatorioGenerico.ReportSource = objRelatorio;
            crvRelatorioGenerico.Refresh();
        }
    }
}
