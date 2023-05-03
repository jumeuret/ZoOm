using System;
using Modele;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Business
{
    /// <summary>
    /// Classe utilisant les implémentations de IPersistanceManager pour gérer les données de l'application
    /// </summary>
    public class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// L'animal sélectionné dans ZoOm
        /// </summary>
        Animal animalCourant;

        /// <summary>
        /// Liste de tous les animaux
        /// </summary>
        private List<Animal> animaux = new List<Animal>();

        /// <summary>
        /// Constructeur de manager
        /// </summary>
        /// <param name="pers"></param>
        public Manager(IPersistanceManager pers)
        {
            Pers = pers;
            Animaux = new ReadOnlyCollection<Animal>(animaux);
        }

        /// <summary>
        /// Propriété de l'IPersistanceManager
        /// </summary>
        public IPersistanceManager Pers { get; set; }

        /// <summary>
        /// Propriété de la liste animaux
        /// </summary>
        public ReadOnlyCollection<Animal> Animaux { get; private set; }

        /// <summary>
        /// Propriété de l'attribut animalCourant
        /// </summary>
        public Animal AnimalCourant
        {
            get => animalCourant;
            set
            {
                if (animalCourant == value)
                {
                    return;
                }
                animalCourant = value;
                OnPropertyChanged(nameof(AnimalCourant));
            }
        }

        /// <summary>
        /// Evenemment permettant de prévenir le changement des données dans le code des données affichées par ZoOm
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fonction utilisant l'évênement PropertyChangedEventArgs en lui renvoyant le nom de l'élément ayant reçu des modifications
        /// </summary>
        /// <param name="nomPropriete"></param>
        private void OnPropertyChanged(string nomPropriete)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        /// <summary>
        /// Fonction permettant au Manager de récupérer les données persistées par IPersistanceManager
        /// </summary>
        public void ChargerDonnées()
        {
            animaux.Clear();
            animaux.AddRange(Pers.ChargerDonnées());
            if (animaux.Count <= 0)
            {
                return;
            }
            AnimalCourant = animaux[0];
        }

        /// <summary>
        /// Fonction permettant au Manager de sauvegarder les données grâce à IPersistanceManager
        /// </summary>
        public void SauvegarderDonnées()
        {
            Pers.SauvegarderDonnées(animaux);
        }

        /// <summary>
        /// Fonction créant et retournant la liste de toutes les espèces des animaux
        /// </summary>
        /// <returns></returns>
        public List<string> ListEspeces()
        {
            List<string> especes = new List<string>();
            foreach (Animal a in animaux)
            {
                if (!especes.Contains(a.Espece.Nom))
                {
                    especes.Add(a.Espece.Nom);
                }
            }
            if (especes.Count <= 0)
            {
                return null;
            }
            especes.Sort();
            return especes;
        }

        /// <summary>
        /// Fonction permettant d'ajouter un animal
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool AjouterAnimal(Animal animal)
        {
            if (animaux.Contains(animal))
            {
                return false;
            }
            animaux.Add(animal);
            Pers.SauvegarderDonnées(animaux);
            return true;
        }

        /// <summary>
        /// Fonction permettant de modifier un animal
        /// </summary>
        /// <param name="ancien"></param>
        /// <param name="nouveau"></param>
        /// <returns></returns>
        public bool ModifierAnimal(Animal ancien, Animal nouveau)
        {
            if (ancien.Equals(nouveau))
            {
                return false;
            }

            if (!ancien.Taille.Equals(nouveau.Taille))
            {
                DateTime maxA = DateTime.MinValue;
                foreach (DateTime cle in ancien.Taille.Keys)
                {
                    if (maxA < cle)
                    {
                        maxA = cle;
                    }
                }
                DateTime maxN = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Nourrissage.Keys)
                {
                    if (maxN < cle)
                    {
                        maxN = cle;
                    }
                }
                foreach (KeyValuePair<DateTime, float> cleValeur in nouveau.Taille)
                {
                    if (cleValeur.Key != maxN)
                    {
                        nouveau.Nourrissage.Remove(cleValeur.Key);
                    }
                }
                foreach (KeyValuePair<DateTime, float> cleValeur in ancien.Taille)
                {
                    if (cleValeur.Key != maxA)
                    {
                        nouveau.Taille.Add(cleValeur.Key, cleValeur.Value);
                    }
                }
            }

            if (!ancien.Poids.Equals(nouveau.Poids))
            {
                DateTime maxA = DateTime.MinValue;
                foreach (DateTime cle in ancien.Poids.Keys)
                {
                    if (maxA < cle)
                    {
                        maxA = cle;
                    }
                }
                DateTime maxN = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Poids.Keys)
                {
                    if (maxN < cle)
                    {
                        maxN = cle;
                    }
                }
                foreach (KeyValuePair<DateTime, float> cleValeur in nouveau.Poids)
                {
                    if (cleValeur.Key != maxN)
                    {
                        nouveau.Poids.Remove(cleValeur.Key);
                    }
                }
                foreach (KeyValuePair<DateTime, float> cleValeur in ancien.Poids)
                {
                    if (cleValeur.Key != maxA)
                    {
                        nouveau.Poids.Add(cleValeur.Key, cleValeur.Value);
                    }
                }
            }

            if (!ancien.Nourrissage.Equals(nouveau.Nourrissage))
            {
                DateTime maxA = DateTime.MinValue;
                foreach (DateTime cle in ancien.Nourrissage.Keys)
                {
                    if (maxA < cle)
                    {
                        maxA = cle;
                    }
                }
                DateTime maxN = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Nourrissage.Keys)
                {
                    if (maxN < cle)
                    {
                        maxN = cle;
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in nouveau.Nourrissage)
                {
                    if (cleValeur.Key != maxN)
                    {
                        nouveau.Nourrissage.Remove(cleValeur.Key);
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in ancien.Nourrissage)
                {
                    if (cleValeur.Key != maxA)
                    {
                        nouveau.Nourrissage.Add(cleValeur.Key, cleValeur.Value);
                    }
                }
            }

            if (!ancien.Nettoyage.Equals(nouveau.Nettoyage))
            {
                DateTime maxA = DateTime.MinValue;
                foreach (DateTime cle in ancien.Nettoyage.Keys)
                {
                    if (maxA < cle)
                    {
                        maxA = cle;
                    }
                }
                DateTime maxN = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Nettoyage.Keys)
                {
                    if (maxN < cle)
                    {
                        maxN = cle;
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in nouveau.Nettoyage)
                {
                    if (cleValeur.Key != maxN)
                    {
                        nouveau.Nettoyage.Remove(cleValeur.Key);
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in ancien.Nettoyage)
                {
                    if (cleValeur.Key != maxA)
                    {
                        nouveau.Nettoyage.Add(cleValeur.Key, cleValeur.Value);
                    }
                }
            }

            if (!ancien.Sante.Equals(nouveau.Sante))
            {
                DateTime maxA = DateTime.MinValue;
                foreach (DateTime cle in ancien.Sante.Keys)
                {
                    if (maxA < cle)
                    {
                        maxA = cle;
                    }
                }
                DateTime maxN = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Sante.Keys)
                {
                    if (maxN < cle)
                    {
                        maxN = cle;
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in nouveau.Sante)
                {
                    if (cleValeur.Key != maxN)
                    {
                        nouveau.Sante.Remove(cleValeur.Key);
                    }
                }
                foreach (KeyValuePair<DateTime, bool> cleValeur in ancien.Sante)
                {
                    if (cleValeur.Key != maxA)
                    {
                        nouveau.Sante.Add(cleValeur.Key, cleValeur.Value);
                    }
                }
            }
            int index = animaux.IndexOf(ancien);
            animaux.Remove(ancien);
            animaux.Insert(index, nouveau);
            Pers.SauvegarderDonnées(animaux);
            return true;
        }

        /// <summary>
        /// Fonction permettant d'actualiser les informations d'un animal
        /// </summary>
        /// <param name="ancien"></param>
        /// <param name="nouveau"></param>
        /// <returns></returns>
        public bool ActualiserAnimal(Animal ancien, Animal nouveau)
        {
            if (ancien.Equals(nouveau))
            {
                return false;
            }
            if (!ancien.Taille.Equals(nouveau.Taille))
            {
                DateTime maxT = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Taille.Keys)
                {
                    if (maxT < cle)
                    {
                        maxT = cle;
                    }
                }
                float val = nouveau.Taille[maxT];
                ancien.Taille.Add(maxT,val);
            }
            if (!ancien.Poids.Equals(nouveau.Poids))
            {
                DateTime maxP = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Poids.Keys)
                {
                    if (maxP < cle)
                    {
                        maxP = cle;
                    }
                }
                float val = nouveau.Poids[maxP];
                ancien.Poids.Add(maxP, val);
            }
            if (!ancien.Nourrissage.Equals(nouveau.Nourrissage))
            {
                DateTime maxNo = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Nourrissage.Keys)
                {
                    if (maxNo < cle)
                    {
                        maxNo = cle;
                    }
                }
                bool val = nouveau.Nourrissage[maxNo];
                ancien.Nourrissage.Add(maxNo, val);
            }
            if (!ancien.Nettoyage.Equals(nouveau.Nettoyage))
            {
                DateTime maxNe = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Nettoyage.Keys)
                {
                    if (maxNe < cle)
                    {
                        maxNe = cle;
                    }
                }
                bool val = nouveau.Nettoyage[maxNe];
                ancien.Nettoyage.Add(maxNe, val);
            }
            if (!ancien.Sante.Equals(nouveau.Sante))
            {
                DateTime maxS = DateTime.MinValue;
                foreach (DateTime cle in nouveau.Sante.Keys)
                {
                    if (maxS < cle)
                    {
                        maxS = cle;
                    }
                }
                bool val = nouveau.Sante[maxS];
                ancien.Sante.Add(maxS, val);
            }
            Pers.SauvegarderDonnées(animaux);
            return true;
        }

        /// <summary>
        /// Fonction permettant de rechercher des animaux dont le nom ou l'espèce correspond totalement ou en partie au contenu de param
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Animal> RechercherAnimal(string param)
        {
            List<Animal> res = new List<Animal>();
            param = "[a-zA-Z]*" + param + "[a-zA-Z]*";
            List<string> especes = ListEspeces();
            foreach (Animal a in Animaux)
            {
                if (Regex.IsMatch(a.Espece.Nom, param, RegexOptions.IgnoreCase))
                {
                    if (!res.Contains(a))
                    {
                        res.Add(a);
                    }
                }
                if (Regex.IsMatch(a.Nom, param, RegexOptions.IgnoreCase))
                {
                    if (!res.Contains(a))
                    {
                        res.Add(a);
                    }
                }
            }
            return res;
        }
    }
}
