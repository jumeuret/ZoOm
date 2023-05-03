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
using Modele;

namespace ZoOm
{
    ///<summary>
    /// Logique d'interaction pour UC_Animal_Item.xaml
    ///</summary>
    public partial class UC_Animal_Item : UserControl
    {
        public UC_Animal_Item(Animal animal)
        {
            InitializeComponent();
            NomAnimal.Text = animal.Nom;
            NomEspece.Text = animal.Espece.Nom;
            ImageAnimal.Source = new BitmapImage(new Uri(animal.Photos[0], UriKind.Relative));
        }

        public string Nom
        {
            get { return (string)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomProperty =
            DependencyProperty.Register("Nom", typeof(string), typeof(UC_Animal_Item), new PropertyMetadata("Bertenilde"));

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(string), typeof(UC_Animal_Item), new PropertyMetadata("/Chamois/Bertenilde.png"));

        public Espece Espece
        {
            get { return (Espece)GetValue(EspeceProperty); }
            set { SetValue(EspeceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Espece.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EspeceProperty =
            DependencyProperty.Register("Espece", typeof(Espece), typeof(UC_Animal_Item), new PropertyMetadata(new Espece("Chamois", "Rupicapra rupicapra", "Montagnes",
            new List
            <string>() { "Peuvent se déplacer sur des parois presques verticales", "Courent sur les parois en question", },
            "Aigle Royal, Renard, Ours Brun, Loups, Lynx, Oiseaux", 25, 40, (float)0.80, (float)60.5, "Chamois.jpg", Alimentation.Herbivore,
            Statut.PreoccupationMineure)));

    }
}