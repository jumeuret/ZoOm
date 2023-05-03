using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZoOm.Convertisseurs
{
    /// <summary>
    /// Classe de conversion de string en images
    /// </summary>
    internal class StringToImageConverter : IValueConverter
    {
        /// <summary>
        /// Source finale de l'image
        /// </summary>
        private static string cheminImages;

        /// <summary>
        /// Fonction de création de la source de l'image
        /// </summary>
        static StringToImageConverter()
        {
            cheminImages = Path.Combine(Directory.GetCurrentDirectory(), "..\\Images\\Animaux\\");
        }

        /// <summary>
        /// Fonction de conversion d'un string vers une image
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cheminRelatifImage = (string)value;
            if (string.IsNullOrWhiteSpace(cheminRelatifImage))
            {
                return null;
            }
            string cheminAbsoluImage = Path.Combine(cheminImages,cheminRelatifImage);
            return new Uri(cheminAbsoluImage, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Fonction non codée de conversion d'un string vers une image
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
