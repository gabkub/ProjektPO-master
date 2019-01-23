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
    /// Interaction logic for WpisWindow.xaml
    /// </summary>
    public partial class WpisWindow : Window
    {
        private WpisWindowMetody metody;
        private List<Pogoda> dodane;
        private string _miasto;
        private DataGrid grid;
        private PogodaWindowMetody metodypogody;

        public WpisWindow(string miasto, ref DataGrid gridDetalePogody)
        {
            InitializeComponent();
            metody = new WpisWindowMetody();
            metodypogody = new PogodaWindowMetody();
            _miasto = miasto;
            grid = gridDetalePogody;
        }

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
                CienienieTextBox, TemperaturaTextBox, DodajButton);
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (DodajButton.Content != "Modyfikuj")
            {
                dodane = metody.BudujDodawanieParser(DeszczCheckBox, SniegCheckBox, ZachmurzenieCheckBox, _miasto,
                    Kalendarz, CienienieTextBox, TemperaturaTextBox);
                metody.DodajDoBazy(dodane);
                Close();
                metodypogody.WypelnijDataGrid(grid, _miasto);
            }
            else
            {
                foreach (var VARIABLE in dodane)
                {
                    dodane = metody.BudujDodawanieParser(VARIABLE.IdWpisu, DeszczCheckBox, SniegCheckBox,
                        ZachmurzenieCheckBox, _miasto, Kalendarz, CienienieTextBox, TemperaturaTextBox);
                    metody.DodajModyfikacje(dodane);
                    MessageBox.Show("Modyfikacja udana");
                }

                Close();
                metodypogody.WypelnijDataGrid(grid, _miasto);
            }
        }
    }
}