using System;
using System.Data;
using Tombola_Airpak.ExcelFile;
using Tombola_Airpak.Reports;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Tombola_Airpak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string txtPath = Path.Combine(Application.StartupPath, "Premio.txt");
            string texto = File.ReadAllText(txtPath);
            lblPremio.Text = texto;
        }

        Random random = new Random();
        Random random2 = new Random();
        int VueltasTimerTick = 0;
        string AlmacenarCadena;
        string CadenaSet = Properties.Settings.Default.CadenaDeConexion;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if(VueltasTimerTick <= 35000)
            {
                timer1.Start();
            }
            else
            {
                VueltasTimerTick = 0;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(VueltasTimerTick <= 35000)
            {
                VueltasTimerTick += 1000;
                txt1.Text = random.Next(0, 9).ToString();
                txt2.Text = random.Next(1, 9).ToString();
                txt3.Text = random.Next(1, 9).ToString();
                txt4.Text = random.Next(1, 9).ToString();
                txt5.Text = random.Next(1, 9).ToString();
                txt6.Text = random.Next(1, 9).ToString();
                txt7.Text = random.Next(1, 9).ToString();
                txt8.Text = random.Next(1, 9).ToString();
                txt9.Text = random.Next(1, 9).ToString();
                txt10.Text = random.Next(1, 9).ToString();
            }
            else
            {
                timer1.Stop();
                SqlConnection sqlConnection = new SqlConnection(CadenaSet);

                SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM dbo.TombolaAP", sqlConnection);
                sqlConnection.Open();
                int countData = (int)sqlCommand2.ExecuteScalar();

                //de 1 hasta n datos
                string cadenaRandom = random2.Next(1, countData).ToString();
                sqlConnection.Close();

                //empezamos la conexion SQL para obtener al ganador por medio de los
                //datos en la tabla correspondiente
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT TOP 1 * FROM dbo.TombolaAP WHERE id=" + cadenaRandom, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataSet dataSet = new DataSet();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);

                //Mostramos los datos del ganador en los label mediante los datos recolectados
                //por el dataset con la consulta anterior
                lbliD.Text = dataSet.Tables[0].Rows[0]["ID"].ToString();
                lblFecha.Text = dataSet.Tables[0].Rows[0]["FECHA"].ToString();
                lblNombres.Text = dataSet.Tables[0].Rows[0]["NOMBRES"].ToString();
                lblDocumento.Text = dataSet.Tables[0].Rows[0]["DOCUMENTO"].ToString();
                lblTipoTransaccion.Text = dataSet.Tables[0].Rows[0]["TIPO_TX"].ToString();
                lblDireccion.Text = dataSet.Tables[0].Rows[0]["DIRECCION"].ToString();
                lblTelefono.Text = dataSet.Tables[0].Rows[0]["TELEFONO"].ToString();
                lblMTCN.Text = dataSet.Tables[0].Rows[0]["MTCN"].ToString();
                lblAgencia.Text = dataSet.Tables[0].Rows[0]["AGENCIA"].ToString();

                //Guardamos el mtcn para splitearlo en 10 partes distintas y mostrarlas en 
                //los textboxs correspndientes a los numeros del sorteo
                AlmacenarCadena = lblMTCN.Text;
                char[] mtcn = AlmacenarCadena.ToCharArray();
                txt1.Text = mtcn[0].ToString();
                txt2.Text = mtcn[1].ToString();
                txt3.Text = mtcn[2].ToString();
                txt4.Text = mtcn[3].ToString();
                txt5.Text = mtcn[4].ToString();
                txt6.Text = mtcn[5].ToString();
                txt7.Text = mtcn[6].ToString();
                txt8.Text = mtcn[7].ToString();
                txt9.Text = mtcn[8].ToString();
                txt10.Text = mtcn[9].ToString();

                //desabilitamos el boton de iniciar la tombola hasta que registramos al ganador
                btnIniciar.Enabled = false;
            }
        }

        int HayGanador = 0;
        private void btnGuardarGanador_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(CadenaSet);
            sqlConnection.Open();
            
            //verficamos que el ganador no exista en nuestros registro de la tabla de Ganadores
            if(HayGanador == 1)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Ganadores WHERE ORDEN=" + lbliD.Text.ToString(), sqlConnection);
                DialogResult dialogResult = MessageBox.Show("Esta persona ya ha resultado ganadora", "Desea Volver a Iniciar la Tombola", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                //Si el dialog result es OK significa que el ganador existe por ende se reiniciar la tombola
                if(dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }

            }
            //Si el ganador no existe, se procede a guardar el nuevo registro del ganador
            else
            {
                string Insertar = "INSERT INTO Ganadores VALUES(" + lbliD.Text.Trim() + ", " + "'" + lblFecha.Text.Trim() + "'," + "'" + lblNombres.Text.Trim() + "'," + "'" + lblDocumento.Text.Trim() + "'," + "'" + lblTipoTransaccion.Text.Trim() + "'," + "'" + lblDireccion.Text.Trim() + "'," + "'" + lblTelefono.Text.Trim() + "'," + "'" + lblMTCN.Text.Trim() + "'," + "'" + lblAgencia.Text.Trim() + "'," + "'" + lblPremio.Text.Trim() + "'," + "GETDATE()" + ")";
                SqlCommand sqlCommand = new SqlCommand(Insertar, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Ganador Insertado Correctamente");
            }

            //Cerramos la conexion y mostramos un mensaje en caso de seguir utilizando la tombola
            sqlConnection.Close();
            DialogResult dialogResult2 = MessageBox.Show("Para Elegir Otro Ganador debe Reiniciar la Tómbola", "[Pregunta del Sistema]", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult2 == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnReiniciarTombola_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            UploadExcelinBD uploadExcelinBD = new UploadExcelinBD();
            uploadExcelinBD.Show();
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            ReporteGanador reporteGanador = new ReporteGanador();
            reporteGanador.Fecha = dateTimePicker1.Value;
            reporteGanador.Show();
        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            ReporteGanadorTotal ganadorTotal = new ReporteGanadorTotal();
            ganadorTotal.Show();
        }

        private void btnEditPrize_Click(object sender, EventArgs e)
        {
            lblPremio.ReadOnly = false;
       
        }

        private void lblPremio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                lblPremio.ReadOnly = true;
                string txtPath = Path.Combine(Application.StartupPath, "Premio.txt");
                string[] lineasTxt = File.ReadAllLines(txtPath);
                lineasTxt[0] = lblPremio.Text;
                File.WriteAllLines(txtPath, lineasTxt);
                btnIniciar.Focus();
                this.Refresh();
            }
        }    
    }
}
