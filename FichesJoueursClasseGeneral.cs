/*

    Programmeurs:   Alexandre Roy, Cyrille Fidjio, Jérémie Rousselle, Stéphane Nkontie
    Date:           22 Octobre 2024

    But:            Devoir 2 (Phase F) - Fiche des joueurs

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
            CEErreurGeneral,
            CEErreurExtensionInvalide,
            CEErreurFichierVide
        }

        #endregion

        #region Message d'erreurs

        public static string[] tabMessagesErreursStr = new string[5];
        public const string ErreurCreationEnfant = "Le fichier enfant n'as pu être crée.";
        public const string ErreurIndexEnfant = "Numero du formulaire enfant invalide.";
        public const string ErreurGeneral = "Une erreur c'est produite. Contactez le programmeur";
        public const string ErreurExtension = "Vous ne pouvez ouvrir que des fichiers portant l'extension .rtf avec  l'application FichesJoueurs";
        public const string ErreurFichierVide = "Vous ne pouvez pas enregistrer des fichiers vides.";

        #endregion

        #region Méthodes publiques - partagées

        #region Initialisation des messages d'erreurs
        public static void InitMessagesErreur()
        {
            tabMessagesErreursStr[(int)ce.CECreationNouveauEnfantErreur] = ErreurCreationEnfant;
            tabMessagesErreursStr[(int)ce.CENumeroFormulaireInvalide] = ErreurIndexEnfant;
            tabMessagesErreursStr[(int)ce.CEErreurGeneral] = ErreurGeneral;
            tabMessagesErreursStr[(int)ce.CEErreurExtensionInvalide] = ErreurExtension;
            tabMessagesErreursStr[(int)ce.CEErreurFichierVide] = ErreurFichierVide;
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
