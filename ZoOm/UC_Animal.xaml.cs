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
using Modele;

namespace ZoOm
{
    /// <summary>
    /// Logique d'interaction pour UC_Animal.xaml
    /// </summary>
    public partial class UC_Animal : UserControl
    {
        int PhotoCourante;
        public UC_Animal(Animal animal)
        {
            InitializeComponent();
            Animal = animal;
            DataContext = Animal;
            PhotoCourante = 0;

            Part1Animal.Text = Animal.Particularités[0];
            if (Animal.Particularités.Count > 1)
            {
                Part2Animal.Text = Animal.Particularités[1];
            }

            Part1Espece.Text = Animal.Espece.Particularités[0];
            if (Animal.Espece.Particularités.Count > 1)
            {
                Part2Espece.Text = Animal.Espece.Particularités[1];
            }

            UC_Icone_Modification U_Modification = new UC_Icone_Modification();
            UCanimalIconeActualiserCc.Content = U_Modification;

            UC_affichageCarte UC_affichageCarte = new UC_affichageCarte(Animal);
            affichageCarteCc.Content = UC_affichageCarte;

            ImageAgrandie ImageAgrandie = new ImageAgrandie(Animal);

            UC_InfoAnimal UC_InfoAnimal = new UC_InfoAnimal(Animal);
            UC_InfosAnimalCc.Content = UC_InfoAnimal;

            PhotoAnimal.Source = new BitmapImage(new Uri(Animal.Photos[PhotoCourante],UriKind.Relative));

            DateTime min = DateTime.MinValue;
            foreach (DateTime cle in Animal.Taille.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            tailleText.Text = Animal.Taille[min].ToString() + " m";

            min = DateTime.MinValue;
            foreach (DateTime cle in Animal.Poids.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            poidsText.Text = Animal.Poids[min].ToString() + " kg";
        }

        private void Button_Confirmer_Click(object sender, RoutedEventArgs arg)
        {
            var modifications = new UC_ajoutAnimal();

        }
        private void Changer_Photo_Click(object sender, RoutedEventArgs arg)
        {
            int nbPhotos = Animal.Photos.Count;
            int i = PhotoCourante + 1;
            while (i < nbPhotos)
            {
                PhotoCourante = i;
            }
            PhotoCourante = 0;
        }

        public Animal Animal
        {
            get { return (Animal)GetValue(AnimalProperty); }
            set { SetValue(AnimalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Animal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(Animal), typeof(UC_Animal), new PropertyMetadata(new Animal("Jésus", Genre.Femelle, new DateTime(0001, 01, 01), 
            (float)1.77, 76, new List<string>() {"Transforme l'eau en vin", "A resussité"}, new List<string>() 
            {"Images/Humain/Dieu.jpg"}, new Espece("Humain", "Humanidae", "Partout", new List<string>() {"Bipèdes", 
            "Détruisent tout sur leur passage", }, "Aucun", 100, 120, (float)2.27, (float)320.79, "Images/Humain.jpg", Alimentation.Omnivore, 
            Statut.NonEvaluee))));

    }
}
