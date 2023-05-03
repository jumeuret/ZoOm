using System;
using Modele;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    /// <summary>
    /// Interface définissant des méthodes pour persister les données de l'application
    /// </summary>
    public interface IPersistanceManager
    {
        void SauvegarderDonnées(IEnumerable<Animal> dataSave);
        IEnumerable<Animal> ChargerDonnées();
    }
}
