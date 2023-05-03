using Business;
using Persistance;
using System;
using Xunit;

namespace Test_DataContract
{
    /// <summary>
    /// Tests unitaires de la classe DataContract
    /// </summary>
    public class DataContract_Test
    {
        /// <summary>
        /// Tests de la fonction ChargerDonnées et SauvegarderDonnées de DataContract
        /// </summary>
        [Fact]
        public void Test()
        {
            Manager manager = new Manager(new Stub());
            manager.ChargerDonnées();
            manager.Pers = new DataContract();
            manager.SauvegarderDonnées();

            var animauxOld = manager.Animaux;
            manager.ChargerDonnées();
            var animauxNew = manager.Animaux;

            Assert.Equal(animauxOld, animauxNew);
        }
    }
}