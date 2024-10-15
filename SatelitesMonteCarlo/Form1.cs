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

        //----------------------------------Funciones--------------------------------
        public void descargarExcel(DataGridView data)
        {
            //Paso 0: Instalar complemento de Excel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            //Paso 1: Contruir columnas y los nombres de las cabeceras
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }

            //Paso 2: Construir filas y llenar valores
            int indiceFilas = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            //Paso 3: Visibilidad
            exportarExcel.Visible = true;
        }

        public void llenarGrid(List<List<int>> paneles, List<int> vidas)
        {
            int n = Convert.ToInt32(textBox1.Text);
            //Paso 0: Numero de columnas
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";
            string numeroColumna3 = "3";
            string numeroColumna4 = "4";
            string numeroColumna5 = "5";
            string numeroColumna6 = "6";
            string numeroColumna7 = "7";

            //Paso 1: Determinar la cantidad de columnas
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Experimento");
            dataGridView1.Columns.Add(numeroColumna2, "Panel 1");
            dataGridView1.Columns.Add(numeroColumna3, "Panel 2");
            dataGridView1.Columns.Add(numeroColumna4, "Panel 3");
            dataGridView1.Columns.Add(numeroColumna5, "Panel 4");
            dataGridView1.Columns.Add(numeroColumna6, "Panel 5");
            dataGridView1.Columns.Add(numeroColumna7, "X ( i )");

            //Paso 2: Recorrer el grid para cada fila y llenar de valores esperados
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = i+1;
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = paneles[i][0];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna3) - 1].Value = paneles[i][1];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna4) - 1].Value = paneles[i][2];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna5) - 1].Value = paneles[i][3];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna6) - 1].Value = paneles[i][4];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna7) - 1].Value = vidas[i];
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[6].Cells[Int32.Parse(numeroColumna1) - 1].Value = "Promedio";
            dataGridView1.Rows[6].Cells[Int32.Parse(numeroColumna7) - 1].Value = vidas.Average();

            int media = Convert.ToInt32(vidas.Average());
            int desvi = 0;
            foreach (int i in vidas)
            {
                desvi += (i * i)/(n * (n - 1))/ (media ^ 2) / (n - 1);
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[7].Cells[Int32.Parse(numeroColumna1) - 1].Value = "Sn";
            dataGridView1.Rows[7].Cells[Int32.Parse(numeroColumna7) - 1].Value = desvi;

        }

        //----------------------------------Elementos--------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Los numeros tienen que ser mayor que 0, no vacios");
                return;
            }

            int n = Convert.ToInt32(textBox1.Text);

            List<int> vidas = new List<int>();
            List<List<int>> todosPaneles = new List<List<int>>();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                Experimento satelite = new Experimento();
                List<int> paneles = satelite.vidaSatelite(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), rand);
                paneles.Sort();
                vidas.Add(paneles[3]);
                todosPaneles.Add(paneles);
            }

            llenarGrid(todosPaneles,vidas);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            descargarExcel(dataGridView1);
        }
    }
}
