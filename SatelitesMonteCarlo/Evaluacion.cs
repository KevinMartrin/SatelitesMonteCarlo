using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelitesMonteCarlo
{
    public class Evaluacion
    {
        public Evaluacion () { }

        public List<double> FuncionExponencial(double a, double b, int min, int max, Random randi)
        {
            Algoritmo aleatorio = new Algoritmo();
            int x = aleatorio.CSharpRandom(min, max, randi);
            double y = Math.Pow(a,x*b);

            List<double> listilla = new List<double>();
            listilla.Add(Convert.ToDouble(x));
            listilla.Add(y);

            return listilla;
        }
    }
}
