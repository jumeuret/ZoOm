using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    /// <summary>
    /// Enumération permettant de définir le statut d'une espèce
    /// </summary>
    [Flags]
    public enum Statut
    {
        [EnumMember]
        Eteint = 0,
        EteintEtatSauvage = 1,
        DangerCritique = 2,
        Danger = 3,
        Vulnerable = 4,
        QuasiMenacee = 5,
        PreoccupationMineure = 6,
        DonneesInsufisantes = 7,
        NonEvaluee = 8
    }

    /// <summary>
    /// Classe d'aide à la transcription des statut 
    /// </summary>
    public class StatutHelper
    {
        /// <summary>
        /// Traduit les statut en chaînes de caractères 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string to_string(Statut arg)
        {
            string statut = "";

            switch (arg)
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
    }
}
