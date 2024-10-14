using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatelitesMonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public void llenarGrid(int media)
        {
            //Paso 0: Numero de columnas
            string numeroColumna1 = "1";
            //string numeroColumna2 = "2";

            //Paso 1: Determinar la cantidad de columnas
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Media");

            //Paso 2: Recorrer el grid para cada fila y llenar de valores esperados
            for (int i = 0; i < 1; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = media;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Los numeros tienen que ser mayor que 0, no vacios");
                return;
            }

            List <int> vidas = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                Experimento satelite = new Experimento();
                vidas.Add(satelite.vidaSatelite(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), rand));
            }

            llenarGrid(Convert.ToInt32(vidas.Average()));

        }
    }
}
