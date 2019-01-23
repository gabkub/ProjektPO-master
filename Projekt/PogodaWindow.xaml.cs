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
    /// Interaction logic for PogodaWindow.xaml
    /// </summary>
    public partial class PogodaWindow : Window
    {
        private PogodaWindowMetody metody;
        private ZapisJSON zapis;
        private string _miasto;
        private List<Pogoda> modyfikacja;

        public PogodaWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// konstruktor okna szczegółów pogody danego miasta. Okno przyjmuje Title = nazwa wybranego miasta
        /// </summary>
        /// <param name="miasto">wybrane miasto z CB z MainWindow</param>
        public PogodaWindow(string miasto)
        {
            InitializeComponent();
            metody = new PogodaWindowMetody();
            metody.WypelnijDataGrid(GridDetalePogody, miasto);
            GridDetalePogody.IsReadOnly = true;
            _miasto = miasto;
        }

        /// <summary>
        /// button zapisujący dane z dataGrid w formacie JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            zapis = new ZapisJSON(metody.szczegoly, _miasto);
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            WpisWindow wpis = new WpisWindow(_miasto, ref GridDetalePogody);
            wpis.Show();
        }

        private void ModyfikujButton_Click(object sender, RoutedEventArgs e)
        {
            metody.Modyfikacja(GridDetalePogody, _miasto);
            WpisWindow wpis = new WpisWindow(metody.Modyfikacja(GridDetalePogody, _miasto), _miasto, ref GridDetalePogody);
            wpis.Show();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            metody = new PogodaWindowMetody();
            metody.Usun(metody.Modyfikacja(GridDetalePogody, _miasto), ref GridDetalePogody);
            metody.WypelnijDataGrid(GridDetalePogody, _miasto);
        }
    }
}