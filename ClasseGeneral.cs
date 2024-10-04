/*
    Programmeurs:   Alexandre Roy, Cyrille Sonfack, Jérémie Rousselle, Stéphane Nkontie
    Date:           10 Octobre 2024
    But:            Devoir 2 - Fiche des joueurs

    Projet:         FichesJoueurs.csproj
    Solution:       FichesJoueurs.sln
    Classe:         FichesJoueursForm.cs

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ce = FichesJoueurs.ClasseGeneral.CodeErreurs;

namespace FichesJoueurs
{
    internal class ClasseGeneral
    {
        #region Enumération

        public enum CodeErreurs
        {
            CECreationNouveauEnfantErreur
        }

        #region Message d'erreurs

        public static string[] tabMessagesErreursStr = new string[1];

        public static void InitMessagesErreur()
        {
            tabMessagesErreursStr[(int)ce.CECreationNouveauEnfantErreur] = "Le fichier enfant n'as pu être crée.";
        }

        #endregion

        public static void EnleverCrochetSousMenu(ToolStripMenuItem parentMenu)
        {
            if (parentMenu != null)
            {
                foreach (ToolStripItem otoolStripItem in parentMenu.DropDownItems)
                {
                    if (otoolStripItem is ToolStripMenuItem)
                    {
                        ((ToolStripMenuItem)otoolStripItem).Checked = false;
                    }
                }
            }
        }

        #endregion
    }
}
