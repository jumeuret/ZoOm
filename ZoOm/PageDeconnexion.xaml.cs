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
    /// Logique d'interaction pour PageDeconnexion.xaml
    /// </summary>
    public partial class PageDeconnexion : Window
    {
        /// <summary>
        /// Constructeur de PageDeconnexion
        /// </summary>
        public PageDeconnexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le bouton Oui de la page est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouiButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            (Application.Current.MainWindow as MainWindow).mainWindowConnexionCc.Content = new UC_Connexion();
            (Application.Current.MainWindow as MainWindow).mainWindowDirecteur_SoigneurCc.Content = new UC_ZoneBlanche();
            (Application.Current.MainWindow as MainWindow).mainWindowIconeAjoutAnimalCc.Content = new UC_ZoneBlanche();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le bouton Non de la page est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nonButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
