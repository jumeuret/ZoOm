using System;
using Xunit;
using Modele;
using System.Diagnostics;

namespace Test_Genre
{
    /// <summary>
    /// Tests unitaires de la classe Genre
    /// </summary>
    public class Genre_Test
    {
        /// <summary>
        /// Test du constructeur de genres et de la fonction to_string
        /// </summary>
        /// <param name="g"></param>
        [Theory]
        [InlineData(Genre.Femelle)]
        [InlineData(Genre.Male)]
        public void TestConstruct(Genre g)
        {
            Trace.WriteLine("Test de la classe Genre :");
            Trace.WriteLine("Test du constructeur :");

            Genre gender = g;
            Assert.Equal(g, gender);

            Trace.WriteLine("Test de la fonction to_string :");

            Trace.WriteLine(value: GenreHelper.to_string(g));

        }
    }
}
