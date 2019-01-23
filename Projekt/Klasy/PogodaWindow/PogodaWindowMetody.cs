using Projekt.Baza;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Projekt.Klasy.PogodaWindow
{
    public class PogodaWindowMetody
    {
        public List<Pogoda> szczegoly;

        /// <summary>
        /// knstruktor wykorzystany do pobrania szczegółów  pogody w danej lokalizacji
        /// </summary>
        /// <param name="miasto"></param>

        /// <summary>
        /// metoda pobierająca szczegóły pogody w zależności od miasta
        /// </summary>
        /// <param name="miasto">jest to miasto wybrane w ComboBox w MainWindow</param>
        /// <returns></returns>
        private List<Pogoda> _pobierzSzczegoly(string miasto)
        {
            List<Pogoda> temp = new List<Pogoda>();
            using (var context = new Baza.ProjektEntities2())
            {
                // select konkretnych danych dotyczących miasta
                var data = (from k in context.Pogoda
                            where k.Miasto == miasto
                            select k).ToList();

                foreach (var VARIABLE in data)
                {
                    temp.Add(VARIABLE);
                }
            }

            return temp;
        }

        /// <summary>
        /// metoda wypełniająca datagrid
        /// </summary>
        /// <param name="dataGrid">DataGrid do wypełnienia</param>
        public void WypelnijDataGrid(DataGrid dataGrid, string miasto)
        {
            dataGrid.ItemsSource = _pobierzSzczegoly(miasto);
        }

        public List<Pogoda> Modyfikacja(DataGrid grid, string miasto)
        {
            List<Pogoda> edytowane = new List<Pogoda>();
            Pogoda pogoda = grid.SelectedItem as Pogoda;

            edytowane.Add(new Pogoda()
            {
                Ciśnienie = pogoda.Ciśnienie,
                Data = pogoda.Data,
                Deszcz = pogoda.Deszcz,
                Śnieg = pogoda.Śnieg,
                IdWpisu = pogoda.IdWpisu,
                Miasto = pogoda.Miasto,
                Temperatura = pogoda.Temperatura,
                Zachmurzenie = pogoda.Zachmurzenie
            });
            return edytowane;
        }

        public void Usun(List<Pogoda> modyfikacja, ref DataGrid grid)
        {
            var result = MessageBox.Show("Potwierdź", "Usuń", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var context = new Baza.ProjektEntities2())
                {
                    foreach (var VARIABLE in modyfikacja)
                    {
                        var pogoda = context.Pogoda.FirstOrDefault(c => c.IdWpisu == VARIABLE.IdWpisu);
                        context.Pogoda.Remove(pogoda);
                        context.SaveChanges();
                    }
                }
            }

            if (result == MessageBoxResult.No)
            {
                Application.Current.Windows[0]?.Close();
            }
        }
    }
}