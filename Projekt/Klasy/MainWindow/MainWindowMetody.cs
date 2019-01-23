using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Projekt.Klasy.MainWindow
{
    public class MainWindowMetody //IComparable
    {
        private List<string> _miasta;

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
        ///
        /// </summary>
        /// <param name="combo"></param>
        public void WypelnijComboBox(ComboBox combo)
        {
            //List<string> posortowaneMiasta;
            foreach (var VARIABLE in _miasta)
            {
                combo.Items.Add(VARIABLE.ToString());
            }
        }

        public MainWindowMetody()
        {
            _miasta = PobierzMiasta();
        }
    }
}