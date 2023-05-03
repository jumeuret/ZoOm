using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    /// <summary>
    /// Enumération permettant de définir l'alimentation d'un animal
    /// </summary>
    [Flags]
    public enum Alimentation
    {
        [EnumMember]
        Omnivore = 0,
        Herbivore = 1,
        Granivore = 2,
        Frugivore = 3,
        Nectarivore = 4,
        Carnivore = 5,
        Piscivore = 6,
        Insectivore = 7,
        Charognard = 8
    }
}
