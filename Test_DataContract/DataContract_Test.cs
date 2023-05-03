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
        /// Tests de la fonction ChargerDonn�es et SauvegarderDonn�es de DataContract
        /// </summary>
        [Fact]
        public void Test()
        {
            Manager manager = new Manager(new Stub());
            manager.ChargerDonn�es();
            manager.Pers = new DataContract();
            manager.SauvegarderDonn�es();

            var animauxOld = manager.Animaux;
            manager.ChargerDonn�es();
            var animauxNew = manager.Animaux;

            Assert.Equal(animauxOld, animauxNew);
        }
    }
}