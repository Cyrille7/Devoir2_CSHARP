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

namespace FichesJoueurs
{
    public partial class JoueurForm : Form
    {
        public static int nombre = 0;
        public JoueurForm()
        {
            InitializeComponent();
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
    }
}
