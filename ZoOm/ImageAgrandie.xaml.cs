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
    /// Logique d'interaction pour ImageAgrandie.xaml
    /// </summary>
    public partial class ImageAgrandie : Window
    {
        /// <summary>
        /// Constructeur d'ImageAgrandie
        /// </summary>
        /// <param name="animal"></param>
        public ImageAgrandie(Animal animal)
        {
            InitializeComponent();
            CarteEspece.Source = new BitmapImage(new Uri(animal.Espece.Carte, UriKind.Relative));
        }

        /// <summary>
        /// Méthode se déclenchant lorsque la croix est cliquée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Croix_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } 
    }
}
