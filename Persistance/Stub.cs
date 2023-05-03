using System;
using Modele;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    /// <summary>
    /// Classe permettant de sauvegarder les données de l'application dans une liste et des recréer les animaux pour simuler une persistance des données
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Propriété donnant accès à la liste des animaux du zoo
        /// </summary>
        List<Animal> animaux;

        /// <summary>
        /// Constructeur de Stub
        /// </summary>
        public Stub()
        {
            List<string> part = new List<string>()
            {
                "Crachent leur salive au visage des gens qu'ils n'aiment pas",
                "Peuvent cracher leur salive à plus de 3 mètres de distance"
            };
            List<string> diego = new List<string>()
            {
                "Mignon",
                "Grognon"
            };
            Espece guanaco = new Espece("Guanaco", "Lama Glama Guanicoe", "Montagnes", part, "Puma, Condor (Jeunes individus)",
            50, 70, (float)1.87, (float)147.2, "\\Guanaco\\guanaco.png", Alimentation.Herbivore, Statut.PreoccupationMineure);
            List<string> img = new List<string>()
            {
                "\\Guanaco\\Diego.png"
            };

            List<string> part2 = new List<string>()
            {
                "Leur appendice caudal peut mesurer jusqu'à la moitié de leur longueur totale",
                "Pratique le cannibalisme intra-utérin"
            };
            List<string> pascal = new List<string>()
            {
                "Kawaii",
                "A l'air stupide mais est intelligent"
            };
            Espece requinRenard = new Espece("Requin Renard", "Alopias vulpinus", "Océans", part2, "Humains",
            50, 70, (float)6.30, (float)440.0, "\\Requin Renard\\requinRenard.png", Alimentation.Piscivore, Statut.Vulnerable);
            List<string> imag = new List<string>()
            {
                "\\Requin Renard\\Pascal.png"
            };

            List<string> cognac = new List<string>() { "Fait la fine bouche quand à son repas" };
            List<string> photo = new List<string>() { "Lynx Boréal/Cognac.png" };
            Espece lynx = new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales", new List<string>() 
            { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png",
            Alimentation.Carnivore, Statut.PreoccupationMineure);

            List<string> carlos = new List<string>() { "Aime se rouler dans le sable" };
            List<string> imagerie = new List<string>() { "Requin Dormeur Mexicain/ Carlos.png" };
            Espece requinDormeurmexicain = new Espece("Requin Dormeur Mexicain", "Heterodontus mexicanus", 
            "Océans", new List<string>() { "Tacheté de noir" }, "Homme", 0, 0, (float)0.7, (float)0, "Requin Dormeur Mexicain.png",
            (Alimentation)6, (Statut)7);

            animaux = new List<Animal>()
            {
                new Animal("Diego", Genre.Male, new DateTime(2009, 09, 18), (float)1.20, 59, diego, img, guanaco),
                new Animal("Pascal", Genre.Male, new DateTime(2006, 04, 21), (float)5.70, (float)397.4, pascal, imag, requinRenard),
                new Animal("Cognac", Genre.Male, new DateTime(1987,12,02), (float)0.68, (float)31.9, cognac, photo, lynx),
                new Animal("Carlos", Genre.Male, new DateTime(2017, 06, 14), (float)0.47,(float)37.9, carlos, imagerie, requinDormeurmexicain)
            };
        }

        /// <summary>
        /// Fonction de chargement des données
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Animal> ChargerDonnées()
        {
            return new List<Animal>(animaux);
        }

        /// <summary>
        /// Fonction de sauvegarde des données
        /// </summary>
        /// <param name="dataSave"></param>
        public void SauvegarderDonnées(IEnumerable<Animal> dataSave)
        {
            animaux = dataSave.ToList();
        }
    }
}
