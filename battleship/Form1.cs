using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BateauDLL;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace battleship
{
    public partial class Form1 : Form
    {
        static Socket sck;

        const int bateauCellule = 3;
        const int touche = 1;
        const int manque = 2;

        int posDepartX;
        int posDepartY;

        bool firstClick = true;
        bool estCommencer = false;

        String [] ligneHeader={"A","B","C","D","E","F","G","H","I","J"};
        Joueur player = new Joueur("player1");
        int bateauChoisisLength;
        int[,] matriceAttaque = new int[10, 10];
        int[,] matricePosition = new int[10, 10];

        private void Form1_Load(object sender, EventArgs e)
        {
            bateauChoisisLength = player.PorteAvion.longueur;
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
            bool aAttaque=envoyerAttaque();
            if (aAttaque)
            {
                BTN_Attack.Enabled = false;
                String message = null;
                message = lire();
                traiterMessageAattaque(message);
                if (message != "vous avez gagnes" && message != "vous avez perdus")
                {
                    message = lire();
                    traiterMessageEteAttaque(message);
                    BTN_Attack.Enabled = true;
                }
                else
                {
                    BTN_Attack.Enabled = false;
                    envoyerMessage("ok");
                    newGame();
                }
            }
        }
        private void envoyerMessage(String message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            sck.Send(data);       
        }
        private bool envoyerAttaque()
        {
            int posX = GridAttack.CurrentCell.ColumnIndex;
            int posY = GridAttack.CurrentCell.RowIndex;
            GridAttack.Rows[posY].Cells[posX].Selected = false;
            if (GridAttack.Rows[posY].Cells[posX].Style.BackColor == Color.Empty)
            {
                position pos = new position();
                pos.x = posX;
                pos.y = posY;
                byte[] data;
                BinaryFormatter b = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    b.Serialize(stream, pos);
                    data = stream.ToArray();
                }
                sck.Send(data);
            }
            else
            {
                MessageBox.Show("Vous-avez déjà lancé une torpille ici");
                return false;
            }
            return true;
        }
        private void traiterMessageAattaque(String message)
        {
            String[] data = message.Split(new char[]{','});
            int number;
            if (int.TryParse(data[0], out number))
            {
                if (int.Parse(data[0]) == touche)
                {
                    GridAttack.Rows[int.Parse(data[2])].Cells[int.Parse(data[1])].Style.BackColor = Color.Red;
                }
                else
                {
                    GridAttack.Rows[int.Parse(data[2])].Cells[int.Parse(data[1])].Style.BackColor = Color.Blue;
                }
                MessageBox.Show(data[3]);
            }
            else 
            {
                MessageBox.Show(data[0]);
            }
        }
        private void traiterMessageEteAttaque(String message)
        {
            String[] data = message.Split(new char[] { ',' });
            int number;
            if (int.TryParse(data[0], out number))
            {
                if (int.Parse(data[0]) == touche)
                {
                    GridPlayer.Rows[int.Parse(data[2])].Cells[int.Parse(data[1])].Style.BackColor = Color.Red;
                }
                else
                {
                    GridPlayer.Rows[int.Parse(data[2])].Cells[int.Parse(data[1])].Style.BackColor = Color.Blue;
                }
                MessageBox.Show(data[3]);
            }
            else 
            {
                MessageBox.Show(data[0]);
                newGame();
            }
            
        }
        private String recevoirResultat()
        {
            byte[] buff = new byte[sck.SendBufferSize];
            int bytesRead = sck.Receive(buff);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buff[i];
            }
            string strData = Encoding.ASCII.GetString(formatted);
            return strData;
        }
        //place la grosseur du bateau choisis
        private void RBTN_Bateau_CheckedChanged(object sender, EventArgs e)
        {
            if(RBTN_Croiseur.Checked){
                bateauChoisisLength =player.Croiseur.longueur;
            }
            else if(RBTN_ContreTorpille.Checked){
                bateauChoisisLength = player.ContreTorpille.longueur;
            }
            else if(RBTN_SousMarin.Checked){
                bateauChoisisLength = player.SousMarin.longueur;
            }
            else if (RBTN_Torpilleur.Checked)
            {
                bateauChoisisLength = player.Torpilleur.longueur;
            }
            else {
                bateauChoisisLength = player.PorteAvion.longueur;
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
                EnvoyerBateauServeur();

                String message = null;
                message = lire();
                MessageBox.Show(message);
                BTN_Attack.Enabled = true;
                message = lire();
                if (message == "2")
                {
                    BTN_Attack.Enabled = false;
                    message = lire();
                    traiterMessageEteAttaque(message);
                    BTN_Attack.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Placer tout les bateaux pour commencer la partie");
            }
        }
        private String lire()
        {
            String message = null;
            do
            {
                message = recevoirResultat();
            } while (message == null);
            return message;
        }
        private void EnvoyerBateauServeur()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("172.17.104.114"), 1234);
            try
            {
                sck.Connect(localEndPoint);
            }
            catch
            {
                MessageBox.Show("Erreur de connexion");
            }

            if(sck.Connected)
            {
                byte[] data;
                BinaryFormatter b = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    b.Serialize(stream, player);
                    data = stream.ToArray();
                }
                sck.Send(data);
            }
        }

        private String GetBateauString()
        {
            return null;
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
            envoyerMessage("ok");
            newGame();
        }
        private void newGame()
        {
            BTN_NouvellePartie.Visible = false;
            panel1.Visible = true;
            BTN_Place.Visible = true;
            BTN_replace.Visible = true;

            sck.Close();

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
                    GridPlayer.Rows[i].Cells[y].Style.BackColor = Color.Empty;
                    GridAttack.Rows[i].Cells[y].Style.BackColor = Color.Empty;
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
            initCoordoneebateau();
        }
        private int getOrientation() { 
            //haut
            if (posDepartX == getposX() && posDepartY - 1 == getposY())
                return 1;
            //bas
            else if (posDepartX == getposX() && posDepartY + 1 == getposY())
                return 2;
            //gauche
            else if (posDepartX - 1 == getposX() && posDepartY == getposY())
                return 3;
            //droite
            else
                return 4;
        }
        private void initCoordoneebateau()
        {
            int ori = getOrientation();

            if(RBTN_PorteAvion.Checked)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    if(ori==1)
                    {
                        player.PorteAvion.cases[i].x = posDepartX;
                        player.PorteAvion.cases[i].y = posDepartY-i;
                    }
                    else if (ori == 2) 
                    {
                        player.PorteAvion.cases[i].x = posDepartX;
                        player.PorteAvion.cases[i].y = posDepartY+i;                    
                    }
                    else if (ori == 3)
                    {
                        player.PorteAvion.cases[i].x = posDepartX-i;
                        player.PorteAvion.cases[i].y = posDepartY;
                    }
                    else 
                    {
                        player.PorteAvion.cases[i].x = posDepartX+i;
                        player.PorteAvion.cases[i].y = posDepartY;                   
                    }
                }
            }
            else if (RBTN_ContreTorpille.Checked)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    if (ori == 1)
                    {
                        player.ContreTorpille.cases[i].x = posDepartX;
                        player.ContreTorpille.cases[i].y = posDepartY - i;
                    }
                    else if (ori == 2)
                    {
                        player.ContreTorpille.cases[i].x = posDepartX;
                        player.ContreTorpille.cases[i].y = posDepartY + i;
                    }
                    else if (ori == 3)
                    {
                        player.ContreTorpille.cases[i].x = posDepartX - i;
                        player.ContreTorpille.cases[i].y = posDepartY;
                    }
                    else
                    {
                        player.ContreTorpille.cases[i].x = posDepartX + i;
                        player.ContreTorpille.cases[i].y = posDepartY;
                    }
                }
            }
            else if (RBTN_Croiseur.Checked)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    if (ori == 1)
                    {
                        player.Croiseur.cases[i].x = posDepartX;
                        player.Croiseur.cases[i].y = posDepartY - i;
                    }
                    else if (ori == 2)
                    {
                        player.Croiseur.cases[i].x = posDepartX;
                        player.Croiseur.cases[i].y = posDepartY + i;
                    }
                    else if (ori == 3)
                    {
                        player.Croiseur.cases[i].x = posDepartX - i;
                        player.Croiseur.cases[i].y = posDepartY;
                    }
                    else
                    {
                        player.Croiseur.cases[i].x = posDepartX + i;
                        player.Croiseur.cases[i].y = posDepartY;
                    }
                }
            }
            else if (RBTN_SousMarin.Checked)
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    if (ori == 1)
                    {
                        player.SousMarin.cases[i].x = posDepartX;
                        player.SousMarin.cases[i].y = posDepartY - i;
                    }
                    else if (ori == 2)
                    {
                        player.SousMarin.cases[i].x = posDepartX;
                        player.SousMarin.cases[i].y = posDepartY + i;
                    }
                    else if (ori == 3)
                    {
                        player.SousMarin.cases[i].x = posDepartX - i;
                        player.SousMarin.cases[i].y = posDepartY;
                    }
                    else
                    {
                        player.SousMarin.cases[i].x = posDepartX + i;
                        player.SousMarin.cases[i].y = posDepartY;
                    }
                }
            }
            else
            {
                for (int i = 0; i < bateauChoisisLength; ++i)
                {
                    if (ori == 1)
                    {
                        player.Torpilleur.cases[i].x = posDepartX;
                        player.Torpilleur.cases[i].y = posDepartY - i;
                    }
                    else if (ori == 2)
                    {
                        player.Torpilleur.cases[i].x = posDepartX;
                        player.Torpilleur.cases[i].y = posDepartY + i;
                    }
                    else if (ori == 3)
                    {
                        player.Torpilleur.cases[i].x = posDepartX - i;
                        player.Torpilleur.cases[i].y = posDepartY;
                    }
                    else
                    {
                        player.Torpilleur.cases[i].x = posDepartX + i;
                        player.Torpilleur.cases[i].y = posDepartY;
                    }
                }
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
}
