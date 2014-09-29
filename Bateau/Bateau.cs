using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BateauDLL
{
    [Serializable]
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

    [Serializable]
    public class Bateau
    {
        public int longueur { get; set; }
        public String nom { get; set; }
        public position [] cases;
        public bool [] estTouche;
        public Bateau(int l, String N)
        {
            longueur = l;
            nom = N;
            estTouche = new bool[l];
            cases = new position[l];
            for (int i=0;i<cases.Length;++i)
                cases[i]=new position();
        }
    };

    [Serializable]
    public class Joueur
    {
        public String Nom_;
        public Bateau PorteAvion;
        public Bateau Croiseur;
        public Bateau ContreTorpille;
        public Bateau SousMarin;
        public Bateau Torpilleur;

        public Joueur(String Nom) {
            Nom_ = Nom;
            PorteAvion = new Bateau(5, "Porte-Avion");
            Croiseur = new Bateau(4, "Croiseur");
            ContreTorpille = new Bateau(3, "Contre-Torpilleur");
            SousMarin = new Bateau(3, "Sous-Marin");
            Torpilleur = new Bateau(2, "Torpilleur");
        }
    };
}
