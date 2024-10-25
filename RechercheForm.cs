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
    public partial class RechercheForm : Form
    {

        #region Variables

        String MotString = String.Empty;

        #endregion

        #region Initialisation
            public RechercheForm()
            {
                InitializeComponent();
            }

        #endregion

        #region Proprietes

        public String Mot
            {
                get
                {
                    return MotString;
                }
                set
                {
                    MotString = value;
                }
            }

        #endregion

        #region Recherche TextBox_TextChanged
            private void rechercheTextBox_TextChanged(object sender, EventArgs e)
            {
                Mot = rechercheTextBox.Text;

            }

        #endregion

        #region Suivant Click sur le bouton

            private void suivantButton_Click(object sender, EventArgs e)
            {

                try
                {
                    DialogResult = DialogResult.None;

                    JoueurForm oJoueur = (JoueurForm)this.Owner.ActiveMdiChild;

                    RichTextBox oRichTextBox = oJoueur.infoRichTextBox;

                    int positionDepartInt = oRichTextBox.SelectionStart;

                    if(oRichTextBox.SelectionLength == 0) 
                    {

                        if (oRichTextBox.Find(Mot, positionDepartInt, RichTextBoxFinds.None) == -1)
                            oRichTextBox.Find(Mot, 0, RichTextBoxFinds.None);
                 
                    }
                    else
                    {
                        if (oRichTextBox.Find(Mot, positionDepartInt + 1, RichTextBoxFinds.None) == -1)
                            oRichTextBox.Find(Mot, 0, RichTextBoxFinds.None);
                    }
                }
                catch(Exception) 
                { 
                    MessageBox.Show(c.tabMessagesErreursStr[(int)c.CodeErreurs.CEErreurGeneral]);
                }

            }
        #endregion

        #region Fermeture du formulaire
            private void annulerButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion

    }
}
