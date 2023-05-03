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
    /// Classe de conversion de statut en string
    /// </summary>
    internal class StatutToStringConverter : IValueConverter
    {
        /// <summary>
        /// Fonction de conversion d'un statut vers un string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string statut = "";

            switch (value)
            {
                case Statut.Eteint:
                    statut = "Eteinte"; break;
                case Statut.EteintEtatSauvage:
                    statut = "Eteinte à l'état sauvage"; break;
                case Statut.DangerCritique:
                    statut = "En danger critique"; break;
                case Statut.Danger:
                    statut = "En danger"; break;
                case Statut.Vulnerable:
                    statut = "Vulnérable"; break;
                case Statut.QuasiMenacee:
                    statut = "Quasiment menacée"; break;
                case Statut.PreoccupationMineure:
                    statut = "Préoccupation mineure"; break;
                case Statut.DonneesInsufisantes:
                    statut = "Données récoltées insufisantes"; break;
                case Statut.NonEvaluee:
                    statut = "Non évaluée"; break;
            }
            return statut;
        }

        /// <summary>
        /// Fonction non codée de conversion d'un statut vers un string
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
