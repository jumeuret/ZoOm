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
    /// Logique d'interaction pour UC_IconeSoigneur.xaml
    /// </summary>
    public partial class UC_IconeSoigneur : UserControl
    {
        public UC_IconeSoigneur()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageDeconnexion page_deconnexion = new PageDeconnexion();
            page_deconnexion.Show();
        }
    }
}
