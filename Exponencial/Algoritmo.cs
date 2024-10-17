using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelitesMonteCarlo
{
    public class Algoritmo
    {
        public Algoritmo() { }
        public int CuadradoMedio(int min, int max, Random numero_aleatorio)
        {
            List<int> lista = new List<int>();

            int num_aleatorio = numero_aleatorio.Next(min, max);
            int col1 = num_aleatorio;
            int n = Convert.ToString(col1).Length;
            int c = 0;
            int col4 = col1;
            while (c < 1000 && !(col4 >= min && col4 <= max))
            {
                int col2 = col1 * col1;
                if (Convert.ToString(col2).Length <= 2)
                {
                    col4 = col2;
                }
                else
                {
                    int col3 = Convert.ToInt32(Convert.ToString(col2).Substring(1, Convert.ToString(col2).Length - 1));
                    if (Convert.ToString(col3).Length <= 1)
                    {
                        col4 = col3;
                    }
                    else
                    {
                        col4 = Convert.ToInt32(Convert.ToString(col3).Substring(0, Convert.ToString(col3).Length - 1));
                    }
                }

                lista.Add(col4);

                col1 = col4;
                c++;
            }

            int numerito = num_aleatorio;
            foreach (int i in lista)
            {
                if (i >= min && i <= max)
                {
                    numerito = i;
                }
            }

            return numerito;
        }
        public int CSharpRandom(int min, int max, Random numero_aleatorio)
        {
            int numerito = numero_aleatorio.Next(min, max);
            return numerito;
        }
    }
}
