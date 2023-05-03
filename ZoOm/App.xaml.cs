using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Business;
using Modele;
using Persistance;

namespace ZoOm
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Propiété permettant de choisir le type de Persistance utilisée par l'application
        /// </summary>
        public Manager LeManager { get; private set; } = new Manager(new DataContract());
    }
}
