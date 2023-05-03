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
using System.Windows.Shapes;

namespace ZoOm
{
    /// <summary>
    /// Logique d'interaction pour PageRecherche.xaml
    /// </summary>
    public partial class PageRecherche : Window
    {
        /// <summary>
        /// Propriété permettant de récupérer les résultats de la recherche
        /// </summary>
        List<Animal> Resultats;

        /// <summary>
        /// Constructeur de PageRecherche
        /// </summary>
        /// <param name="resultats"></param>
        public PageRecherche(List<Animal> resultats)
        {
            InitializeComponent();
            Resultats = resultats;
            UC_Animal_Item ucAnimal = new UC_Animal_Item(resultats[0]);
            UC_Aniaml_ItemCc.Content = ucAnimal;
        }

        /// <summary>
        /// Fonction se déclenchant lorsque que le résultat de la recherche est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (Resultats.Count > 0)
            {
                (Application.Current.MainWindow as MainWindow).mainWindowAnimalCc.Content = new UC_Animal(Resultats[0]);
            }
            Close();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le bouton Quitter de la page est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Non_Click(object sender, RoutedEventArgs e)
        {
            Close();
            (Application.Current.MainWindow as MainWindow).mainWindowAnimalCc.Content = new UC_Home();
        }
    }
}
