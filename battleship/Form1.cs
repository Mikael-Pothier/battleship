using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    enum bateauLength{
        PorteAvion=5,
        Croisseur=4,
        ContreTorpilleur=3,
        SousMarin=3,
        Torpilleur=2
    };
    
    public partial class Form1 : Form
    {
        String [] ligneHeader={"A","B","C","D","E","F","G","H","I","J"};
        int  bateauChoisisLength = (int)bateauLength.PorteAvion;
    
        public Form1()
        {
            InitializeComponent();
            createGrid();
            RBTN_PorteAvion.Checked = true;
        }
        private void createGrid() {
            for (int i = 0; i < GridAttack.ColumnCount; ++i) {
                GridAttack.Rows.Add();              
                GridAttack.Rows[i].HeaderCell.Value = ligneHeader[i];
                GridPlayer.Rows.Add();
                GridPlayer.Rows[i].HeaderCell.Value = ligneHeader[i];
            }
        }

        private void BTN_Attack_Click(object sender, EventArgs e)
        {

        }
        //place la grosseur du bateau choisis
        private void RBTN_Bateau_CheckedChanged(object sender, EventArgs e)
        {
            if(RBTN_Croiseur.Checked){
                bateauChoisisLength = (int)bateauLength.Croisseur;
            }
            else if(RBTN_ContreTorpille.Checked){
                bateauChoisisLength = (int)bateauLength.ContreTorpilleur;
            }
            else if(RBTN_SousMarin.Checked){
                bateauChoisisLength = (int)bateauLength.SousMarin;
            }
            else if (RBTN_Torpilleur.Checked)
            {
                bateauChoisisLength = (int)bateauLength.Torpilleur;
            }
            else {
                bateauChoisisLength = (int)bateauLength.PorteAvion;
            }
        }

        //rentre les position des bateau dans la matrice et enleve le bouton et les radio button
        /*RESTE A PLACER LES BATEAU DANS LA MATRICE*/
        private void BTN_Place_Click(object sender, EventArgs e)
        {
            RBTN_PorteAvion.Checked=true;
            panel1.Visible = false;
            BTN_Place.Visible = false;
            BTN_NouvellePartie.Visible = true;
        }
        //creer une nouvelle partie !
        /*POUR LINSTANT IL NE FAIT QU AFFICHER LES RADIO BUTTON ET LE BUTTON PRET*/
        private void BTN_NouvellePartie_Click(object sender, EventArgs e)
        {
            BTN_NouvellePartie.Visible = false;
            panel1.Visible = true;
            BTN_Place.Visible = true;
        }
    }
}
