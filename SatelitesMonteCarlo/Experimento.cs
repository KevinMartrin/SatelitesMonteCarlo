using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelitesMonteCarlo
{
    public class Experimento
    {
        public Experimento () { }

        public List<double> vidaSatelite(double min, double max, Random randi)
        {

            int mini = Convert.ToInt32(min);
            int maxi = Convert.ToInt32(max);
            List <double> paneles = new List<double> ();
            
            for (int i = 0; i < 5; i++)
            {
                Algoritmo aleatorio = new Algoritmo ();
                paneles.Add(aleatorio.CuadradoMedio(mini,maxi, randi));
            }

            return paneles;
        }
    }
}
