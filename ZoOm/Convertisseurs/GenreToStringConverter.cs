using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Modele;

namespace ZoOm.Convertisseurs
{
    /// <summary>
    /// Classe de conversion de genre en string
    /// </summary>
    internal class GenreToStringConverter : IValueConverter
    {
        /// <summary>
        /// Fonction de conversion d'un genre vers un string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string genre = "";

            switch (value)
            {
                case Genre.Femelle:
                    genre = "Femelle"; break;
                case Genre.Male:
                    genre = "Mâle"; break;
            }
            return genre;
        }

        /// <summary>
        /// Fonction non codée de conversion d'un genre vers un string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
