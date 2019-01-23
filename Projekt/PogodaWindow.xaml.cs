using Projekt.Baza;
using Projekt.Klasy.PogodaWindow;
using Projekt.Klasy.ZapisOdczytPliku;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekt
{
    /// <summary>
    /// Obsługa PogodaWindow.xaml
    /// </summary>
    public partial class PogodaWindow : Window
    {
        
        private PogodaWindowMetody metody;
        private ZapisJSON zapis;
        private string _miasto;
        
        /// <summary>
        /// Inicjalizacja nowej instancji klasy <see cref="PogodaWindow"/>.
        /// </summary>
        public PogodaWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor okna zawierającego wpisy z bazy danych o pogodzie w danym mieście. Wypełniany jest DataGrid (ustawiony w tryb tylko do odczytu).
        /// </summary>
        /// <param name="miasto">Miasto wybrane przez użytkownika w Miasta_ComboBox</param>
        public PogodaWindow(string miasto)
        {
            InitializeComponent();
            metody = new PogodaWindowMetody();
            metody.WypelnijDataGrid(GridDetalePogody, miasto);
            GridDetalePogody.IsReadOnly = true;
            _miasto = miasto;
        }

        /// <summary>
        /// Obsługa zdarzenia Click dla ZapiszButton.
        /// Przycisk zapisuje dane o pogodzie dla danego miasta do pliku w formacie JSON za pomocą klasy <see cref="ZapisJSON"/>.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca szczegóły zdarzenia.</param>
        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            zapis = new ZapisJSON(metody.szczegoly, _miasto);
        }

        /// <summary>
        /// Obsługa zdarzenia Click dla DodajButton.
        /// By utworzyć nowy wpis w bazie danych tworzona jest nowa nowa instancja klasy <see cref="WpisWindow"/>.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca szczegóły zdarzenia.</param>
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            WpisWindow wpis = new WpisWindow(_miasto, ref GridDetalePogody);
            wpis.Show();
        }

        /// <summary>
        /// Obsługa zdarzenia Click dla ModyfikujButton.
        /// Po zaznaczeniu elementu DataGrid można go modyfikować.
        /// Najpierw wykonywana jest metoda Modyfikacja klasy <see cref="PogodaWindowMetody"/>, a następnie tworzona jest nowa nowa instancja klasy <see cref="WpisWindow"/> przyjmująca detale wpisu do modyfikacji.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca szczegóły zdarzenia.</param>
        private void ModyfikujButton_Click(object sender, RoutedEventArgs e)
        {
            metody.Modyfikacja(GridDetalePogody, _miasto);
            WpisWindow wpis = new WpisWindow(metody.Modyfikacja(GridDetalePogody, _miasto), _miasto, ref GridDetalePogody);
            wpis.Show();
        }

        /// <summary>
        /// Obsługa zdarzenia Click dla UsunButton.
        /// Po wybraniu w DataGrid danego wpisu można go usunąć za pomocą metody Usun klasy <see cref="PogodaWindowMetody"/>.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca szczegóły zdarzenia.</param>
        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            metody.Usun(metody.Modyfikacja(GridDetalePogody, _miasto), ref GridDetalePogody);
            metody.WypelnijDataGrid(GridDetalePogody, _miasto);
        }
    }
}