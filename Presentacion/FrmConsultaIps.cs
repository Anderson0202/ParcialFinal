using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace Presentacion
{
    public partial class FrmConsultaIps : Form
    {
        private IpsService IpsService;
        private ServicioService servicioService;
        private string ConnectionString;

        List<Ips> Ipses = new List<Ips>();
        public FrmConsultaIps()
        {
            InitializeComponent();

            ConnectionString = ConfigConnection.connectionString;
            //CmbIps.Text = "Laboratorio Yesenia Ovalle";
            //CmbIps.Text = "Laboratorio Nacy Florez";
            //CmbIps.Text = "Laboratorio Cristiam Gram";

            IpsService = new IpsService(ConnectionString);
            servicioService = new ServicioService(ConnectionString);
            Ipses = IpsService.ConsultarTodosBD();
            foreach (Ips item in Ipses)
            {
                CmbIps.Items.Add(item.NombreIps);
            }
        }

        public void AbrirArchivo()
        {

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {
                string file = openFile.FileName;
                List<Servicio> servicios = servicioService.ConsultarTodaLaLista(file);
                //MessageBox.Show(mensaje);
                servicioService.ValidarIps(servicios, Ipses[CmbIps.SelectedIndex].IdIps);
                if(servicioService.ServicioIpsIncorrecto.Count != 0)
                {
                    MessageBox.Show("Cantidad de servicios con el codigo de la ips incorrecto: " + servicioService.ServicioIpsIncorrecto.Count);
                }
                else
                {
                    if (true)
                    {

                    }
                }
            }

        }

        private bool EsVacio()
        {
            if (CmbIps.Text == "")
            {
                MessageBox.Show("Seleccione la IPS");
                return true;
            }
            return false;
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
            if (!EsVacio())
            {
                AbrirArchivo();
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void VIGENCIA_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
