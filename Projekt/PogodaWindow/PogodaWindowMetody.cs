using System;
using Projekt.Baza;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// Pobiera szczegóły wpisów z bazy danych dotyczących pogody dla wybranego miasta.
        /// </summary>
        /// <param name="miasto">Miasto wybrane przez użytkownika.</param>
        /// <returns>Lista wpisów z bazy danych.</returns>
        private List<Pogoda> _pobierzSzczegoly(string miasto)
        {
            List<Pogoda> temp = new List<Pogoda>();
            using (var context = new Baza.ProjektEntities2())
            {
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
        /// Wypełnia DataGrid wpisami z bazy danych dla danego miasta.
        /// </summary>
        /// <param name="dataGrid">DatGrid</param>
        /// <param name="miasto">Miasto wybrane przez użytkownika.</param>
        public void WypelnijDataGrid(DataGrid dataGrid, string miasto)
        {
            szczegoly = _pobierzSzczegoly(miasto);
            dataGrid.ItemsSource = szczegoly;
        }
        /// <summary>
        /// Modyfikuje wybrany element bazy danych.
        /// </summary>
        /// <param name="grid">DataGrid</param>
        /// <param name="miasto">Miasto wybrane przez użytkownika.</param>
        /// <returns>Lista wpisów z bazy danych.</returns>
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
        /// <summary>
        /// Po potwierdzeniu przez użytkownika usuwa wybrany element bazy danych.
        /// </summary>
        /// <param name="modyfikacja">Lista wpisów z bazy danych.</param>
        /// <param name="grid">DataGrid</param>
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