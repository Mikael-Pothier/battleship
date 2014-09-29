using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BateauDLL
{
    public class Bateau
    {
        public int longueur { get; set; }
        public String nom { get; set; }
        public position debut = new position();
        public position fin = new position();
        public Bateau(int l, String N)
        {
            longueur = l;
            nom = N;
            debut.x = 0;
            debut.y = 0;
            fin.x = 0;
            fin.y = 0;
        }
    };
    public class position
    {
        public int x;
        public int y;

        public position()
        {
            x = 0;
            y = 0;
        }
    };
}
