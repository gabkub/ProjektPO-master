using Projekt.Baza;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekt.Klasy.WpisWindow
{
    public class WpisWindowMetody
    {/// <summary>
    /// Dodaje modyfikacje wpisów do bazy danych.
    /// </summary>
    /// <param name="doEdycji">Lista wpisów bazy danych do edycji.</param>
        public void DodajModyfikacje(List<Pogoda> doEdycji)
        {
            foreach (var VARIABLE in doEdycji)
            {
                using (var context = new Baza.ProjektEntities2())
                {
                    var pogoda = context.Pogoda.SingleOrDefault(p => p.IdWpisu == VARIABLE.IdWpisu);

                    pogoda.Deszcz = VARIABLE.Deszcz;
                    pogoda.Śnieg = VARIABLE.Śnieg;
                    pogoda.Zachmurzenie = VARIABLE.Zachmurzenie;
                    pogoda.Ciśnienie = VARIABLE.Ciśnienie;
                    pogoda.Data = VARIABLE.Data;
                    pogoda.Temperatura = VARIABLE.Temperatura;

                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Wypełnia TextBox w oknie danymi wybranego wpisu.
        /// </summary>
        /// <param name="doEdycji">Lista wpisów do edycji.</param>
        /// <param name="DeszczCheckBox">DeszczCheckBox.</param>
        /// <param name="SniegCheckBox">SniegCheckBox.</param>
        /// <param name="ZachmurzenieCheckBox">ZachmurzenieCheckBox.</param>
        /// <param name="Kalendarz">Kalendarz</param>
        /// <param name="CisnienieTextBox">Kontrolka tekstowa ciśnienia.</param>
        /// <param name="TemperaturaTextBox">Kontrolka tekstowa temperatury.</param>
        /// <param name="DodajButton">Przycisk DodajButton.</param>
        public void WypelnijDanymi(List<Pogoda> doEdycji, CheckBox DeszczCheckBox, CheckBox SniegCheckBox, CheckBox ZachmurzenieCheckBox, Calendar Kalendarz, TextBox CienienieTextBox, TextBox TemperaturaTextBox, Button DodajButton)
        {
            foreach (var VARIABLE in doEdycji)
            {
                TemperaturaTextBox.Text = VARIABLE.Temperatura.ToString();
                CienienieTextBox.Text = VARIABLE.Ciśnienie.ToString();
                Kalendarz.SelectedDate = VARIABLE.Data;
                DeszczCheckBox.IsChecked = VARIABLE.Deszcz;
                SniegCheckBox.IsChecked = VARIABLE.Śnieg;
                ZachmurzenieCheckBox.IsChecked = VARIABLE.Zachmurzenie;
            }
        }
        /// <summary>
        /// Dodaje nowy wpis do bazy danych.
        /// </summary>
        /// <param name="doDodania">Lista wpisów do dodania.</param>
        public void DodajDoBazy(List<Pogoda> doDodania)
        {
            using (var context = new Baza.ProjektEntities2())
            {
                foreach (var VARIABLE in doDodania)
                {
                    context.Pogoda.Add(VARIABLE);
                }

                context.SaveChanges();
            }

            MessageBox.Show("Dodano");
        }

        /// <summary>
        /// Buduje listę wpisów do bazy danych uwzględniając dodane.
        /// </summary>
        /// <param name="Id">Idntyfikator wpisu.</param>
        /// <param name="DeszczCheckBox">DeszczCheckBox.</param>
        /// <param name="SniegCheckBox">SniegCheckBox.</param>
        /// <param name="ZachmurzenieCheckBox">ZachmurzenieCheckBox.</param>
        /// <param name="_miasto">miasto wybrane przez użytkownika.</param>
        /// <param name="Kalendarz">Kalendarz.</param>
        /// <param name="CienienieTextBox">Kontrolka tekstowa ciśnienia.</param>
        /// <param name="TemperaturaTextBox">Kontrolka tekstowa temperatury.</param>
        /// <returns>Lista dodanych wpisów.</returns>
        public List<Pogoda> BudujDodawanieParser(int Id, CheckBox DeszczCheckBox, CheckBox SniegCheckBox, CheckBox ZachmurzenieCheckBox, string _miasto, Calendar Kalendarz, TextBox CienienieTextBox, TextBox TemperaturaTextBox)
        {
            List<Pogoda> dodaj = new List<Pogoda>();

            var deszcz = DeszczCheckBox.IsChecked != null && DeszczCheckBox.IsChecked.Value;

            var snieg = SniegCheckBox.IsChecked != null && SniegCheckBox.IsChecked.Value;

            var zachmurzenie = ZachmurzenieCheckBox.IsChecked != null && ZachmurzenieCheckBox.IsChecked.Value;

            try
            {
                if (Kalendarz.SelectedDate != null)
                {
                    dodaj.Add(new Pogoda()
                    {
                        IdWpisu = Id,
                        Miasto = _miasto,
                        Data = Kalendarz.SelectedDate.Value,
                        Ciśnienie = CienienieTextBox.Text,
                        Deszcz = deszcz,
                        Śnieg = snieg,
                        Zachmurzenie = zachmurzenie,
                        Temperatura = Convert.ToInt32(TemperaturaTextBox.Text)
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

            return dodaj;
        }
        /// <summary>
        /// Buduje listę wpisów do bazy danych uwzględniając dodane.
        /// </summary>
        /// <param name="Id">Idntyfikator wpisu.</param>
        /// <param name="DeszczCheckBox">DeszczCheckBox.</param>
        /// <param name="SniegCheckBox">SniegCheckBox.</param>
        /// <param name="ZachmurzenieCheckBox">ZachmurzenieCheckBox.</param>
        /// <param name="_miasto">miasto wybrane przez użytkownika.</param>
        /// <param name="Kalendarz">Kalendarz.</param>
        /// <param name="CienienieTextBox">Kontrolka tekstowa ciśnienia.</param>
        /// <param name="TemperaturaTextBox">Kontrolka tekstowa temperatury.</param>
        /// <returns>Lista dodanych wpisów.</returns>
        public List<Pogoda> BudujDodawanieParser(CheckBox DeszczCheckBox, CheckBox SniegCheckBox, CheckBox ZachmurzenieCheckBox, string _miasto, Calendar Kalendarz, TextBox CienienieTextBox, TextBox TemperaturaTextBox)
        {
            List<Pogoda> dodaj = new List<Pogoda>();

            var deszcz = DeszczCheckBox.IsChecked != null && DeszczCheckBox.IsChecked.Value;

            var snieg = SniegCheckBox.IsChecked != null && SniegCheckBox.IsChecked.Value;

            var zachmurzenie = ZachmurzenieCheckBox.IsChecked != null && ZachmurzenieCheckBox.IsChecked.Value;

            try
            {
                if (Kalendarz.SelectedDate != null)
                {
                    dodaj.Add(new Pogoda()
                    {
                        Miasto = _miasto,
                        Data = Kalendarz.SelectedDate.Value,
                        Ciśnienie = CienienieTextBox.Text,
                        Deszcz = deszcz,
                        Śnieg = snieg,
                        Zachmurzenie = zachmurzenie,
                        Temperatura = Convert.ToInt32(TemperaturaTextBox.Text)
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

            return dodaj;
        }
    }
}