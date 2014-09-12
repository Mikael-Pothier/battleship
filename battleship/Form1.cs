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
            for (int i = 0; i < GridPlayer.ColumnCount; ++i){
                for (int y = 0; y < GridPlayer.RowCount; ++y) {
                    GridPlayer.Rows[i].Cells[y].Style.BackColor = Color.White;
                }
            }
        }

        private void GridPlayer_Click(object sender,EventArgs e)
        {
            int posX = getposX();
            int posY = getposY();
            GridPlayer.Rows[posY].Cells[posX].Selected = false;
            GridPlayer.Rows[posY].Cells[posX].Style.BackColor = Color.Gray;
            choix(posX, posY);

        }
      //donne la posistion de la colone choisis du gridplayer
        private int getposX() {
            return GridPlayer.CurrentCell.ColumnIndex;
        }
        //donne la posistion de la row choisis du gridplayer
        private int getposY() {
            return GridPlayer.CurrentCell.RowIndex;
        }
        //place les choix possibles lorseque l'on click pour placer un bateau(en croix)
        private void choix(int posX,int posY) { 
            if(posY + bateauChoisisLength <=10){
                GridPlayer.Rows[posY + 1].Cells[posX].Style.BackColor = Color.Green;
            }
            if(posY-bateauChoisisLength>=-1){
                GridPlayer.Rows[posY - 1].Cells[posX].Style.BackColor = Color.Green;                
            }
            if(posX+bateauChoisisLength <=10){
                GridPlayer.Rows[posY].Cells[posX+1].Style.BackColor = Color.Green;            
            }
            if (posX - bateauChoisisLength>=-1)
            {
                GridPlayer.Rows[posY].Cells[posX-1].Style.BackColor = Color.Green;            
            }
        }
    }
}
