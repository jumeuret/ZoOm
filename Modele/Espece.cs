using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    /// <summary>
    /// Classe permettant de construire des espèces
    /// </summary>
    [DataContract]
    public class Espece : INotifyPropertyChanged
    {
        string nom;
        string nomLatin;
        string habitat;
        List<string> particularités;
        string prédateurs;
        int ageRecord;
        int ageRecordCaptivite;
        float tailleRecord;
        float poidsRecord;
        string carte;
        Alimentation regime;
        Statut statut;

        /// <summary> 
        ///Constructeur d'espèces 
        /// </summary>
        public Espece(string nomEspece, string nomLatinEspece, string habitatEspece, List<string> particularitésEspece,
        string prédateursEspece, int ageRecordEspece, int ageRecordCaptiviteEspece, float tailleRecordEspece, float poidsRecordEspece,
        string carteEspece, Alimentation regimeAnimal, Statut statutAnimal)
        {
            Nom = nomEspece;
            NomLatin = nomLatinEspece;
            Habitat = habitatEspece;
            Particularités = particularitésEspece;
            Prédateurs = prédateursEspece;
            AgeRecord = ageRecordEspece;
            AgeRecordCaptivite = ageRecordCaptiviteEspece;
            TailleRecord = tailleRecordEspece;
            PoidsRecord = poidsRecordEspece;
            Carte = carteEspece;
            Regime = regimeAnimal;
            Statut = statutAnimal;
        }

        [DataMember]
        /// <summary> 
        /// Nom de l'espèce 
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
        /// Nom latin de l'espèce 
        /// </summary>
        public string NomLatin
        {
            get => nomLatin;
            set
            {
                nomLatin= value;
                OnPropertyChanged(nameof(NomLatin));
            }
        }

        [DataMember]
        /// <summary> 
        /// Habitat de l'espèce 
        /// </summary>
        public string Habitat
        {
            get => habitat;
            set
            {
                habitat = value;
                OnPropertyChanged(nameof(Habitat));
            }
        }

        [DataMember]
        /// <summary> 
        /// Liste de particularités de l'espèce 
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
        /// Prédateurs de l'espèce 
        /// </summary>
        public string Prédateurs
        {
            get => prédateurs;
            set
            {
                prédateurs = value;
                OnPropertyChanged(nameof(Prédateurs));
            }
        }

        [DataMember]
        /// <summary> 
        /// Age maximal de l'espèce 
        /// </summary>
        public int AgeRecord
        {
            get => ageRecord;
            set
            {
                ageRecord = value;
                OnPropertyChanged(nameof(AgeRecord));
            }
        }

        [DataMember]
        /// <summary> 
        /// Age maximal en captivité de l'espèce 
        /// </summary>
        public int AgeRecordCaptivite
        {
            get => ageRecordCaptivite;
            set
            {
                ageRecordCaptivite = value;
                OnPropertyChanged(nameof(AgeRecordCaptivite));
            }
        }

        [DataMember]
        /// <summary> 
        /// Taille maximale de l'espèce 
        /// </summary>
        public float TailleRecord
        {
            get => tailleRecord;
            set
            {
                tailleRecord = value;
                OnPropertyChanged(nameof(TailleRecord));
            }
        }

        [DataMember]
        /// <summary> 
        /// Poids maximal de l'espèce 
        /// </summary>
        public float PoidsRecord
        {
            get => poidsRecord;
            set
            {
                poidsRecord = value;
                OnPropertyChanged(nameof(PoidsRecord));
            }
        }

        [DataMember]
        /// <summary> 
        /// Répartition géographique de l'espèce l'espèce 
        /// </summary>
        public string Carte
        {
            get => carte;
            set
            {
                carte = value;
                OnPropertyChanged(nameof(Carte));
            }
        }

        [DataMember]
        /// <summary> 
        /// Type d'alimentation de l'espèce 
        /// </summary>
        public Alimentation Regime
        {
            get => regime;
            set
            {
                regime = value;
                OnPropertyChanged(nameof(Regime));
            }
        }

        [DataMember]
        /// <summary> 
        /// Statut de conservation de l'espèce 
        /// </summary>
        public Statut Statut
        {
            get => statut;
            set
            {
                statut = value;
                OnPropertyChanged(nameof(Statut));
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
        private void OnPropertyChanged(string propriete)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriete));
        }
    }
}
