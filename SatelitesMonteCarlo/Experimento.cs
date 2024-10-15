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

        public List<int> vidaSatelite(int min, int max, Random randi)
        {
            List <int> paneles = new List<int> ();
            
            for (int i = 0; i < 5; i++)
            {
                Algoritmo aleatorio = new Algoritmo ();
                paneles.Add(aleatorio.CuadradoMedio(min, max, randi));
            }

            return paneles;
        }
    }
}
