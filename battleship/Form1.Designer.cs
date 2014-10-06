namespace battleship
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridAttack = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPlayer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Attack = new System.Windows.Forms.Button();
            this.BTN_NouvellePartie = new System.Windows.Forms.Button();
            this.BTN_Quit = new System.Windows.Forms.Button();
            this.RBTN_PorteAvion = new System.Windows.Forms.RadioButton();
            this.RBTN_Croiseur = new System.Windows.Forms.RadioButton();
            this.RBTN_ContreTorpille = new System.Windows.Forms.RadioButton();
            this.RBTN_SousMarin = new System.Windows.Forms.RadioButton();
            this.RBTN_Torpilleur = new System.Windows.Forms.RadioButton();
            this.BTN_Place = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_replace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridAttack
            // 
            this.GridAttack.AllowUserToAddRows = false;
            this.GridAttack.AllowUserToDeleteRows = false;
            this.GridAttack.AllowUserToResizeColumns = false;
            this.GridAttack.AllowUserToResizeRows = false;
            this.GridAttack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAttack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9,
            this.col10});
            this.GridAttack.Location = new System.Drawing.Point(23, 12);
            this.GridAttack.MultiSelect = false;
            this.GridAttack.Name = "GridAttack";
            this.GridAttack.ReadOnly = true;
            this.GridAttack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.GridAttack.Size = new System.Drawing.Size(568, 244);
            this.GridAttack.TabIndex = 0;
            // 
            // col1
            // 
            this.col1.HeaderText = "1";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            this.col1.Width = 50;
            // 
            // col2
            // 
            this.col2.HeaderText = "2";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            this.col2.Width = 50;
            // 
            // col3
            // 
            this.col3.HeaderText = "3";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            this.col3.Width = 50;
            // 
            // col4
            // 
            this.col4.HeaderText = "4";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            this.col4.Width = 50;
            // 
            // col5
            // 
            this.col5.HeaderText = "5";
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            this.col5.Width = 50;
            // 
            // col6
            // 
            this.col6.HeaderText = "6";
            this.col6.Name = "col6";
            this.col6.ReadOnly = true;
            this.col6.Width = 50;
            // 
            // col7
            // 
            this.col7.HeaderText = "7";
            this.col7.Name = "col7";
            this.col7.ReadOnly = true;
            this.col7.Width = 50;
            // 
            // col8
            // 
            this.col8.HeaderText = "8";
            this.col8.Name = "col8";
            this.col8.ReadOnly = true;
            this.col8.Width = 50;
            // 
            // col9
            // 
            this.col9.HeaderText = "9";
            this.col9.Name = "col9";
            this.col9.ReadOnly = true;
            this.col9.Width = 50;
            // 
            // col10
            // 
            this.col10.HeaderText = "10";
            this.col10.Name = "col10";
            this.col10.ReadOnly = true;
            this.col10.Width = 50;
            // 
            // GridPlayer
            // 
            this.GridPlayer.AllowUserToAddRows = false;
            this.GridPlayer.AllowUserToDeleteRows = false;
            this.GridPlayer.AllowUserToResizeColumns = false;
            this.GridPlayer.AllowUserToResizeRows = false;
            this.GridPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPlayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.GridPlayer.Location = new System.Drawing.Point(23, 262);
            this.GridPlayer.MultiSelect = false;
            this.GridPlayer.Name = "GridPlayer";
            this.GridPlayer.ReadOnly = true;
            this.GridPlayer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.GridPlayer.Size = new System.Drawing.Size(568, 244);
            this.GridPlayer.TabIndex = 1;
            this.GridPlayer.Click += new System.EventHandler(this.GridPlayer_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "7";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "8";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "9";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "10";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // BTN_Attack
            // 
            this.BTN_Attack.Enabled = false;
            this.BTN_Attack.Location = new System.Drawing.Point(598, 33);
            this.BTN_Attack.Name = "BTN_Attack";
            this.BTN_Attack.Size = new System.Drawing.Size(106, 44);
            this.BTN_Attack.TabIndex = 2;
            this.BTN_Attack.Text = "Attaque";
            this.BTN_Attack.UseVisualStyleBackColor = true;
            this.BTN_Attack.Click += new System.EventHandler(this.BTN_Attack_Click);
            // 
            // BTN_NouvellePartie
            // 
            this.BTN_NouvellePartie.Location = new System.Drawing.Point(816, 415);
            this.BTN_NouvellePartie.Name = "BTN_NouvellePartie";
            this.BTN_NouvellePartie.Size = new System.Drawing.Size(134, 38);
            this.BTN_NouvellePartie.TabIndex = 3;
            this.BTN_NouvellePartie.Text = "Nouvelle Partie";
            this.BTN_NouvellePartie.UseVisualStyleBackColor = true;
            this.BTN_NouvellePartie.Visible = false;
            this.BTN_NouvellePartie.Click += new System.EventHandler(this.BTN_NouvellePartie_Click);
            // 
            // BTN_Quit
            // 
            this.BTN_Quit.Location = new System.Drawing.Point(815, 459);
            this.BTN_Quit.Name = "BTN_Quit";
            this.BTN_Quit.Size = new System.Drawing.Size(135, 38);
            this.BTN_Quit.TabIndex = 4;
            this.BTN_Quit.Text = "Quitter";
            this.BTN_Quit.UseVisualStyleBackColor = true;
            this.BTN_Quit.Click += new System.EventHandler(this.BTN_Quit_Click);
            // 
            // RBTN_PorteAvion
            // 
            this.RBTN_PorteAvion.AutoSize = true;
            this.RBTN_PorteAvion.Location = new System.Drawing.Point(3, 3);
            this.RBTN_PorteAvion.Name = "RBTN_PorteAvion";
            this.RBTN_PorteAvion.Size = new System.Drawing.Size(80, 17);
            this.RBTN_PorteAvion.TabIndex = 5;
            this.RBTN_PorteAvion.TabStop = true;
            this.RBTN_PorteAvion.Text = "Porte Avion";
            this.RBTN_PorteAvion.UseVisualStyleBackColor = true;
            this.RBTN_PorteAvion.CheckedChanged += new System.EventHandler(this.RBTN_Bateau_CheckedChanged);
            // 
            // RBTN_Croiseur
            // 
            this.RBTN_Croiseur.AutoSize = true;
            this.RBTN_Croiseur.Location = new System.Drawing.Point(3, 26);
            this.RBTN_Croiseur.Name = "RBTN_Croiseur";
            this.RBTN_Croiseur.Size = new System.Drawing.Size(63, 17);
            this.RBTN_Croiseur.TabIndex = 6;
            this.RBTN_Croiseur.TabStop = true;
            this.RBTN_Croiseur.Text = "Croiseur";
            this.RBTN_Croiseur.UseVisualStyleBackColor = true;
            this.RBTN_Croiseur.CheckedChanged += new System.EventHandler(this.RBTN_Bateau_CheckedChanged);
            // 
            // RBTN_ContreTorpille
            // 
            this.RBTN_ContreTorpille.AutoSize = true;
            this.RBTN_ContreTorpille.Location = new System.Drawing.Point(3, 49);
            this.RBTN_ContreTorpille.Name = "RBTN_ContreTorpille";
            this.RBTN_ContreTorpille.Size = new System.Drawing.Size(98, 17);
            this.RBTN_ContreTorpille.TabIndex = 7;
            this.RBTN_ContreTorpille.TabStop = true;
            this.RBTN_ContreTorpille.Text = "Contre-torpilleur";
            this.RBTN_ContreTorpille.UseVisualStyleBackColor = true;
            this.RBTN_ContreTorpille.CheckedChanged += new System.EventHandler(this.RBTN_Bateau_CheckedChanged);
            // 
            // RBTN_SousMarin
            // 
            this.RBTN_SousMarin.AutoSize = true;
            this.RBTN_SousMarin.Location = new System.Drawing.Point(3, 72);
            this.RBTN_SousMarin.Name = "RBTN_SousMarin";
            this.RBTN_SousMarin.Size = new System.Drawing.Size(75, 17);
            this.RBTN_SousMarin.TabIndex = 8;
            this.RBTN_SousMarin.TabStop = true;
            this.RBTN_SousMarin.Text = "sous-marin";
            this.RBTN_SousMarin.UseVisualStyleBackColor = true;
            this.RBTN_SousMarin.CheckedChanged += new System.EventHandler(this.RBTN_Bateau_CheckedChanged);
            // 
            // RBTN_Torpilleur
            // 
            this.RBTN_Torpilleur.AutoSize = true;
            this.RBTN_Torpilleur.Location = new System.Drawing.Point(3, 90);
            this.RBTN_Torpilleur.Name = "RBTN_Torpilleur";
            this.RBTN_Torpilleur.Size = new System.Drawing.Size(64, 17);
            this.RBTN_Torpilleur.TabIndex = 9;
            this.RBTN_Torpilleur.TabStop = true;
            this.RBTN_Torpilleur.Text = "torpilleur";
            this.RBTN_Torpilleur.UseVisualStyleBackColor = true;
            this.RBTN_Torpilleur.CheckedChanged += new System.EventHandler(this.RBTN_Bateau_CheckedChanged);
            // 
            // BTN_Place
            // 
            this.BTN_Place.Location = new System.Drawing.Point(598, 393);
            this.BTN_Place.Name = "BTN_Place";
            this.BTN_Place.Size = new System.Drawing.Size(98, 37);
            this.BTN_Place.TabIndex = 10;
            this.BTN_Place.Text = "prêt";
            this.BTN_Place.UseVisualStyleBackColor = true;
            this.BTN_Place.Click += new System.EventHandler(this.BTN_Place_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RBTN_PorteAvion);
            this.panel1.Controls.Add(this.RBTN_Croiseur);
            this.panel1.Controls.Add(this.RBTN_Torpilleur);
            this.panel1.Controls.Add(this.RBTN_ContreTorpille);
            this.panel1.Controls.Add(this.RBTN_SousMarin);
            this.panel1.Location = new System.Drawing.Point(598, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 110);
            this.panel1.TabIndex = 11;
            // 
            // BTN_replace
            // 
            this.BTN_replace.Location = new System.Drawing.Point(598, 437);
            this.BTN_replace.Name = "BTN_replace";
            this.BTN_replace.Size = new System.Drawing.Size(98, 42);
            this.BTN_replace.TabIndex = 12;
            this.BTN_replace.Text = "Replacer";
            this.BTN_replace.UseVisualStyleBackColor = true;
            this.BTN_replace.Click += new System.EventHandler(this.BTN_replace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 515);
            this.Controls.Add(this.BTN_replace);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_Place);
            this.Controls.Add(this.BTN_Quit);
            this.Controls.Add(this.BTN_NouvellePartie);
            this.Controls.Add(this.BTN_Attack);
            this.Controls.Add(this.GridPlayer);
            this.Controls.Add(this.GridAttack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "battleship";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridAttack;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn col9;
        private System.Windows.Forms.DataGridViewTextBoxColumn col10;
        private System.Windows.Forms.DataGridView GridPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Button BTN_Attack;
        private System.Windows.Forms.Button BTN_NouvellePartie;
        private System.Windows.Forms.Button BTN_Quit;
        private System.Windows.Forms.RadioButton RBTN_PorteAvion;
        private System.Windows.Forms.RadioButton RBTN_Croiseur;
        private System.Windows.Forms.RadioButton RBTN_ContreTorpille;
        private System.Windows.Forms.RadioButton RBTN_SousMarin;
        private System.Windows.Forms.RadioButton RBTN_Torpilleur;
        private System.Windows.Forms.Button BTN_Place;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_replace;

    }
}

