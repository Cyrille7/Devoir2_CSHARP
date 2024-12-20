﻿/*
    Programmeurs:   Alexandre Roy, Cyrille Fidjio, Jérémie Rousselle, Stéphane Nkontie
    Date:           22 Octobre 2024
    But:            Devoir 2 (Phase F) - Fiche des joueurs

    Projet:         FichesJoueurs.csproj
    Solution:       FichesJoueurs.sln
    Classes:        FichesJoueursForm.cs

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using c = FichesJoueurs.FichesJoueursClasseGeneral;

namespace FichesJoueurs
{
    public partial class FichesJoueursParent : Form
    {
        #region Variables

        private int nbClients = 1;
        FontStyle oFontStyle;

        #endregion

        #region Constructeur
        public FichesJoueursParent()
        {
            InitializeComponent();
        }
        #endregion

        #region Chargement du formulaire
        private void FichesJoueursParent_Load(object sender, EventArgs e)
        {
            oFontStyle = FontStyle.Regular;
            c.InitMessagesErreur();
            AssocierImages();
            fichesJoueursOpenFileDialog.Filter = "Fichier rtf (*.rtf) |*.RTF|Tous les fichiers (*.*)| *.*";

            fichesJoueursOpenFileDialog.DefaultExt = ".rtf";
            fichesJoueursOpenFileDialog.AddExtension = true;
            fichesJoueursOpenFileDialog.CheckFileExists = true;
            fichesJoueursOpenFileDialog.CheckPathExists = true;

            DesactiverOperationsMenusBarreOutils();

            languageToolStripStatusLabel.Text = CultureInfo.CurrentCulture.NativeName;

            if (System.Console.CapsLock)
            {
                capsLockToolStripStatusLabel.Text = "MAJ";
            }

            policeToolStripComboBox.SelectedIndexChanged -= policeToolStripComboBox_SelectedIndexChanged;
            tailleToolStripComboBox.SelectedIndexChanged -= tailleToolStripComboBox_SelectedIndexChanged;

            InitPolice();

            policeToolStripComboBox.SelectedIndexChanged += policeToolStripComboBox_SelectedIndexChanged;
            tailleToolStripComboBox.SelectedIndexChanged += tailleToolStripComboBox_SelectedIndexChanged;


            fichesJoueursFontDialog.MaxSize = 16;
            fichesJoueursFontDialog.MinSize = 8;

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

        #region Render Mode
        private void StyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int menuStripRenderModeInt;
            menuStripRenderModeInt = boiteOutilsToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender) + 1;

            fichesJoueursMenuStrip.RenderMode = (System.Windows.Forms.ToolStripRenderMode)menuStripRenderModeInt;

            c.EnleverCrochetSousMenu(boiteOutilsToolStripMenuItem);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        #endregion

        #region Nouveau enfant
        private void FichierNouveauDocument_Click(object sender, EventArgs e)
        {
            try
            {
                JoueurForm oJoueur = new JoueurForm();
                oJoueur.MdiParent = this;
                oJoueur.ModeInsertion = true;
                oJoueur.Text += " " + (nbClients).ToString();
                oJoueur.Show();
                nbClients++;
                ActiverOperationsMenusBarreOutils();
                policesListBox.Visible = false;
                
                
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CENumeroFormulaireInvalide]);
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CECreationNouveauEnfantErreur]);
            }
        }

        #endregion

        #region MdiLayout
        private void FenetreMdiLayout_Click(object sender, EventArgs e)
        {
            int layoutMdiInt;
            layoutMdiInt = fenetreToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender);

            this.LayoutMdi((System.Windows.Forms.MdiLayout)layoutMdiInt);

            c.EnleverCrochetSousMenu(fenetreToolStripMenuItem);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        #endregion

        #region ToolStripPanel
        private void QuatrePaneaux_ControlAdded(object sender, ControlEventArgs e)
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
                    policeToolStripComboBox.Visible = false;
                    tailleToolStripComboBox.Visible = false;
                }
                else
                {
                    policeToolStripComboBox.Visible = true;
                    tailleToolStripComboBox.Visible = true;
                }
            }
        }

        #endregion

        #region Enregistrer ou Enregistrer sous

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    JoueurForm oJoueur = (JoueurForm)this.ActiveMdiChild;

                    if (sender == enregistrersousToolStripMenuItem)
                        oJoueur.EnregistrerSous();
                    else
                        oJoueur.Enregistrer();

                    creerOuvrirJoueurToolStripStatusLabel.Text = oJoueur.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

        #region Style et Police

        private void StylePolice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    JoueurForm oJoueur = (JoueurForm)this.ActiveMdiChild;
                    
                    if (sender == grasToolStripButton)
                    {

                        if (grasToolStripButton.Checked)
                        {
                            oJoueur.ChangerAttributsPolice(FontStyle.Bold);
                        }
                        else
                        {
                            oJoueur.infoRichTextBox.SelectionFont = new Font(oJoueur.infoRichTextBox.SelectionFont,
                               oJoueur.infoRichTextBox.SelectionFont.Style & ~FontStyle.Bold);
                        }
                    }
                    else if(sender == italiqueToolStripButton)
                    {
                        if (italiqueToolStripButton.Checked)
                        {
                            oJoueur.ChangerAttributsPolice(FontStyle.Italic);
                        }
                        else
                        {
                            oJoueur.infoRichTextBox.SelectionFont = new Font(oJoueur.infoRichTextBox.SelectionFont,
                               oJoueur.infoRichTextBox.SelectionFont.Style & ~FontStyle.Italic);
                        }
                    }
                    else
                    {
                        if (soulignementToolStripButton.Checked)
                        {
                            oJoueur.ChangerAttributsPolice(FontStyle.Underline);
                        }
                        else
                        {
                            oJoueur.infoRichTextBox.SelectionFont = new Font(oJoueur.infoRichTextBox.SelectionFont,
                               oJoueur.infoRichTextBox.SelectionFont.Style & ~FontStyle.Underline);
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
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
                        oJoueur.ModeInsertion = true;
                        oJoueur.Text = fichesJoueursOpenFileDialog.FileName;

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
                        ActiverOperationsMenusBarreOutils();
                    }
                    else
                        MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurExtensionInvalide], "Ouvrir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

        #region Fermer

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl != null || ActiveMdiChild != null)
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

        #region DesactiverOperationsMenusBarreOutils

        private void DesactiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in fichesJoueursMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem oMainMenuItem)
                {
                    foreach (ToolStripItem oCourantToolStripItem in oMainMenuItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem)
                        {
                            oCourantToolStripItem.Enabled = false;
                        }
                    }
                }
            }

            quitterToolStripMenuItem.Enabled = true;
            nouveauToolStripMenuItem.Enabled = true;
            ouvrirToolStripMenuItem.Enabled = true;
            aideSurListeJoueursToolStripMenuItem.Enabled = true;

            foreach (ToolStripItem boutonToolStripItem in fichesJoueursToolStrip.Items)
            {
                boutonToolStripItem.Enabled = false;
            }

            nouveauToolStripButton.Enabled = true;
            ouvrirToolStripButton.Enabled = true;

        }

        #endregion

        #region ActiverOperationsMenusBarreOutils

        private void ActiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in fichesJoueursMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem oMainMenuItem)
                {
                    foreach (ToolStripItem oCourantToolStripItem in oMainMenuItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem)
                        {
                            oCourantToolStripItem.Enabled = true;
                        }
                    }
                }
            }

            foreach (ToolStripItem boutonToolStripItem in fichesJoueursToolStrip.Items)
            {
                boutonToolStripItem.Enabled = true;
            }

            //Désactiver les boutons appropriés : A FAIRE !!!!!!!

            couperToolStripButton.Enabled = false;
            couperToolStripMenuItem.Enabled = false;
            copierToolStripButton.Enabled = false;
            copierToolStripMenuItem.Enabled = false;
            collerToolStripButton.Enabled = false;
            collerToolStripMenuItem.Enabled = false;

            if (Clipboard.ContainsText() || Clipboard.ContainsImage())
            {
                collerToolStripButton.Enabled = true;
                collerToolStripMenuItem.Enabled = true;
            }
        }

        #endregion

        #region Alignement

        private void Alignement_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ActiveMdiChild != null)
                {
                    if(this.ActiveMdiChild is JoueurForm joueurForm)
                    {
                        if (sender == gaucheAlignementToolStripButton)
                        {
                            joueurForm.infoRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                            centreAlignementToolStripButton.Checked = false;
                            droiteAlignementToolStripButton.Checked = false;
                        }
                        else if (sender == centreAlignementToolStripButton)
                        {
                            joueurForm.infoRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
                            gaucheAlignementToolStripButton.Checked = false;
                            droiteAlignementToolStripButton.Checked = false;

                        }
                        else
                        {
                            joueurForm.infoRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                            centreAlignementToolStripButton.Checked = false;
                            gaucheAlignementToolStripButton.Checked = false;
                        }
                    }
                }  
            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

        #region MdiChildActivate
        private void FichesJoueursParent_MdiChildActivate(object sender, EventArgs e)
        {
            if(ActiveMdiChild == null)
            {
                DesactiverOperationsMenusBarreOutils();

                creerOuvrirJoueurToolStripStatusLabel.Text = "Créer un nouveau formulaire enfant...";
                insertToolStripStatusLabel.Text = string.Empty;
            }
            else 
            {
                JoueurForm oJoueur = (JoueurForm)this.ActiveMdiChild;

                if (oJoueur.ModeInsertion)
                {
                    insertToolStripStatusLabel.Text = "INS";
                }
                else
                {
                    insertToolStripStatusLabel.Text = "RFP";
                }

                creerOuvrirJoueurToolStripStatusLabel.Text = oJoueur.Text;
            }
        }

        #endregion

        #region Edition
        private void EditionTexte_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    if(this.ActiveMdiChild is JoueurForm joueurForm)
                    {
                        if (sender == copierToolStripMenuItem || sender == copierToolStripButton)
                        {
                            joueurForm.infoRichTextBox.Copy();
                        }
                        else if (sender == collerToolStripMenuItem || sender == collerToolStripButton)
                        {
                            joueurForm.infoRichTextBox.Paste();
                        }
                        else if (sender == couperToolStripMenuItem || sender == couperToolStripButton)
                        {
                            joueurForm.infoRichTextBox.Cut();
                        }
                        else if (sender == selectionnerToolStripMenuItem)
                        {
                            joueurForm.infoRichTextBox.SelectAll();
                        }
                        else
                        {
                            joueurForm.infoRichTextBox.Clear();
                        }
                    }      
                }
            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }


        #endregion

        #region KeyDown
        private void FichesJoueursParent_KeyDown(object sender, KeyEventArgs e)
        {
            JoueurForm oJoueur = this.ActiveMdiChild as JoueurForm;

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                capsLockToolStripStatusLabel.Text = "MAJ";
            }
            else
            {
                capsLockToolStripStatusLabel.Text = string.Empty;
            }

            if (e.KeyCode == Keys.Insert)
            {
                if (insertToolStripStatusLabel.Text == "INS")
                {
                    insertToolStripStatusLabel.Text = "RFP";

                    if (this.ActiveMdiChild != null)
                    {
                        oJoueur.ModeInsertion = false;
                    }
                }
                else
                {
                    insertToolStripStatusLabel.Text = "INS";

                    if (this.ActiveMdiChild != null)
                    {
                        oJoueur.ModeInsertion = true;
                    }
                }
            }
        }

        #endregion

        #region Initialisation Police

        private void InitPolice()
        {
            try
            {
                InstalledFontCollection oInstalledFonts = new InstalledFontCollection();


                foreach (FontFamily oFamily in oInstalledFonts.Families)
                {
                    policeToolStripComboBox.Items.Add(oFamily.Name);
                }


                //for (int i = 0; i < oInstalledFonts.Families.Length; i++)
                //{
                //    Font newFont = new Font(oInstalledFonts.Families[i], 12, FontStyle.Regular);

                //    TextBox oTextBox = new TextBox();
                //    oTextBox.Font = newFont;
                //    oTextBox.Text = oInstalledFonts.Families[i].Name;
                //    policeToolStripComboBox.Items.Add(oTextBox.Text);
                //    policeToolStripComboBox.Font = newFont;
                //    Console.WriteLine(policeToolStripComboBox.Font);
                //}


            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }

        }

        #endregion

        #region Format Police
        private void policeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                JoueurForm oJoueur = this.ActiveMdiChild as JoueurForm;

                fichesJoueursFontDialog.ShowEffects = true;
                fichesJoueursFontDialog.Font = oJoueur.infoRichTextBox.Font;

                if (fichesJoueursFontDialog.ShowDialog() == DialogResult.OK)
                {
                    oJoueur.infoRichTextBox.Font = fichesJoueursFontDialog.Font;  
                }
            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);

            }
        }

        #endregion

        #region Police SelectedIndexChanged
        private void policeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                JoueurForm oJoueurForm = (JoueurForm)this.ActiveMdiChild;
                Font enfantRichTextBoxFont = oJoueurForm.infoRichTextBox.SelectionFont;

        
                string policeSelectionnee = (string)policeToolStripComboBox.SelectedItem;

                if(enfantRichTextBoxFont != null)
                    oJoueurForm.infoRichTextBox.SelectionFont = new Font(policeSelectionnee, enfantRichTextBoxFont.Size, enfantRichTextBoxFont.Style);
                else
                    oJoueurForm.infoRichTextBox.SelectionFont = new Font(policeSelectionnee, float.Parse(tailleToolStripComboBox.Text), FontStyle.Regular);



                oJoueurForm.infoRichTextBox.Focus();
                policesListBox.Visible = false;


            }
            catch(Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }

        #endregion

        #region Taille SelectedIndexChanged
        private void tailleToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                JoueurForm ojoueurForm = (JoueurForm)this.ActiveMdiChild;
                Font enfantRichTextBoxFont = ojoueurForm.infoRichTextBox.SelectionFont;

                if (enfantRichTextBoxFont != null)
                {

                    float tailleSelectionnee = float.Parse((string)tailleToolStripComboBox.SelectedItem);
                    ojoueurForm.infoRichTextBox.SelectionFont = new Font(enfantRichTextBoxFont.FontFamily, tailleSelectionnee, enfantRichTextBoxFont.Style);

           
                    ojoueurForm.infoRichTextBox.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
            }
        }




        #endregion

        #region Police ToolStripComboBox_TextChanged
        private void policeToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            JoueurForm ojoueurForm = (JoueurForm)this.ActiveMdiChild;

            if (policeToolStripComboBox.Focused)
            {
                InstalledFontCollection oInstalledFonts = new InstalledFontCollection();

                String pattern = "";
                pattern = policeToolStripComboBox.Text.ToString();

                policesListBox.Visible = true;

                policesListBox.Items.Clear();


                foreach (FontFamily oFamily in oInstalledFonts.Families)
                {
                    if (oFamily.Name.ToLower().StartsWith(pattern.ToLower()))
                    {
                        policesListBox.Items.Add(oFamily.Name);
                    }

                }

            }

        }

        #endregion

        #region Police ListBoxClick

        private void policesListBox_Click(object sender, EventArgs e)
            {
                policeToolStripComboBox.Text = policesListBox.SelectedItem.ToString();

                policesListBox.Visible = false;
            }

        #endregion

        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                try
                {
                    JoueurForm oJoueur = (JoueurForm)this.ActiveMdiChild;

                    RechercheForm oRecherche = new RechercheForm();

                    oRecherche.rechercheTextBox.SelectedText = oJoueur.infoRichTextBox.SelectedText;

                    oRecherche.Owner = this;

                    oRecherche.Mot = oJoueur.infoRichTextBox.SelectedText;

                    oRecherche.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CECreationNouveauEnfantErreur]);
                }

            }
               
        }
    }
}
