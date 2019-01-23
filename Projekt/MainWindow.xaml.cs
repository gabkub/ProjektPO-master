using Projekt.Klasy.MainWindow;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowMetody metody;

        public MainWindow()
        {
            InitializeComponent();
            metody = new MainWindowMetody();
            metody.WypelnijComboBox(Miasta_ComboBox);
        }

        /// <inheritdoc />

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