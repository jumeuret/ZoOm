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
    /// Logique d'interaction pour PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion : Window
    {
        /// <summary>
        /// Constructeur de PageConnexion
        /// </summary>
        public PageConnexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le mot de passe incorrect est complètement effacé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "")
            {
                statusText.Text = "";
                return;
            }
        }
        /// <summary>
        /// Fonction se déclenchant lorsque le bouton Se connecter de la page est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Password == "lapin") 
            {
                Close();
                (Application.Current.MainWindow as MainWindow).mainWindowConnexionCc.Content = new UC_ZoneBlanche();
                (Application.Current.MainWindow as MainWindow).mainWindowDirecteur_SoigneurCc.Content = new UC_IconeSoigneur();
                (Application.Current.MainWindow as MainWindow).mainWindowIconeAjoutAnimalCc.Content = new UC_IconeAjoutAnimal();
                return;
            }
            else if(passwordBox.Password == "kangourou")
            {
                Close();
                (Application.Current.MainWindow as MainWindow).mainWindowConnexionCc.Content = new UC_ZoneBlanche();
                (Application.Current.MainWindow as MainWindow).mainWindowDirecteur_SoigneurCc.Content = new UC_IconeDirecteur();
                (Application.Current.MainWindow as MainWindow).mainWindowIconeAjoutAnimalCc.Content = new UC_IconeAjoutAnimal();
                //(Application.Current.MainWindow as MainWindow).mainWindowAnimalBoutonCc.Content = new UC_IconeModificationAnimal();
            }
            else
            {
                statusText.Text = "Mot de passe incorrect";
            }
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le bouton Retour de la page est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
