using Business;
using Persistance;
using Xunit;

namespace Test_Stub
{
    /// <summary>
    /// Tests unitaires de la classe Stub
    /// </summary>
    public class Stub_Test
    {
        /// <summary>
        /// Tests de la fonction ChargerDonnées et SauvegarderDonnées de Stub
        /// </summary>
        [Fact]
        public void Test()
        {
            Manager manager = new Manager(new Stub());
            manager.ChargerDonnées();
            var animauxOld = manager.Animaux;
            manager.SauvegarderDonnées();

            manager.ChargerDonnées();
            var animauxNew = manager.Animaux;

            Assert.Equal(animauxOld, animauxNew);
        }
    }
}