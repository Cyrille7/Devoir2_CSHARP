/*
    Programmeurs:   Alexandre Roy, Cyrille Sonfack, Jérémie Rousselle, Stéphane Nkontie
    Date:           7 Octobre 2024
    But:            Devoir 2 (Phase B) - Fiche des joueurs

    Projet:          FichesJoueurs.csproj
    Solution:        FichesJoueurs.sln
    Classe:          EnfantForm.cs

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FichesJoueurs
{
    public partial class JoueurForm : Form
    {
        #region Variables

        private bool enregistrementBool = false;
        private bool modificationBool = false;
        public static int nombre = 0;

        #endregion

        #region Constructeur
        public JoueurForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Propriétés

        public bool Enregistrement
        {
            get
            {
                return enregistrementBool;
            }
            set
            {
                enregistrementBool = value;
            }
        }

        public bool Modification
        {
            get
            {
                return modificationBool;
            }
            set
            {
                modificationBool = value;
            }
        }

        public static int NombreEnfant()
        {
            try
            {
                return nombre++;
            }
            catch
            {
                throw new IndexOutOfRangeException("Erreur d'index");
            }
        }

        #endregion

        #region Formulaire ferme

         private void Enfant_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult oDialogResult;

            try
            {

                if(Modification)
                {
                    oDialogResult = MessageBox.Show("Modification. Enregistrer ?", "Modification", MessageBoxButtons.YesNoCancel);

                    switch (oDialogResult)
                    {
                        case DialogResult.Yes:
                            Enregistrer();
                            this.Dispose();
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;

                        case DialogResult.No:
                            this.Dispose();
                            break;
                    }
                }  
            }
            catch
            {

            }
            
                
        }

        #endregion

        #region Changement dans TextBox

        private void clientTextBox_TextChanged(object sender, EventArgs e)
        {
            Modification = true;
        }

        #endregion

        #region Enregistrer

        public void Enregistrer()
        {
            try
            {
                if (Modification)
                {
                    if (!Enregistrement)
                    {
                        EnregistrerSous();
                    }
                    else
                    {
                        // Utiliser une méthode pour Sauvegarder...

                        SaveToRichTextBox(this.Text);

                        // Pas de changement
                        Modification = false;
                    }
                }
            }
            catch
            {

            }
            
        }

        public void EnregistrerSous()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Fichier rtf (*.rtf) |*.RTF|Tous les fichiers (*.*)| *.*";
                sfd.DefaultExt = ".rtf";
                sfd.Title = "Enregistrer le client";
                sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if(sfd.FileName.EndsWith(".rtf"))
                        {
                            string filePath = sfd.FileName;
                            this.Text = filePath;

                            // Utiliser une méthode pour Sauvegarder...

                            SaveToRichTextBox(filePath);

                            // Enregistré et pas de changement
                            Enregistrement = true;
                            Modification = false;
                        }
                        else
                            MessageBox.Show("L'extension RTF doit etre utilise.", "Enregistrer sous du document", MessageBoxButtons.OK , MessageBoxIcon.Error);
                    }
            }
            catch
            {

            }
            
        }

        private void SaveToRichTextBox(string filePath)
        {
            // Créer un RichTextBox temporaire
            RichTextBox tempRichTextBox = new RichTextBox();

            // Charger le RTF existant
            tempRichTextBox.Rtf = infoRichTextBox.Rtf;

            tempRichTextBox.SelectionStart = 0;
            tempRichTextBox.SelectionLength = 0;


            tempRichTextBox.SelectedText = nomTextBox.Text + Environment.NewLine;
            tempRichTextBox.SelectedText = prenomTextBox.Text + Environment.NewLine;
            tempRichTextBox.SelectedText = telephoneMaskedTextBox.Text + Environment.NewLine;


            // Enregistrer dans un fichier si un chemin est fourni
            tempRichTextBox.SaveFile(filePath);

            infoRichTextBox.Modified = false;
        }

        #endregion

    }
}
