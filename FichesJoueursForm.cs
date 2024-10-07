/*
    Programmeurs:   Alexandre Roy, Cyrille Fidjio, Jérémie Rousselle, Stéphane Nkontie
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using c = FichesJoueurs.FichesJoueursClasseGeneral;

namespace FichesJoueurs
{
    public partial class FichesJoueursParent : Form
    {
        #region Variables

        private int nbClients = 1;

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
            c.InitMessagesErreur();
            AssocierImages();
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
                oJoueur.Text += " " + (nbClients).ToString();
                oJoueur.Show();
                nbClients++;
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

        #endregion
    }
}
