using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System;

namespace Tombola_Airpak.ExcelFile
{
    public partial class UploadExcelinBD : Form
    {
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.CadenaDeConexion);
        public UploadExcelinBD()
        {
            InitializeComponent();
            btnUploadExcel.Visible = false;

            if(txtFilePath.Text == "")
            {
                lblStatusUploadExcel.ForeColor = System.Drawing.Color.Red;
                lblStatusUploadExcel.Text = "La ruta del Archivo Excel esta: Vacio y Fallando";
            }
        }

        private void btnFindExcel_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.Abort)
            {
                return;
            }
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            txtFilePath.Text = openFileDialog.FileName.ToString();
            lblStatusUploadExcel.ForeColor = System.Drawing.Color.Green;
            lblStatusUploadExcel.Text = " La ruta del Archivo Excel esta: OK";
            btnUploadExcel.Visible = true;
        }
        
        public void ImportDataFromExcelSheet(string excelFilePath)
        {
            string sqltable = "TombolaAP";
            string myExcelDataQuery = string.Format("SELECT [ID],[FECHA],[NOMBRES],[DOCUMENTO],[TIPO_TX],[DIRECCION],[TELEFONO],[MTCN],[AGENCIA] FROM [{0}]", "Hoja1$");
            try
            {
                string sExcelConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 12.0;HDR=YES;'");
                sqlConnection.Open();
                OleDbConnection oleDbConnection = new OleDbConnection(sExcelConnectionString);
                OleDbCommand oleDbCommand = new OleDbCommand(myExcelDataQuery, oleDbConnection);
                oleDbConnection.Open();
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();

                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection);
                sqlBulkCopy.DestinationTableName = sqltable;

                while (oleDbDataReader.Read())
                {
                    sqlBulkCopy.WriteToServer(oleDbDataReader);
                }
                oleDbDataReader.Close();
                oleDbConnection.Close();
                sqlConnection.Close();

                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM dbo.TombolaAP", sqlConnection);
                sqlConnection.Open();
                int countData = (int)sqlCommand.ExecuteScalar();

                MessageBox.Show("Se ha importado Correctamente la Hoja con un total de: " + countData + " registros a la base de datos");
                sqlConnection.Close();

            }
            catch(Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error critico en la importado, lea los siguiente detalles: " + ex.Message);
                sqlConnection.Close();
            }
        }

        private void btnUploadExcel_Click(object sender, System.EventArgs e)
        {
            ImportDataFromExcelSheet(txtFilePath.Text);
        }

        private void linklErrasePreviousData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("TRUNCATE TABLE dbo.TombolaAP", sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Datos Anteriores eliminados Exitosamente");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error fatal al tratar de borrar los datos Anteriores, consulte el estado en: " + ex);
            }  
            
        }
    }
}
