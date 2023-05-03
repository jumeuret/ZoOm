using Business;
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
    /// Logique d'interaction pour UC_ajoutAnimal.xaml
    /// </summary>
    public partial class UC_ajoutAnimal : UserControl
    {
        public Manager Mgr
        {
            get
            {
                return (Application.Current as App).LeManager;
            }
        }
        public Animal Animal { get; set; }

        public UC_ajoutAnimal()
        {
            InitializeComponent();
        }

        public void AjouterAnimal()
        {
            InitializeComponent();
            Animal = new Animal("", 0, new DateTime(01,01,0001), 0, 0, new List<string>(), 
            new List<string>(), new Espece("", "", "", new List<string>(), "", 0, 
            0, 0, 0, "", 0, 0));
            DataContext = Animal;

            Animal.Photos.Add(Photos.Text);
            Animal.Particularités.Add(Particularite1.Text);
            Animal.Particularités.Add(Particularite2.Text);
            Animal.Espece.Particularités.Add(ParticulariteE1.Text);
            Animal.Espece.Particularités.Add(ParticulariteE2.Text);
            Animal.Espece.Nom = NomE.Text;
            Animal.Espece.NomLatin = NomLatin.Text;
            Animal.Nom = Nom.Text;
            Genre genre;
            //Animal.Genre = Genre.Parse(Genre.Text);
            Animal.DateNaiss = DateTime.Parse(DateNaiss.Text);
            Animal.Espece.Habitat = Habitat.Text;
            //Animal.Espece.Statut = Statut.Parse(Statut.Text);
            //Animal.Espece.Regime = Alimentation.Parse(Alimentation.Text);
            Animal.Espece.Prédateurs = Predateurs.Text;
            Animal.Espece.AgeRecord = int.Parse(AgeRecord.Text);
            Animal.Espece.AgeRecordCaptivite = int.Parse(AgeRecordCaptivite.Text);
            Animal.Espece.TailleRecord = float.Parse(TailleRecord.Text);
            Animal.Espece.PoidsRecord = float.Parse(PoidsRecord.Text);


            DateTime min = DateTime.MinValue;
            foreach (DateTime cle in Animal.Taille.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            tailleAnimal.Text = Animal.Taille[min].ToString();

            min = DateTime.MinValue;
            foreach (DateTime cle in Animal.Poids.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            poidsAnimal.Text = Animal.Poids[min].ToString();
        }

        private void Button_Annuler_Click(object sender, RoutedEventArgs arg)
        {
            (Application.Current.MainWindow as MainWindow).mainWindowAnimalCc.Content = new UC_Home();
            return;
        }

        private void Button_Confirmer_Click(object sender, RoutedEventArgs arg)
        {
            Mgr.AjouterAnimal(new Animal(Animal.Nom, Animal.Genre, Animal.DateNaiss, float.Parse(tailleAnimal.Text),
            float.Parse(poidsAnimal.Text), Animal.Particularités, Animal.Photos, new Espece(Animal.Espece.Nom, Animal.Espece.NomLatin,
            Animal.Espece.Habitat, Animal.Espece.Particularités, Animal.Espece.Prédateurs, Animal.Espece.AgeRecord,
            Animal.Espece.AgeRecordCaptivite, Animal.Espece.TailleRecord, Animal.Espece.PoidsRecord, Animal.Espece.Carte,
            Animal.Espece.Regime, Animal.Espece.Statut)));
            (Application.Current.MainWindow as MainWindow).mainWindowAnimalCc.Content = new UC_Home();
            return;
        }
    }
}
