using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BateauDLL
{
    [Serializable]
    //Classe position contient un position en X et en Y.
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
        // classe du bateau, contient la longueur du bateaux (2,3,4 ou 5),son nom, leur position sur une matrice (x, y)
        // et s'il est touché.
        public int longueur { get; set; }
        public String nom { get; set; }
        public position [] cases;
        public bool [] estTouche;
        //constructeur paramétrique de bateau: Recoit la longueur (l) et le nom du bateau (N).
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
        //classe du joueur, contient le nom du joueur ( joueur 1 ou joueur 2) et les bateaux.
        public String Nom_;
        public Bateau PorteAvion;
        public Bateau Croiseur;
        public Bateau ContreTorpille;
        public Bateau SousMarin;
        public Bateau Torpilleur;

        //Constructeur paramétrique de joueur : Recoit le nom du joueur (joueur 1 ou joueur 2).
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
