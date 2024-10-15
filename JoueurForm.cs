/*
    Programmeurs:   Alexandre Roy, Cyrille Fidjio, Jérémie Rousselle, Stéphane Nkontie
    Date:           15 Octobre 2024
    But:            Devoir 2 (Phase D) - Fiche des joueurs

    Projet:         FichesJoueurs.csproj
    Solution:       FichesJoueurs.sln
    Classe:         JoueurForm.cs

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

using c = FichesJoueurs.FichesJoueursClasseGeneral;

namespace FichesJoueurs
{
    public partial class JoueurForm : Form
    {
        #region Variables

        private bool enregistrementBool = false;
        private bool modificationBool = false;



        #endregion

        #region Initialisation

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



        #endregion

        #region Fermeture du formulaire enfant

        private void Joueur_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                DialogResult oDialogResult;

                if (Modification)
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
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }


        }

        #endregion

        #region Changement dans TextBox

        private void JoueurFormTextBox_TextChanged(object sender, EventArgs e)
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
                    if (Enregistrement)
                    {
                        // Utiliser une méthode pour Sauvegarder...

                        SaveToRichTextBox(this.Text);

                        // Pas de changement
                        Modification = false;
                    }
                    else
                    {
                        EnregistrerSous();
                    }
                }
                else
                    MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurFichierVide], "Enregistrement du document", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
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
                    if (sfd.FileName.EndsWith(".rtf"))
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
                        MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurExtensionInvalide], "Enregistrer sous du document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
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

        #region RichTextBox_SelectionChanged

        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                FichesJoueursParent parent = (FichesJoueursParent)this.MdiParent;
         
                parent.grasToolStripButton.Checked = infoRichTextBox.SelectionFont.Bold;
                parent.italiqueToolStripButton.Checked = infoRichTextBox.SelectionFont.Italic;
                parent.soulignementToolStripButton.Checked = infoRichTextBox.SelectionFont.Underline;
                
                if (Clipboard.ContainsText() || Clipboard.ContainsImage())
                {
                    parent.collerToolStripButton.Enabled = true;
                    parent.collerToolStripMenuItem.Enabled = true;
                }
                else
                {
                    parent.collerToolStripButton.Enabled = false;
                    parent.collerToolStripMenuItem.Enabled = false;
                }

                parent.copierToolStripMenuItem.Enabled = infoRichTextBox.SelectionLength > 0;
                parent.copierToolStripButton.Enabled = infoRichTextBox.SelectionLength > 0;
                parent.couperToolStripMenuItem.Enabled = infoRichTextBox.SelectionLength > 0;
                parent.couperToolStripButton.Enabled = infoRichTextBox.SelectionLength > 0;

                switch (infoRichTextBox.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        parent.gaucheAlignementToolStripButton.Checked = true;
                        parent.centreAlignementToolStripButton.Checked = false;
                        parent.droiteAlignementToolStripButton.Checked = false;
                        break;
                    case HorizontalAlignment.Center:
                        parent.gaucheAlignementToolStripButton.Checked = false;
                        parent.centreAlignementToolStripButton.Checked = true;
                        parent.droiteAlignementToolStripButton.Checked = false;
                        break;
                    case HorizontalAlignment.Right:
                        parent.gaucheAlignementToolStripButton.Checked = false;
                        parent.centreAlignementToolStripButton.Checked = false;
                        parent.droiteAlignementToolStripButton.Checked = true;
                        break;
                }

            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

        #region ClientActivated
        private void ClientActivated()
        {
            RichTextBox_SelectionChanged(null ,null);
        }

        #endregion

        #region ChangerAttributsPolice
        public void ChangerAttributsPolice(FontStyle style)
        {
            try
            {
                if (infoRichTextBox.Font.FontFamily.IsStyleAvailable(style))
                {

                    infoRichTextBox.SelectionFont = new Font(infoRichTextBox.SelectionFont,
                         infoRichTextBox.SelectionFont.Style | style);
                }

            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

    }
}