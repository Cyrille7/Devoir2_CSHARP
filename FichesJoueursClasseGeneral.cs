/*
<<<<<<< HEAD
    Programmeurs:   Alexandre Roy, Cyrille Sonfack, Jérémie Rousselle, Stéphane Nkontie
    Date:           10 Octobre 2024
=======
    Programmeurs:   Alexandre Roy, Cyrille Fidjio, Jérémie Rousselle, Stéphane Nkontie
    Date:           7 Octobre 2024
>>>>>>> f4c2721aaabe6280785dd4e9822e2deecca29016
    But:            Devoir 2 (Phase B) - Fiche des joueurs

    Projet:         FichesJoueurs.csproj
    Solution:       FichesJoueurs.sln
    Classes:        FichesJoueursClasseGeneral.cs       

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ce = FichesJoueurs.FichesJoueursClasseGeneral.CodeErreurs;

namespace FichesJoueurs
{
    internal class FichesJoueursClasseGeneral
    {
        #region Enumération

        public enum CodeErreurs
        {
            CECreationNouveauEnfantErreur,
            CENumeroFormulaireInvalide,
        }

        #endregion

        #region Message d'erreurs

        public static string[] tabMessagesErreursStr = new string[2];
        public const string ErreurCreationEnfant = "Le fichier enfant n'as pu être crée.";
        public const string ErreurIndexEnfant = "Numero du formulaire enfant invalide.";

        #endregion

        #region Méthodes publiques - partagées

        #region Initialisation des messages d'erreurs
        public static void InitMessagesErreur()
        {
            tabMessagesErreursStr[(int)ce.CECreationNouveauEnfantErreur] = ErreurCreationEnfant;
            tabMessagesErreursStr[(int)ce.CENumeroFormulaireInvalide] = ErreurIndexEnfant;
        }
        #endregion

        #region Enlever le crochet sur les sous menu

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

        #endregion

        
    }
}
