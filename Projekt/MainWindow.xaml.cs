using Projekt.Klasy.MainWindow;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Projekt
{
    /// <summary>
    /// Obsługa dla MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowMetody metody;
        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="MainWindow"/>, tworzy nowy obiekt "metody" będący instancją klasy <see cref="MainWindowMetody"/>.
        /// Wypełnia kontrolkę Miasta_ComboBox zawierającą miasta do wyboru dla użytkownika.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            metody = new MainWindowMetody();
            metody.WypelnijComboBox(Miasta_ComboBox);
        }

        /// <summary>
        /// Obsługa zdarzenia Click dla przycisku Button_Dalej.
        /// Sprawdzenie, czy użytkownik wybrał miasto w Miasta_ComboBox, jeśli nie - wyświetlenie okna informującego o tym.
        /// Następnie utworzenie i otwarcie nowego okna <see cref="PogodaWindow"/> dla wybranego miasta.
        ///  </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Instancja <see cref="RoutedEventArgs"/> zawierająca dane zdarzenia.</param>
        private void Button_Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (Miasta_ComboBox.SelectedItem != null)
            {
                string miasto = Miasta_ComboBox.SelectedItem.ToString();
                PogodaWindow pogodaWindow = new PogodaWindow(miasto);
                pogodaWindow.Title = miasto;
                pogodaWindow.Show();
            }
            else
            {
                MessageBox.Show("Wybierz miasto");
            }
        }
    }
}