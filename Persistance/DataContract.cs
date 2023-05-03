using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using Modele;
using Persistance;

namespace Persistance
{
    /// <summary>
    /// Classe permettant de sauvegarder les données de l'application dans un fichier xml et de les charger à partir de ce fichier
    /// </summary>
    public class DataContract : IPersistanceManager
    {
        /// <summary>
        /// Chemin du fichier d'enregistrement
        /// </summary>
        public string CheminFichier { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        /// <summary>
        /// Nom donné au fichier d'enregistrement
        /// </summary>
        public string NomFichier { get; set; } = "ZoOm.xml";
        /// <summary>
        /// Propriété calculée, concaténant le chemin du fichier d'enregistrement et son nom
        /// </summary>
        string InfosFichier => Path.Combine(CheminFichier, NomFichier);

        /// <summary>
        /// Fonction permettant de lire les données du fichier et de les retourner sous forme d'une liste d'animaux
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public IEnumerable<Animal> ChargerDonnées()
        {
            if (!File.Exists(InfosFichier))
            {
                throw new FileNotFoundException("Le fichier de sauvegarde est manquant...");
            }
            var serializer = new DataContractSerializer(typeof(IEnumerable<Animal>));

            IEnumerable<Animal> animaux;
            using (Stream flux = File.OpenRead(InfosFichier))
            {
                animaux = serializer.ReadObject(flux) as IEnumerable<Animal>;
            }
            return animaux;
        }

        /// <summary>
        /// Fonction permettant de stocker les données dans le fichier d'enregistrement
        /// </summary>
        /// <param name="dataSave"></param>
        public void SauvegarderDonnées(IEnumerable<Animal> dataSave)
        {
            var serializer = new DataContractSerializer(typeof(IEnumerable<Animal>));

            if (!Directory.Exists(CheminFichier))
            {
                Directory.CreateDirectory(CheminFichier);
            }

            var preferences = new XmlWriterSettings() { Indent = true };
            using (TextWriter txtwr = File.CreateText(InfosFichier))
            {
                using (XmlWriter write = XmlWriter.Create(txtwr, preferences))
                {
                    serializer.WriteObject(write, dataSave);
                }
            }
        }
    }
}
