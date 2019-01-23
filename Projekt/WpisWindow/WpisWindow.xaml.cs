using Projekt.Baza;
using Projekt.Klasy.PogodaWindow;
using Projekt.Klasy.WpisWindow;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekt
{
    /// <summary>
    /// Obsługa WpisWindow.xaml
    /// </summary>
    public partial class WpisWindow : Window
    {
        private WpisWindowMetody metody;
        private List<Pogoda> dodane;
        private string _miasto;
        private DataGrid grid;
        private PogodaWindowMetody metodypogody;

        /// <summary>
        /// Konstruktor nowej instancji klasy <see cref="WpisWindow"/>.
        /// Tworzy obiekty klas <see cref="WpisWindowMetody"/> oraz <see cref="PogodaWindowMetody"/>.
        /// Nie zawiera żadnych danych, ponieważ obsługuje dodawanie wpisu do bazy danych.
        /// </summary>
        /// <param name="miasto">Miasto wybrane przez użytkownika.</param>
        /// <param name="gridDetalePogody">DataGrid zawierający szczegóły pogody w wybranym mieście.</param>
        public WpisWindow(string miasto, ref DataGrid gridDetalePogody)
        {
            InitializeComponent();
            metody = new WpisWindowMetody();
            metodypogody = new PogodaWindowMetody();
            _miasto = miasto;
            grid = gridDetalePogody;
        }
        /// <summary>
        /// Konstruktor nowej instancji klasy <see cref="WpisWindow"/> dla modyfikowania danych.
        /// Zmienia zawartość przycisku "Dodaj" na "Modyfikuj", wypełnia TextBoxy szczegółami wybranego wpisu.
        /// </summary>
        /// <param name="doEdycji">Lista wpisów do edycji.</param>
        /// <param name="miasto">Miasto wybrane przez użytkownika.</param>
        /// <param name="gridDetalePogody">DataGrid zawierający szczegóły pogody w wybranym mieście.</param>
        public WpisWindow(List<Pogoda> doEdycji, string miasto, ref DataGrid gridDetalePogody)
        {
            InitializeComponent();
            DodajButton.Content = "Modyfikuj";
            metody = new WpisWindowMetody();
            metodypogody = new PogodaWindowMetody();
            _miasto = miasto;
            grid = gridDetalePogody;
            dodane = doEdycji;
            metody.WypelnijDanymi(dodane, DeszczCheckBox, SniegCheckBox, ZachmurzenieCheckBox, Kalendarz,
                CisnienieTextBox, TemperaturaTextBox, DodajButton);
        }
        /// <summary>
        /// Obsługa kliknięcia DodajButton.
        /// Jeśli zawartość DodajButton to "Modyfikuj" wywoływana jest metoda modyfikująca dane, dla innej zawartości zostaje utworzony nowy wpis.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca szczegóły zdarzenia.</param>
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (DodajButton.Content.ToString() != "Modyfikuj")
            {
                dodane = metody.BudujDodawanieParser(DeszczCheckBox, SniegCheckBox, ZachmurzenieCheckBox, _miasto,
                    Kalendarz, CisnienieTextBox, TemperaturaTextBox);
                metody.DodajDoBazy(dodane);
                Close();
                metodypogody.WypelnijDataGrid(grid, _miasto);
            }
            else
            {
                foreach (var VARIABLE in dodane)
                {
                    dodane = metody.BudujDodawanieParser(VARIABLE.IdWpisu, DeszczCheckBox, SniegCheckBox,
                        ZachmurzenieCheckBox, _miasto, Kalendarz, CisnienieTextBox, TemperaturaTextBox);
                    metody.DodajModyfikacje(dodane);
                    MessageBox.Show("Modyfikacja udana");
                }

                Close();
                metodypogody.WypelnijDataGrid(grid, _miasto);
            }
        }
    }
}