using System;
using System.Collections.Generic;
using Xunit;
using Modele;
using System.Diagnostics;

namespace Test_Espece
{
    /// <summary>
    /// Tests unitaires de la classe Espece
    /// </summary>
    public class EspeceTest
    {
        /// <summary>
        /// Test du constructeur d'espèce ( sans l'attribut Particularités )
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="nomLatin"></param>
        /// <param name="habitat"></param>
        /// <param name="predateurs"></param>
        /// <param name="ageRecord"></param>
        /// <param name="ageRecordCaptivite"></param>
        /// <param name="tailleRecord"></param>
        /// <param name="poidsRecord"></param>
        /// <param name="carte"></param>
        /// <param name="regime"></param>
        /// <param name="statut"></param>
        [Theory]
        [InlineData("Requin Dormeur Mexicain", "Heterodontus mexicanus", "Océans", "Homme", 0, 0, (float)0.7, (float)0, "Requin Dormeur Mexicain.png",
        (Alimentation)6, (Statut)7)]
        public void TestConstruct(string nom, string nomLatin, string habitat, string predateurs, int ageRecord, int ageRecordCaptivite,
        float tailleRecord, float poidsRecord, string carte, Alimentation regime, Statut statut)
        {
            Trace.WriteLine("Test de la classe Espece :");
            Trace.WriteLine("Test du constructeur :");

            Espece esp = new Espece(nom, nomLatin, habitat, new List<string>() {
           "On ne sais pas"}, predateurs, ageRecord, ageRecordCaptivite, tailleRecord, poidsRecord,
            carte, regime, statut);

            Assert.Equal(nom, esp.Nom);
            Assert.Equal(nomLatin, esp.NomLatin);
            Assert.Equal(habitat, esp.Habitat);
            Assert.Equal(predateurs, esp.Prédateurs);
            Assert.Equal(ageRecord, esp.AgeRecord);
            Assert.Equal(ageRecordCaptivite, esp.AgeRecordCaptivite);
            Assert.Equal(tailleRecord, esp.TailleRecord);
            Assert.Equal(poidsRecord, esp.PoidsRecord);
            Assert.Equal(carte, esp.Carte);
        }

        /// <summary>
        /// Aide au test de l'attribut Particularités de la classe Espece
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetParticularitésE()
        {
            yield return new object[] { new List<string>() { "Possèdent deux nageoires dorsales" } };
            yield return new object[] { new List<string>() { "Nocturne" } };
        }

        /// <summary>
        /// Test de l'attribut Particularités de la classe Espece
        /// </summary>
        /// <param name="part"></param>
        [Theory]
        [MemberData(nameof(GetParticularitésE))]
        void TestConstructParticularitésE(List<string> part)
        {
            Espece esp = new Espece("Espece", "Especidae Normalidus", "Nulle Part", part,
            "Aucun", 100, 100, (float)2.0, (float)50.0, "Espece.png", (Alimentation)0, (Statut)9);

            Assert.Equal(part, esp.Particularités);
        }
    }
}
