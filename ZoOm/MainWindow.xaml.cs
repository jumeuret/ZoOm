using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Business;
using Modele;
using Persistance;

namespace ZoOm
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Propriété permettant de récupérer de manager de l'application
        /// </summary>
        public Manager Mgr
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }

        /// <summary>
        /// Constructeur de MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Mgr.ChargerDonnées();
            var animaux = Mgr.Animaux;
            var especes = Mgr.ListEspeces();

            var animalCourant = Mgr.AnimalCourant;

            UC_Animal UC_Animal = new UC_Animal(animalCourant);
            mainWindowAnimalCc.Content = UC_Animal;

            UC_Connexion UC_Connexion = new UC_Connexion();
            mainWindowConnexionCc.Content = UC_Connexion;

            UC_ZoneBlanche UC_ZoneBlanche = new UC_ZoneBlanche();
            mainWindowDirecteur_SoigneurCc.Content = UC_ZoneBlanche;

            UC_IconeAjoutAnimal UC_IconeAjoutAnimal = new UC_IconeAjoutAnimal();
            mainWindowIconeAjoutAnimalCc.Content = UC_IconeAjoutAnimal;

            UC_ZoneBlanche UC_ZoneBlanche1 = new UC_ZoneBlanche();
            mainWindowIconeAjoutAnimalCc.Content = UC_ZoneBlanche1;

            UC_ZoneBlanche UC_ZoneBlanche2 = new UC_ZoneBlanche();
            mainWindowDirecteur_SoigneurCc.Content= UC_ZoneBlanche2;

            UC_Animal_Item ucAnimal1 = new UC_Animal_Item(animaux[0]);
            AnimalItem1.Content = ucAnimal1;
            UC_Animal_Item ucAnimal2 = new UC_Animal_Item(animaux[1]);
            AnimalItem2.Content = ucAnimal2;
            UC_Animal_Item ucAnimal3 = new UC_Animal_Item(animaux[2]);
            AnimalItem3.Content = ucAnimal3;
            UC_Animal_Item ucAnimal4 = new UC_Animal_Item(animaux[3]);
            AnimalItem4.Content = ucAnimal4;

            EspeceItem1.Content = especes[0];
            EspeceItem2.Content = especes[1];
            EspeceItem3.Content = especes[2];
            EspeceItem4.Content = especes[3];
        }

        /// <summary>
        /// Fonction se déclenchant au chargement de la mainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="c"></param>
        private void Window_Loaded(object sender, RoutedEventArgs c)
        {
            Mgr?.ChargerDonnées();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque l'UC_Connexion est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageConnexion fenetre = new PageConnexion();
            fenetre.Show();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le logo est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindowAnimalCc.Content = new UC_Home();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le premier animal de la liste est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimalItem1_Click(object sender, RoutedEventArgs e)
        {
            mainWindowAnimalCc.Content = new UC_Animal(Mgr.Animaux[0]);
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le deuxième animal de la liste est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimalItem2_Click(object sender, RoutedEventArgs e)
        {
            mainWindowAnimalCc.Content = new UC_Animal(Mgr.Animaux[1]);
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le troisième animal de la liste est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimalItem3_Click(object sender, RoutedEventArgs e)
        {
            mainWindowAnimalCc.Content = new UC_Animal(Mgr.Animaux[2]);
        }

        /// <summary>
        /// Fonction se déclenchant lorsque le quatrième animal de la liste est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimalItem4_Click(object sender, RoutedEventArgs e)
        {
            mainWindowAnimalCc.Content = new UC_Animal(Mgr.Animaux[3]);
        }

        /// <summary>
        /// Fonction se déclenchant lorsque la première espèce de la liste est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EspeceItem1_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> res = Mgr.RechercherAnimal(Mgr.ListEspeces()[0]);
            PageRecherche page_recherche = new PageRecherche(res);
            page_recherche.Show();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque la deuxième espèce de la liste est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EspeceItem2_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> res = Mgr.RechercherAnimal(Mgr.ListEspeces()[1]);
            PageRecherche page_recherche = new PageRecherche(res);
            page_recherche.Show();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque la troisième espèce de la liste est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EspeceItem3_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> res = Mgr.RechercherAnimal(Mgr.ListEspeces()[2]);
            PageRecherche page_recherche = new PageRecherche(res);
            page_recherche.Show();
        }

        /// <summary>
        /// Fonction se déclenchant lorsque la quatrième espèce de la liste est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EspeceItem4_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> res = Mgr.RechercherAnimal(Mgr.ListEspeces()[3]);
            PageRecherche page_recherche = new PageRecherche(res);
            page_recherche.Show();
        }
    }
}