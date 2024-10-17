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

        public void llenarGrid(List<double> aleatorios, List<double> resultados)
        {
            int n = Convert.ToInt32(textBox3.Text);
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            //Paso 0: Numero de columnas
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";
            string numeroColumna3 = "3";

            //Paso 1: Determinar la cantidad de columnas
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Replica");
            dataGridView1.Columns.Add(numeroColumna2, "x");
            dataGridView1.Columns.Add(numeroColumna3, "f(x)");

            //Paso 2: Recorrer el grid para cada fila y llenar de valores esperados
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = i+1;
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = aleatorios[i];
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna3) - 1].Value = resultados[1];
            }

            double esti = 0;
            foreach (double i in resultados)
            {
                esti += i;
            }
            double nueva_esti = esti * ((b - 1) / n);

            dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[Int32.Parse(numeroColumna1) - 1].Value = "Estimacion de la integral";
            dataGridView1.Rows[n].Cells[Int32.Parse(numeroColumna2) - 1].Value = nueva_esti;



        }

        //----------------------------------Elementos--------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("Los numeros ingresados tienen que ser mayor que 0, las celdas no pueden estar vacias");
                return;
            }

            int n = Convert.ToInt32(textBox3.Text);

            List<double> resultados = new List<double>();
            List<double> aleatorios = new List<double>();
            double fx = 0;
            double ale = 0;
            Random rand = new Random();
            Evaluacion resultado = new Evaluacion();
            for (int i = 0; i < n; i++)
            {
                fx = resultado.FuncionExponencial(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), rand)[1];
                ale = resultado.FuncionExponencial(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), rand)[0];
                resultados.Add(fx);
                aleatorios.Add(ale);
            }

            llenarGrid(aleatorios, resultados);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            descargarExcel(dataGridView1);
        }
    }
}
