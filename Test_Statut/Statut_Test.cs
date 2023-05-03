using System;
using Xunit;
using Modele;
using System.Diagnostics;

namespace Test_Statut
{
    /// <summary>
    /// Tests unitaires de la classe Statut
    /// </summary>
    public class StatutTest
    {
        /// <summary>
        /// Test du constructeur de statut et de la fonction to_string
        /// </summary>
        /// <param name="stt"></param>
        [Theory]
        [InlineData(Statut.Danger)]
        [InlineData(Statut.DangerCritique)]
        [InlineData(Statut.DonneesInsufisantes)]
        [InlineData(Statut.Eteint)]
        [InlineData(Statut.EteintEtatSauvage)]
        [InlineData(Statut.NonEvaluee)]
        [InlineData(Statut.PreoccupationMineure)]
        [InlineData(Statut.QuasiMenacee)]
        [InlineData(Statut.Vulnerable)]
        public void TestConstruct(Statut stt)
        {
            Trace.WriteLine("Test de la classe statut :");
            Trace.WriteLine("Test du constructeur :");

            Statut stat = stt;
            Assert.Equal(stt, stat);

            Trace.WriteLine("Test de la fonction to_string :");

            Trace.WriteLine(value: StatutHelper.to_string(stt));

        }
    }
}
