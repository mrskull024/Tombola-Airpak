using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tombola_Airpak.Reports
{
    public partial class ReporteGanadorTotal : Form
    {
        public ReporteGanadorTotal()
        {
            InitializeComponent();
        }

        private void ReporteGanadorTotal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.SelectTotalWinner' Puede moverla o quitarla según sea necesario.
            this.selectTotalWinnerTableAdapter.Fill(this.dataSet1.SelectTotalWinner);
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.SelectTotalWinner' Puede moverla o quitarla según sea necesario.
            this.selectTotalWinnerTableAdapter.Fill(this.dataSet1.SelectTotalWinner);

            this.reportViewer1.RefreshReport();
        }
    }
}
