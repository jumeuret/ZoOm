using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    /// <summary> 
    /// Enumération permettant de définir le genre d'un animal 
    /// </summary>
    [Flags]
    public enum Genre
    {
        [EnumMember]
        Femelle = 0,
        Male = 1
    }

    /// <summary> 
    /// Classe d'aide à la transcription des genres 
    /// </summary>
    public class GenreHelper
    {

        /// <summary> 
        /// Traduit les genres en chaînes de caractères 
        /// </summary>
        public static string to_string(Genre arg)
        {
            string genre = "";

            switch (arg)
            {
                case Genre.Femelle:
                    genre = "Femelle"; break;
                case Genre.Male:
                    genre = "Mâle"; break;
            }
            return genre;
        }
    }
}
