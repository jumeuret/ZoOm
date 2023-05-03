using System;
using Xunit;
using Modele;
using System.Diagnostics;

namespace Test_Classification
{
    public class ClassificationTest
    {
        [Theory]
        [InlineData("", "Mammalia", "Rodentia", "Sciuridae", "Sciurus")]
        [InlineData("Chordata", "", "Tetraodontiformes", "Diodontidae", "Diodon")]
        [InlineData("Chordata", "Mammalia", "", "Sciuridae", "Sciurus")]
        [InlineData("Chordata", "Actinopterygii", "", "Diodontidae", "Diodon")]
        [InlineData("Chordata", "Mammalia", "Rodentia", "", "Sciurus")]
        [InlineData("Chordata", "Actinopterygii", "Tetraodontiformes", "Diodontidae", "")]
        [InlineData("Chordata", "Mammalia", "Rodentia", "Sciuridae", "Sciurus")]
        [InlineData("Chordata", "Actinopterygii", "Tetraodontiformes", "Diodontidae", "Diodon")]
        public void TestConstructeur(string embranchement, string classe, string ordre, string famille, string genre)
        {
            Trace.WriteLine("Test de la classe Classification :");
            Trace.WriteLine("Test du constructeur :");

            try
            {
                Classification cl2 = new Classification(embranchement, classe, ordre, famille, genre);
            }
            catch(ArgumentNullException exept)
            {
                Classification cl2 = null;
                Trace.WriteLine("Error : " + exept);
            }
            finally
            {
                Trace.WriteLine("Checked !");
            }

            Classification cl = new Classification(embranchement, classe, ordre, famille, genre);

            Assert.Equal(embranchement, cl.Embranchement);
            Assert.Equal(classe, cl.Classe);
            Assert.Equal(ordre, cl.Ordre);
            Assert.Equal(famille, cl.Famille);
            Assert.Equal(genre, cl.Genre);
            Assert.Equal(genre, cl.Genre);
        }
    }
}
