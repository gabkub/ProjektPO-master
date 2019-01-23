using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Projekt.Klasy.MainWindow
{
    public class MainWindowMetody //IComparable
    {
   private List<string> _miasta;
        /// <summary>
        /// Pobiera i zwraca listę dostępnych miast z bazy danych.
        /// </summary>
        /// <returns>Lista miast.</returns>
        private List<string> PobierzMiasta()
        {
            List<string> miasta = new List<string>();

            using (var context = new Baza.ProjektEntities2())
            {
                var data = context.Pogoda.Select(p => p.Miasto).Distinct();

                foreach (var VARIABLE in data)
                {
                    miasta.Add(VARIABLE);
                }
            }

            return miasta;
        }

        /// <summary>
        /// Wypełnia Miasta_ComboBox dostępnymi miastami.
        /// </summary>
        /// <param name="combo">Lista rozwijana</param>
        public void WypelnijComboBox(ComboBox combo)
        {
            //List<string> posortowaneMiasta;
            foreach (var VARIABLE in _miasta)
            {
                combo.Items.Add(VARIABLE.ToString());
            }
        }
        /// <summary>
        /// Konstruktor instancji klasy <see cref="MainWindowMetody"/>.
        /// </summary>
        public MainWindowMetody()
        {
            _miasta = PobierzMiasta();
        }
    }
}