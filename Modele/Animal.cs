using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    [DataContract]
    /// <summary>
    /// Classe permettant de créer des animaux
    /// </summary>
    public class Animal : IEquatable<Animal>, INotifyPropertyChanged
    {
        string nom;
        Genre genre;
        DateTime dateNaiss;
        Dictionary<DateTime, float> taille;
        Dictionary<DateTime, float> poids;
        List<string> particularités;
        List<string> photos;
        Espece espece;
        Dictionary<DateTime, bool> nourrissage;
        Dictionary<DateTime, bool> nettoyage;
        Dictionary<DateTime, bool> sante;

        /// <summary>
        /// Constructeur d'animaux 
        /// </summary>
        public Animal(string nomAnimal, Genre genreAnimal, DateTime dateNaissAnimal, float tailleAnimal, float poidsAnimal, List<string> particularitésAnimal,
        List<string> photosAnimal, Espece especeAnimal)
        {
            Nom = nomAnimal;
            Genre = genreAnimal;
            DateNaiss = dateNaissAnimal;
            Taille = new Dictionary<DateTime, float>();
            Taille.Add(DateTime.Now, tailleAnimal);
            Poids = new Dictionary<DateTime, float>();
            Poids.Add(DateTime.Now,poidsAnimal);
            Particularités = particularitésAnimal;
            Photos = photosAnimal;
            Espece = especeAnimal;
            Nourrissage = new Dictionary<DateTime, bool>();
            Nourrissage.Add(DateTime.Now, false);
            Nettoyage = new Dictionary<DateTime, bool>();
            Nettoyage.Add(DateTime.Now, false); 
            Sante = new Dictionary<DateTime, bool>();
            Sante.Add(DateTime.Now, false);
        }

        [DataMember]
        /// <summary> 
        /// Nom de l'animal 
        /// </summary>
        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        [DataMember]
        /// <summary> 
        /// Genre de l'animal 
        /// </summary>
        public Genre Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        [DataMember]
        /// <summary> 
        /// Date de naissance de l'animal 
        /// </summary>
        public DateTime DateNaiss
        {
            get => dateNaiss;
            set
            {
                dateNaiss = value;
                OnPropertyChanged(nameof(DateNaiss));
            }
        }

        [DataMember]
        /// <summary> 
        /// Historique de la taille de l'animal 
        /// </summary>
        public Dictionary<DateTime, float> Taille
        {
            get => taille;
            set
            {
                taille = value;
                OnPropertyChanged(nameof(Taille));
            }
        }

        [DataMember]
        /// <summary> 
        /// Historique du poids de l'animal 
        /// </summary>
        public Dictionary<DateTime, float> Poids
        {
            get => poids;
            set
            {
                poids = value;
                OnPropertyChanged(nameof(Poids));
            }
        }

        [DataMember]
        /// <summary> 
        /// Liste des particularités de l'animal 
        /// </summary>
        public List<string> Particularités
        {
            get => particularités;
            set
            {
                particularités = value;
                OnPropertyChanged(nameof(Particularités));
            }
        }

        [DataMember]
        /// <summary> 
        /// Liste des photos de l'animal 
        /// </summary>
        public List<string> Photos
        {
            get => photos;
            set
            {
                photos = value;
                OnPropertyChanged(nameof(Photos));
            }
        }

        [DataMember]
        /// <summary> 
        /// Espece de l'animal 
        /// </summary>
        public Espece Espece
        {
            get => espece;
            set
            {
                espece = value;
                OnPropertyChanged(nameof (Espece));
            }
        }

        [DataMember]
        /// <summary> 
        /// Historique des nourrissages de l'animal 
        /// </summary>
        public Dictionary<DateTime, bool> Nourrissage
        {
            get => nourrissage;
            set
            {
                nourrissage = value;
                OnPropertyChanged(nameof(Nourrissage));
            }
        }

        [DataMember]
        /// <summary> 
        /// Historique des nettoyages de l'enclos de l'animal 
        /// </summary>
        public Dictionary<DateTime, bool> Nettoyage
        {
            get => nettoyage;
            set
            {
                nettoyage = value;
                OnPropertyChanged(nameof(Nettoyage));
            }
        }

        [DataMember]
        /// <summary> 
        /// Historique des visites du vétérinaire de l'animal
        /// </summary>
        public Dictionary<DateTime, bool> Sante
        {
            get => sante;
            set
            {
                sante = value;
                OnPropertyChanged(nameof(Sante));
            }
        }

        /// <summary>
        /// Evênnement permettant de prévenir des modifications des propriétés
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fonction utilisant la propriété ci-dessus pour indiquer qu'une propriété à été modifiée, et de laquelle il s'agit
        /// </summary>
        /// <param name="propriete"></param>
        protected virtual void OnPropertyChanged(string propriete)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriete));
        }

        /// <summary>
        /// Redéfinition de la fonction d'égalité Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Animal);
        }

        /// <summary>
        /// Redéfinition de la fonction d'égalité Equals pour le type Animal
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Equals(Animal a)
        {
            if (nom != a.nom) return false;
            return (espece == a.espece);
        }

        /// <summary> 
        /// Redéfinition de la fonction de hashage pour une collection d'animaux 
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
