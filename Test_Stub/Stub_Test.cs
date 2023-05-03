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
        /// Tests de la fonction ChargerDonn�es et SauvegarderDonn�es de Stub
        /// </summary>
        [Fact]
        public void Test()
        {
            Manager manager = new Manager(new Stub());
            manager.ChargerDonn�es();
            var animauxOld = manager.Animaux;
            manager.SauvegarderDonn�es();

            manager.ChargerDonn�es();
            var animauxNew = manager.Animaux;

            Assert.Equal(animauxOld, animauxNew);
        }
    }
}