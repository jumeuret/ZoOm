using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZoOm.Convertisseurs
{
    /// <summary>
    /// Classe de conversion de date en age
    /// </summary>
    class DateToAgeConverter : IValueConverter
    {
        /// <summary>
        /// Fonction de conversion d'une date vers un age
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateNaissance;
            try
            {
                dateNaissance = (DateTime)value;
            }
            catch (Exception ex)
            {
                return -1;
            }
            int age = (DateTime.Now.Year - dateNaissance.Year);
            return age;
        }

        /// <summary>
        /// Fonction non codée de conversion d'un age vers une date
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
