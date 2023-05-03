using System;
using Xunit;
using System.Collections.Generic;
using Modele;
using System.Diagnostics;

namespace Test_Animal
{
    /// <summary>
    /// Tests unitaires de la classe Animal
    /// </summary>
    public class AnimalTest
    {
        Espece guanaco = new Espece("Guanaco", "Lama Glama Guanicoe", "Montagnes",
            new List<string>() { "Crachent leur salive au visage des gens qu'ils n'aiment pas",
            "Peuvent cracher leur salive à plus de 3 mètres de distance", },
            "Puma, Condor (Jeunes individus)", 50, 70, (float)1.87, (float)147.2, "Images/Lama.jpg", (Alimentation)1, (Statut)6);
        List<string> img = new List<string>()
            {
                "Images/Lama/Diego.jpg"
            };
        List<string> pascal = new List<string>()
            {
                "Kawaii",
                "A l'air stupide mais est intelligent"
            };
        Espece requinRenard = new Espece("Requin Renard", "Alopias vulpinus", "Océans", new List<string>() {
        "Leur appendice caudal peut mesurer jusqu'à la moitié de leur longueur totale",
        "Pratique le cannibalisme intra-utérin" }, "Humains", 50, 70, (float)6.30, (float)440.0,
        "Images/RequinRenard.jpg", (Alimentation)6, (Statut)4);
        List<string> imag = new List<string>()
            {
                "Images/RequinRenard/Pascal.jpg"
            };
        DateTime date = new DateTime(2009, 09, 18);

        /// <summary>
        /// Test du constructeur d'animaux ( sans les attributs Particularités, Image et DateNaiss )
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="genre"></param>
        [Theory]
        [InlineData("Diego", Genre.Male)]
        [InlineData("Pascal", Genre.Male)]
        public void TestConstruct(string nom, Genre genre)
        {
            Trace.WriteLine("Test de la classe Animal :");
            Trace.WriteLine("Test du constructeur :");

            List<string> part = new List<string>()
            {
                "Normal",
                "Lambda"
            };
            List<string> imag = new List<string>()
            {
                "Espece/Nom.png"
            };
            DateTime dateN = new DateTime(2022, 01, 01);

            Espece espece = new Espece("Espece", "Especidae Normalidus", "Nulle Part", new List<string>() { "Rien de particulier" },
            "Aucun", 100, 100, (float)2.0, (float)50.0, "Espece.png", (Alimentation)0, (Statut)9);

            float taille = (float)3.25;
            float poids = (float)14.6;

            Animal individu = new Animal(nom, genre, dateN, taille, poids, part, imag, espece);

            Assert.Equal(nom, individu.Nom);
            Assert.Equal(genre, individu.Genre);

            DateTime min = DateTime.MinValue;
            foreach (DateTime cle in individu.Taille.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            Assert.Equal(taille, individu.Taille[min]);

            min = DateTime.MinValue;
            foreach (DateTime cle in individu.Poids.Keys)
            {
                if (min < cle)
                {
                    min = cle;
                }
            }
            Assert.Equal(poids, individu.Poids[min]);
        }

        /// <summary>
        /// Aide au test de l'attribut Particularités de la classe Animal
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetParticularités()
        {
            yield return new object[] { new List<string>() { "Mignon", "Grognon" } };
            yield return new object[] { new List<string>() { "Kawaii", "A l'air stupide mais est intelligent" } };
            yield return new object[] { new List<string>() {"Crachent leur salive au visage des gens qu'ils n'aiment pas",
            "Peuvent cracher leur salive  plus de 3 mtres de distance"} };
            yield return new object[] { new List<string>() {"Leur appendice caudal peut mesurer jusqu' la moiti de leur longueur totale",
            "Pratique le cannibalisme intra-utrin" }};
        }

        /// <summary>
        /// Test de l'attribut Particularités de la classe Animal
        /// </summary>
        /// <param name="part"></param>
        [Theory]
        [MemberData(nameof(GetParticularités))]
        public void TestConstructParticularités(List<string> part)
        {
            Animal individu = new Animal("Animal", (Genre)0, new DateTime(2022,01,01), (float)2.0, (float)50.0, part, 
            new List<string>() { "Animal.png" }, new Espece( "Espece", "Especidae Normalidus", "Nulle Part", part, 
            "Aucun", 100, 100, (float)2.0, (float)50.0, "Espece.png", (Alimentation)0, (Statut)9));

            Assert.Equal(part, individu.Particularités);
        }

        /// <summary>
        /// Aide au test de l'attribut Images de la classe Animal
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetImages()
        {
            yield return new object[] { new List<string>(){ "Animal.png", "Animal2.png" } };
            yield return new object[] { new List<string>() { "Individu.png", "Individu2.png", "Individu3.png" } };
        }

        /// <summary>
        /// Test de l'attribut Images de la classe Animal
        /// </summary>
        /// <param name="photo"></param>
        [Theory]
        [MemberData(nameof(GetImages))]
        public void TestConstructImages(List<string> photo)
        {
            Animal individu = new Animal("Animal", (Genre)0, new DateTime(2022, 01, 01), (float)2.0, (float)50.0,
            new List<string>() { "Normal", "Lambda" }, photo,
            new Espece("Espece", "Especidae Normalidus", "Nulle Part", new List<string>() { "Rien de particulier" },
            "Aucun", 100, 100, (float)2.0, (float)50.0, "Espece.png", (Alimentation)0, (Statut)9));

            Assert.Equal(photo, individu.Photos);
        }

        /// <summary>
        /// Aide au test de l'attribut DateNaiss de la classe Animal
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDateNaiss()
        {
            yield return new object[] { new DateTime(2009, 09, 18) };
            yield return new object[] { new DateTime(2006, 4, 21) };
        }

        /// <summary>
        /// Test de l'attribut DateNaiss de la classe Animal
        /// </summary>
        /// <param name="dateNaiss"></param>
        [Theory]
        [MemberData(nameof(GetDateNaiss))]
        public void TestConstructDateNaiss(DateTime dateNaiss)
        {
            Animal individu = new Animal("Animal", (Genre)0, dateNaiss, (float)2.0, (float)50.0,
            new List<string>() { "Normal", "Lambda" }, new List<string>() { "Espece/Animal.png" },
            new Espece("Espece", "Especidae Normalidus", "Nulle Part", new List<string>() { "Rien de particulier" },
            "Aucun", 100, 100, (float)2.0, (float)50.0, "Espece.png", (Alimentation)0, (Statut)9));

            Assert.Equal(dateNaiss.Ticks, individu.DateNaiss.Ticks);
        }
    }
}
