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
    public partial class Form1 : Form
    {
        const int bateauCellule = 3;
        const int attaque = 4;

        int posDepartX;
        int posDepartY;

        bool firstClick = true;
        bool estCommencer = false;

        String [] ligneHeader={"A","B","C","D","E","F","G","H","I","J"};
        Bateau PorteAvion = new Bateau(5, "Porte-Avion");
        Bateau Croiseur = new Bateau(4, "Croiseur");
        Bateau ContreTorpille = new Bateau(3,"Contre-Torpilleur");
        Bateau SousMarin = new Bateau(3,"Sous-Marin");
        Bateau Torpilleur = new Bateau(2,"Torpilleur");
        int bateauChoisisLength;
        int[,] matriceAttaque = new int[10, 10];
        int[,] matricePosition = new int[10, 10];

        private void Form1_Load(object sender, EventArgs e)
        {
            bateauChoisisLength = PorteAvion.longueur;
        }
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
        //fait une attaque
        //pas finis
        private void BTN_Attack_Click(object sender, EventArgs e)
        {
            int posX = GridAttack.CurrentCell.ColumnIndex;
            int posY= GridAttack.CurrentCell.RowIndex;
            if (matriceAttaque[posX, posY] == 0)
            {
                //envoyer posx,posy
            }
            else
            {
                MessageBox.Show("Vous-avez déjà lancé une torpille ici");
            }

        }
        //place la grosseur du bateau choisis
        private void RBTN_Bateau_CheckedChanged(object sender, EventArgs e)
        {
            if(RBTN_Croiseur.Checked){
                bateauChoisisLength =Croiseur.longueur;
            }
            else if(RBTN_ContreTorpille.Checked){
                bateauChoisisLength = ContreTorpille.longueur;
            }
            else if(RBTN_SousMarin.Checked){
                bateauChoisisLength = SousMarin.longueur;
            }
            else if (RBTN_Torpilleur.Checked)
            {
                bateauChoisisLength = Torpilleur.longueur;
            }
            else {
                bateauChoisisLength = PorteAvion.longueur;
            }
        }

        //rentre les position des bateau dans la matrice et enleve le bouton et les radio button
        /*RESTE A PLACER LES BATEAU DANS LA MATRICE*/
        private void BTN_Place_Click(object sender, EventArgs e)
        {
            if (estPlace())
            {
                RBTN_PorteAvion.Checked = true;
                panel1.Visible = false;

                BTN_Place.Visible = false;
                BTN_replace.Visible = false;

                estCommencer = true;
                BTN_NouvellePartie.Visible = true;

                placerBateauMatrice();
            }
            else
            {
                MessageBox.Show("Placer tout les bateaux pour commencer la partie");
            }
        }
        //place les bateau dans la matrice
        private void placerBateauMatrice() {
            for (int i = 0; i < GridPlayer.RowCount; ++i)
            {
                for (int j = 0; j < GridPlayer.ColumnCount; ++j)
                {
                    if (GridPlayer.Rows[i].Cells[j].Style.BackColor == Color.Black)
                    {
                        matricePosition[i, j] = bateauCellule;
                    }
                }
            }
        }

        //retourne si tout les bateaux sont places
        //return true si tout les bateau sont place
        private bool estPlace()
        {
            return !RBTN_ContreTorpille.Enabled && !RBTN_Croiseur.Enabled && !RBTN_PorteAvion.Enabled && !RBTN_SousMarin.Enabled && !RBTN_Torpilleur.Enabled;
        }
        //creer une nouvelle partie !
        /*POUR LINSTANT IL NE FAIT QU AFFICHER LES RADIO BUTTON ET LE BUTTON PRET*/
        private void BTN_NouvellePartie_Click(object sender, EventArgs e)
        {
            BTN_NouvellePartie.Visible = false;
            panel1.Visible = true;
            BTN_Place.Visible = true;
            BTN_replace.Visible = true;

            enleverBateau();
            enabledCheckBox();

            estCommencer = false;
            firstClick = true;
        }
        private void enleverBateau() {
            for (int i = 0; i < GridPlayer.ColumnCount; ++i)
            {
                for (int y = 0; y < GridPlayer.RowCount; ++y)
                {
                    GridPlayer.Rows[i].Cells[y].Style.BackColor = Color.White;
                }
            }            
        }
        private void enabledCheckBox(){
            RBTN_PorteAvion.Enabled = true;
            RBTN_Croiseur.Enabled = true;
            RBTN_ContreTorpille.Enabled = true;
            RBTN_SousMarin.Enabled = true;
            RBTN_Torpilleur.Enabled = true;
        }
        private void GridPlayer_Click(object sender,EventArgs e)
        {
            if (!estCommencer && !estPlace())
            {
                if (firstClick)
                {
                    posDepartX = getposX();
                    posDepartY = getposY();
                    if (GridPlayer.Rows[posDepartY].Cells[posDepartX].Style.BackColor != Color.Black)
                    {
                        GridPlayer.Rows[posDepartY].Cells[posDepartX].Selected = false;
                        GridPlayer.Rows[posDepartY].Cells[posDepartX].Style.BackColor = Color.Gray;
                        choix(posDepartX, posDepartY);
                        firstClick = false;
                        //enleve le choix des bateau donc il ne peut pas en choisisr dautre lors du deuxieme click
                        panel1.Visible = false;
                    }
                    else
                    {
                        GridPlayer.ClearSelection();
                    }
                }
                else
                {
                    placerBateau();
                    if (firstClick)
                    {
                        enleverChoix();
                        panel1.Visible = true;
                        disableCheckBox();
                    }
                }
            }
            else
            {
                GridPlayer.ClearSelection();
            }

        }
        //disable les checkbox si il a ete place
        private void disableCheckBox(){
            if(RBTN_PorteAvion.Checked)
                RBTN_PorteAvion.Enabled=false;
            else if(RBTN_Croiseur.Checked)
                RBTN_Croiseur.Enabled=false;
            else if(RBTN_ContreTorpille.Checked)
                RBTN_ContreTorpille.Enabled=false;
            else if(RBTN_SousMarin.Checked)
                RBTN_SousMarin.Enabled=false;
            else if (RBTN_Torpilleur.Checked)
                RBTN_Torpilleur.Enabled = false;
            trouverFirstEnabled();
        }
        //trouve le premier checkbox pour le 
        private void trouverFirstEnabled() {
            if (RBTN_PorteAvion.Enabled)
                RBTN_PorteAvion.Checked = true;
            else if (RBTN_Croiseur.Enabled)
                RBTN_Croiseur.Checked = true;
            else if (RBTN_ContreTorpille.Enabled)
                RBTN_ContreTorpille.Checked = true;
            else if (RBTN_SousMarin.Enabled)
                RBTN_SousMarin.Checked = true;
            else if (RBTN_Torpilleur.Enabled)
                RBTN_Torpilleur.Checked = true;
            }
        //place le bateau selon lorientation choisis
        private void placerBateau() {
            int posSecondX = getposX();
            int posSecondY = getposY();
            int posFinX = 0;
            int posFinY = 0;
            //haut
            if (posDepartX == posSecondX && posDepartY - 1 == posSecondY && GridPlayer.Rows[posSecondY].Cells[posSecondX].Style.BackColor == Color.Green)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    GridPlayer.Rows[posDepartY - i].Cells[posDepartX].Style.BackColor = Color.Black;
                    posFinY = posDepartY-i;
                }
                posFinY = posDepartY - bateauChoisisLength-1;
                posFinX = posDepartX;
                firstClick = true;
            }
            //bas
            else if (posDepartX == posSecondX && posDepartY + 1 == posSecondY && GridPlayer.Rows[posSecondY].Cells[posSecondX].Style.BackColor == Color.Green)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    GridPlayer.Rows[posDepartY + i].Cells[posDepartX].Style.BackColor = Color.Black;
                }
                posFinY = posDepartY + bateauChoisisLength - 1;
                posFinX = posDepartX;
                firstClick = true;
            }
            //gauche
            else if (posDepartX - 1 == posSecondX && posDepartY == posSecondY && GridPlayer.Rows[posSecondY].Cells[posSecondX].Style.BackColor == Color.Green)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    GridPlayer.Rows[posDepartY].Cells[posDepartX - i].Style.BackColor = Color.Black;
                }
                posFinX = posDepartX - bateauChoisisLength - 1;
                posFinY = posDepartY;
                firstClick = true;
            }
            //droite
            else if (posDepartX + 1 == posSecondX && posDepartY == posSecondY && GridPlayer.Rows[posSecondY].Cells[posSecondX].Style.BackColor == Color.Green)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    GridPlayer.Rows[posDepartY].Cells[posDepartX + i].Style.BackColor = Color.Black;
                }
                firstClick = true;
            }
            posFinX = posDepartX + bateauChoisisLength - 1;
            posFinY = posDepartY;
            GridPlayer.Rows[posSecondY].Cells[posSecondX].Selected = false;
            initCoordoneebateau(posFinX, posFinY);
        }
        private void initCoordoneebateau(int finX, int finY)
        {

            if(RBTN_PorteAvion.Checked)
            {
                PorteAvion.debut.x = posDepartX;
                PorteAvion.debut.y = posDepartY;
                PorteAvion.fin.x = finX;
                PorteAvion.fin.y = finY;
            }
            else if(RBTN_ContreTorpille.Checked)
            {
                ContreTorpille.debut.x = posDepartX;
                ContreTorpille.debut.y = posDepartY;
                ContreTorpille.fin.x = finX;
                ContreTorpille.fin.y = finY;
            }
            else if(RBTN_Croiseur.Checked)
            {
                Croiseur.debut.x = posDepartX;
                Croiseur.debut.y = posDepartY;
                Croiseur.fin.x = finX;
                Croiseur.fin.y = finY; 
            }
            else if(RBTN_SousMarin.Checked)
            {
                SousMarin.debut.x = posDepartX;
                SousMarin.debut.y = posDepartY;
                SousMarin.fin.x = finX;
                SousMarin.fin.y = finY;                
            }
            else
            {
                Torpilleur.debut.x = posDepartX;
                Torpilleur.debut.y = posDepartY;
                Torpilleur.fin.x = finX;
                Torpilleur.fin.y = finY;    
            }
        }
        //enleve les carre vert
        private void enleverChoix() {
            if (posDepartY + 1 <GridPlayer.RowCount && GridPlayer.Rows[posDepartY + 1].Cells[posDepartX].Style.BackColor == Color.Green)
            GridPlayer.Rows[posDepartY+1].Cells[posDepartX].Style.BackColor = Color.White;
            if (posDepartY -1>=0 && GridPlayer.Rows[posDepartY - 1].Cells[posDepartX].Style.BackColor == Color.Green)
            GridPlayer.Rows[posDepartY-1].Cells[posDepartX].Style.BackColor=Color.White;
            if (posDepartX + 1< GridPlayer.RowCount && GridPlayer.Rows[posDepartY].Cells[posDepartX + 1].Style.BackColor == Color.Green)
            GridPlayer.Rows[posDepartY].Cells[posDepartX+1].Style.BackColor = Color.White;
            if (posDepartX -1 >=0 && GridPlayer.Rows[posDepartY].Cells[posDepartX - 1].Style.BackColor == Color.Green)
            GridPlayer.Rows[posDepartY].Cells[posDepartX-1].Style.BackColor=Color.White;
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
            //bas
            if (posY + bateauChoisisLength <= 10 && verifierChaqueCase(posX, posY,"Down"))
                GridPlayer.Rows[posY + 1].Cells[posX].Style.BackColor = Color.Green;

            if (posY - bateauChoisisLength >= -1 && verifierChaqueCase(posX,posY,"Up"))
                GridPlayer.Rows[posY - 1].Cells[posX].Style.BackColor = Color.Green;

            if (posX + bateauChoisisLength <= 10 && verifierChaqueCase(posX,posY,"Right"))
                GridPlayer.Rows[posY].Cells[posX+1].Style.BackColor = Color.Green;
            if (posX - bateauChoisisLength >= -1 && verifierChaqueCase(posX, posY, "Left"))
                GridPlayer.Rows[posY].Cells[posX-1].Style.BackColor = Color.Green;            
        }
        //verifie si il y a deja un bateau de placer
        private bool verifierChaqueCase(int posX, int posY,string Orientation) {
            if (Orientation == "Up") {
                for (int i = 0; i < bateauChoisisLength; ++i)
                    if (posY - i >= 0 && GridPlayer.Rows[posY - i].Cells[posX].Style.BackColor == Color.Black)
                    {
                        return false;
                }
            }
            else if (Orientation == "Down") {
                for (int i = 0; i < bateauChoisisLength; ++i){
                    if (posY + i < GridPlayer.RowCount && GridPlayer.Rows[posY + i].Cells[posX].Style.BackColor == Color.Black)
                        return false;
                }                
            }
            else if (Orientation == "Left") {
                for (int i = 0; i < bateauChoisisLength; ++i){
                    if (posX - i >= 0 && GridPlayer.Rows[posY].Cells[posX - i].Style.BackColor == Color.Black)
                        return false;
                }            
            }
            else if (Orientation == "Right"){
                for (int i = 0; i < bateauChoisisLength; ++i){
                    if (posX + i < GridPlayer.RowCount && GridPlayer.Rows[posY].Cells[posX + i].Style.BackColor == Color.Black)
                        return false;
                }
            }
            return true;
        }
        //enleve tout les bateau de la grille et permet de replacer les bateau
        private void BTN_replace_Click(object sender, EventArgs e)
        {
            RBTN_PorteAvion.Checked = true;
            firstClick = true;
            enabledCheckBox();
            enleverBateau();
            panel1.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sur de vouloir quitter?",
                         "Message de confirmation",
                         MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel=true;
            }
        }

        private void BTN_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
   }
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
    public class position{
      public int x;
      public int y;

        public position(){
            x=0;
            y=0;
        }
    };
}
