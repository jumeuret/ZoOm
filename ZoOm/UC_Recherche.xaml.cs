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
    /// Logique d'interaction pour UC_Recherche.xaml
    /// </summary>
    public partial class UC_Recherche : UserControl
    {
        string Rech { get; set; }

        public UC_Recherche()
        {
            InitializeComponent();
        }

        private void Loupe_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> res = new List<Animal>();
            PageRecherche page_recherche = new PageRecherche(res);
            page_recherche.Show();
        }
    }
}
