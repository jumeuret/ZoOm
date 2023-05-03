using Business;
using Modele;
using Persistance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Test_Manager
{
    /// <summary>
    /// Tests unitaires de la classe Manager
    /// </summary>
    public class Manager_Test
    {
        /// <summary>
        /// Test du chargement de données
        /// </summary>
        [Fact]
        public void TestChargerDonnées()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction ChargerDonnées :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();
        }

        /// <summary>
        /// Test de la sauvegarde des données
        /// </summary>
        [Fact]
        public void TestSauvegarderDonnées()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction SauvegarderDonnées :");

            Manager mgr = new Manager(new Stub());
            mgr.SauvegarderDonnées();
        }

        /// <summary>
        /// Test de la fonction renvoyant la liste des espèces
        /// </summary>
        [Fact]
        public void TestListEspeces()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction ListEspeces :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();
            List<string> especes = mgr.ListEspeces();
        }

        /// <summary>
        /// Test de la fonction d'ajout d'un animal
        /// </summary>
        [Fact]
        public void TestAjouterAnimal()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction AjouterAnimal :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();
            var animauxOld = mgr.Animaux;

            Animal a = new Animal("Cognac",Genre.Male, new DateTime(02/12/1987), (float)0.68, (float)29.7, 
            new List<string>() {"Fait la fine bouche quand à son repas"},new List<string>() 
            {"Lynx Boréal/Cognac.png"}, new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales", 
            new List<string>() { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png", 
            Alimentation.Carnivore, Statut.PreoccupationMineure));

            mgr.AjouterAnimal(a);
            var animauxNew = mgr.Animaux;
            Assert.Equal(animauxOld.Count, animauxNew.Count);
            Assert.Equal(animauxNew[animauxNew.Count - 1], a);
        }

        /// <summary>
        /// Test de la fonction d'actualisation des données d'un animal
        /// </summary>
        [Fact]
        public void TestActualiserAnimal()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction ActualiserAnimal :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();

            Animal a = new Animal("Cognac", Genre.Male, new DateTime(02 / 12 / 1987), (float)0.68, (float)29.7,
            new List<string>() { "Fait la fine bouche quand à son repas" }, new List<string>()
            {"Lynx Boréal/Cognac.png"}, new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales",
            new List<string>() { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png",
            Alimentation.Carnivore, Statut.PreoccupationMineure));
            mgr.AjouterAnimal(a);

            var countTailleAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Taille.Count;
            var countPoidsAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Poids.Count;
            var countNourrissageAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Nourrissage.Count;
            var countNettoyageAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Nettoyage.Count;
            var countSanteAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Sante.Count;

            Animal b = new Animal("Cognac", Genre.Male, new DateTime(02 / 12 / 1987), (float)0.71, (float)31.15,
            new List<string>() { "Fait la fine bouche quand à son repas" }, new List<string>()
            {"Lynx Boréal/Cognac.png"}, new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales",
            new List<string>() { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png",
            Alimentation.Carnivore, Statut.PreoccupationMineure));
            b.Nourrissage.Add(DateTime.Now, true);
            b.Nettoyage.Add(DateTime.Now, true);
            b.Sante.Add(DateTime.Now, true);

            mgr.ActualiserAnimal(a, b);
            var animauxNew = mgr.Animaux;

            Assert.Equal(animauxNew[animauxNew.Count - 1].Taille.Count, countTailleAnimauxOld + 1);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Poids.Count, countPoidsAnimauxOld + 1);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Nourrissage.Count, countNourrissageAnimauxOld + 1);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Nettoyage.Count, countNettoyageAnimauxOld + 1);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Sante.Count, countSanteAnimauxOld + 1);
        }

        /// <summary>
        /// Test de la fonction de modification des données d'un animal
        /// </summary>
        [Fact]
        public void TestModifierAnimal()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction ModifierAnimal :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();

            Animal a = new Animal("Cognac", Genre.Male, new DateTime(02 / 12 / 1987), (float)0.71, (float)31.15,
            new List<string>() { "Fait la fine bouche quand à son repas" }, new List<string>()
            {"Lynx Boréal/Cognac.png"}, new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales",
            new List<string>() { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png",
            Alimentation.Carnivore, Statut.PreoccupationMineure));
            a.Nourrissage.Add(DateTime.Now, true);
            a.Nettoyage.Add(DateTime.Now, true);
            a.Sante.Add(DateTime.Now, true);
            mgr.AjouterAnimal(a);

            var countPartAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Particularités.Count;
            var countTailleAnimauxOld = mgr.Animaux[mgr.Animaux.Count - 1].Taille.Count;
            var countAnimauxOld = mgr.Animaux.Count;

            Animal b = new Animal("Cognac", Genre.Male, new DateTime(02 / 12 / 1987), (float)0.73, (float)31.15,
            new List<string>() { "Fait la fine bouche quand à son repas", "Adore le chamois" }, new List<string>()
            {"Lynx Boréal/Cognac.png"}, new Espece("Lynx Boréal", "Lynx lynx", "Forêts boréales",
            new List<string>() { "N'a que 28 dents contraitrement aux autres félins qui en ont 30" },
            "Ours brun, Loup gris", 15, 20, (float)0.75, (float)0.35, "Lynx Boréal/Lynx Boréal.png",
            Alimentation.Carnivore, Statut.PreoccupationMineure));
            b.Nourrissage.Add(DateTime.Now, true);
            b.Nettoyage.Add(DateTime.Now, true);
            b.Sante.Add(DateTime.Now, true);

            mgr.ModifierAnimal(a, b);
            var animauxNew = mgr.Animaux;

            Assert.Equal(animauxNew.Count, countAnimauxOld);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Taille.Count, countTailleAnimauxOld);
            Assert.Equal(animauxNew[animauxNew.Count - 1].Particularités.Count, countPartAnimauxOld + 1);
        }

        /// <summary>
        /// Test de la fonction de recherche d'un animal par une partie ou par l'entièreté de son nom ou de son espèce
        /// </summary>
        [Fact]
        public void TestRechercherAnimal()
        {
            Trace.WriteLine("Test de la classe Manager :");
            Trace.WriteLine("Test de la fonction RechercherAnimal :");

            Manager mgr = new Manager(new Stub());
            mgr.ChargerDonnées();

            string parametre = "Diego";
            List<Animal> res = mgr.RechercherAnimal(parametre);
            Assert.NotEmpty(res);
            Assert.Single(res);

            parametre = "Guanaco";
            res.Clear();
            _ = res;
            res = mgr.RechercherAnimal(parametre);
            Assert.NotEmpty(res);
            Assert.Single(res);

            parametre = "anac";
            res.Clear();
            res = mgr.RechercherAnimal(parametre);
            Assert.NotEmpty(res);
            Assert.Single(res);

            parametre = "ieg";
            res.Clear();
            res = mgr.RechercherAnimal(parametre);
            Assert.NotEmpty(res);
            Assert.Single(res);

            parametre = "Autruche";
            res.Clear();
            res = mgr.RechercherAnimal(parametre);
            Assert.Empty(res);
        }
    }
}
