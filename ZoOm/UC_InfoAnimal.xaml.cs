using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZoOm
{
    /// <summary>
    /// Logique d'interaction pour UC_InfoAnimal.xaml
    /// </summary>
    public partial class UC_InfoAnimal : UserControl
    {
        Animal Animalcourant;
        public UC_InfoAnimal(Animal animal)
        {
            InitializeComponent();
            Animalcourant = animal;

            DateTime min = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Nourrissage.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            NourrissageDate.Text = min.Date.ToString().TrimEnd('0', ':');

            min = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Nettoyage.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            NettoyageDate.Text = min.Date.ToString().TrimEnd('0', ':');

            min = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Sante.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            SanteDate.Text = min.Date.ToString().TrimEnd('0',':');
        }

        private void Horloge_Click(object sender, RoutedEventArgs e)
        {
            DateTime min = DateTime.MinValue;
            DateTime min2 = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Nourrissage.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                    min2 = min;
                }
            }
            NourrissageHistorique.Text = min2.Date.ToString().TrimEnd('0', ':');

            min = DateTime.MinValue;
            min2 = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Nettoyage.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                    min2 = min;
                }
            }
            NettoyageHistorique.Text = min2.Date.ToString().TrimEnd('0', ':');

            min = DateTime.MinValue;
            min2 = DateTime.MinValue;
            foreach (DateTime cle in Animalcourant.Sante.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                    min2 = min;
                }
            }
            SanteHistorique.Text = min2.Date.ToString().TrimEnd('0', ':');
        }

        private void Croix_Click(object sender, RoutedEventArgs e)
        {
            NourrissageHistorique.Text = "";
            NettoyageHistorique.Text = "";
            SanteHistorique.Text = "";
        }

    }
}
            
