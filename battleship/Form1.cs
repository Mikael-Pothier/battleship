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
        String [] ligneHeader={"A","B","C","D","E","F","G","H","I","J"}; 
        public Form1()
        {
            InitializeComponent();
            createGrid();
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
    }
}
