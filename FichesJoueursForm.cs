/*
    Programmeurs:   Alexandre Roy, Cyrille Sonfack, Jérémie Rousselle, Stéphane Nkontie
    Date:           7 Octobre 2024
    But:            Devoir 2 (Phase B) - Fiche des joueurs

    Projet:         FichesJoueurs.csproj
    Solution:       FichesJoueurs.sln
    Classes:        FichesJoueursForm.cs

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using c = FichesJoueurs.FichesJoueursClasseGeneral;

namespace FichesJoueurs
{
    public partial class FichesJoueursParent : Form
    {

        #region Constructeur
        public FichesJoueursParent()
        {
            InitializeComponent();
        }
        #endregion

        #region Chargement du formulaire
        private void FichesJoueursParent_Load(object sender, EventArgs e)
        {
            c.InitMessagesErreur();
            AssocierImages();
            fichesJoueursOpenFileDialog.Filter = "Fichier rtf (*.rtf) |*.RTF|Tous les fichiers (*.*)| *.*";
        }

        #endregion

        #region Association d'image

        private void AssocierImages()
        {
            grasToolStripButton.Image = Properties.Resources.boldhs;
            italiqueToolStripButton.Image = Properties.Resources.ItalicHS;
            soulignementToolStripButton.Image = Properties.Resources.underline;
            gaucheAlignementToolStripButton.Image = Properties.Resources.AlignTableCellMiddleLeftJustHS;
            droiteAlignementToolStripButton.Image = Properties.Resources.AlignTableCellMiddleRightHS;
            centreAlignementToolStripButton.Image = Properties.Resources.AlignTableCellMiddleCenterHS;
            (fichesJoueursMenuStrip.Items[6] as ToolStripMenuItem).DropDownItems[0].Image = Properties.Resources.help;
        }

        #endregion

        private void StyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int menuStripRenderModeInt;
            menuStripRenderModeInt = boiteOutilsToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender) + 1;

            fichesJoueursMenuStrip.RenderMode = (System.Windows.Forms.ToolStripRenderMode)menuStripRenderModeInt;

            c.EnleverCrochetSousMenu(boiteOutilsToolStripMenuItem);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                JoueurForm oJoueur = new JoueurForm();
                oJoueur.MdiParent = this;
                oJoueur.Text += " " + (JoueurForm.NombreEnfant() + 1).ToString();
                oJoueur.Show();
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CENumeroFormulaireInvalide]);
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CECreationNouveauEnfantErreur]);
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int layoutMdiInt;
            layoutMdiInt = fenetreToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender);

            this.LayoutMdi((System.Windows.Forms.MdiLayout)layoutMdiInt);

            c.EnleverCrochetSousMenu(fenetreToolStripMenuItem);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void droitToolStripPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control == fichesJoueursMenuStrip)
            {
                if (sender == droitToolStripPanel || sender == gaucheToolStripPanel)
                {
                    fichesJoueursMenuStrip.TextDirection = ToolStripTextDirection.Vertical90;
                    fichesJoueursMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    taperQuestionToolStripTextBox.Visible = false;
                }
                else
                {
                    fichesJoueursMenuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                    fichesJoueursMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    taperQuestionToolStripTextBox.Visible = true;
                }
            }
            else
            {
                if (sender == droitToolStripPanel || sender == gaucheToolStripPanel)
                {
                    premierToolStripComboBox.Visible = false;
                    deuxiemeToolStripComboBox.Visible = false;
                }
                else
                {
                    premierToolStripComboBox.Visible = true;
                    deuxiemeToolStripComboBox.Visible = true;
                }
            }
        }

        #region Enregistrer ou Enregistrer sous

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                JoueurForm oJoueur;
                oJoueur = (JoueurForm)this.ActiveMdiChild;

                if (sender == enregistrersousToolStripMenuItem)
                    oJoueur.EnregistrerSous();
                else
                    oJoueur.Enregistrer();       
            }
        }

        #endregion

        #region Ouvrir

        private void ouvrirToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (fichesJoueursOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fichesJoueursOpenFileDialog.FileName.EndsWith(".rtf"))
                    {
                        JoueurForm oJoueur = new JoueurForm();
                        oJoueur.MdiParent = this;
                        oJoueur.Text = fichesJoueursOpenFileDialog.FileName;

                        // oEnfant.clientRichTextBox.LoadFile(ofd.FileName);

                        RichTextBox ortf = new RichTextBox();

                        ortf.LoadFile(fichesJoueursOpenFileDialog.FileName);

                        oJoueur.nomTextBox.Text = ortf.Lines[0];
                        oJoueur.prenomTextBox.Text = ortf.Lines[1];
                        oJoueur.telephoneMaskedTextBox.Text = ortf.Lines[2];

                        ortf.SelectionStart = 0;
                        ortf.SelectionLength = ortf.Lines[0].Length + ortf.Lines[1].Length + ortf.Lines[2].Length + 3; // ne pas oublier changement de ligne
                        ortf.SelectedText = String.Empty;

                        oJoueur.infoRichTextBox.Rtf = ortf.Rtf;

                        oJoueur.Enregistrement = true;
                        oJoueur.infoRichTextBox.Modified = false;
                        oJoueur.Modification = false;

                        oJoueur.Show();
                    }
                    else
                        MessageBox.Show("Vous ne pouvez ouvrir que des fichiers portant l'extension .rtf avec  l'application FichesJoueurs", "Ouvrir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {

            }
        }

        #endregion

        #region Fermer

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveControl != null || ActiveMdiChild != null)
            {          
                ActiveMdiChild.Dispose();   
            }
        }


        #endregion

        #region Quitter

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        
    }
}
