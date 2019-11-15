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
    public partial class ReporteGanador : Form
    {
        public ReporteGanador()
        {
            InitializeComponent();
        }

        public DateTime Fecha { get; set; }
        private void ReporteGanador_Load(object sender, EventArgs e)
        {
            this.selectWinnerTableAdapter.Fill(this.dataSet1.SelectWinner, Fecha);
            this.reportViewer1.RefreshReport();
        }
    }
}
