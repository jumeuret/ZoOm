using System;
using Xunit;
using Modele;
using System.Diagnostics;

namespace Test_Alimentation
{
    /// <summary>
    /// Test unitaires de la classe Alimentation
    /// </summary>
    public class AlimentationTest
    {
        /// <summary>
        /// Test du constructeur d'alimentations
        /// </summary>
        /// <param name="al"></param>
        [Theory]
        [InlineData(Alimentation.Carnivore)]
        [InlineData(Alimentation.Charognard)]
        [InlineData(Alimentation.Frugivore)]
        [InlineData(Alimentation.Granivore)]
        [InlineData(Alimentation.Herbivore)]
        [InlineData(Alimentation.Insectivore)]
        [InlineData(Alimentation.Nectarivore)]
        [InlineData(Alimentation.Omnivore)]
        [InlineData(Alimentation.Piscivore)]

        public void TestConstruct(Alimentation al)
        {
            Trace.WriteLine("Test de la classe Alimentation :");
            Trace.WriteLine("Test du constructeur :");

            Alimentation regime = al;
            Assert.Equal(al, regime);
        }

    }

}
