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

namespace Presentacion
{
    public partial class FrmConsultaIps : Form
    {
        public FrmConsultaIps()
        {
            InitializeComponent();
        }

        public void AbrirArchivo()
        {

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {
                string file = openFile.FileName;
                string mensaje = LiquidacionService.Guardar(file); // Crear la clase LiquidacionService y el método guardar
                MessageBox.Show(mensaje);
            }

        }

    }
}
