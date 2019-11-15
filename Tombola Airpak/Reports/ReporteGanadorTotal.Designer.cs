namespace Tombola_Airpak.Reports
{
    partial class ReporteGanadorTotal
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGanadorTotal));
            this.selectTotalWinnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Tombola_Airpak.Data.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.selectTotalWinnerTableAdapter = new Tombola_Airpak.Data.DataSet1TableAdapters.SelectTotalWinnerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.selectTotalWinnerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectTotalWinnerBindingSource
            // 
            this.selectTotalWinnerBindingSource.DataMember = "SelectTotalWinner";
            this.selectTotalWinnerBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.selectTotalWinnerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tombola_Airpak.Reports.ReporteGanadorTotales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1054, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // selectTotalWinnerTableAdapter
            // 
            this.selectTotalWinnerTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteGanadorTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 661);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteGanadorTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteGanadorTotal";
            this.Load += new System.EventHandler(this.ReporteGanadorTotal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectTotalWinnerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Data.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource selectTotalWinnerBindingSource;
        private Data.DataSet1TableAdapters.SelectTotalWinnerTableAdapter selectTotalWinnerTableAdapter;
    }
}