using Newtonsoft.Json;
using Projekt.Baza;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Projekt.Klasy.ZapisOdczytPliku
{
    public class ZapisJSON : IZapisywalny
    {
        private List<Pogoda> _jsonList;

        /// <summary>
        /// Konstruktor nowej instancji klasy <see cref="ZapisJSON"/>.
        /// </summary>
        /// <param name="doSerializacji">Lista wpisów do serializacji.</param>
        /// <param name="m">Miasto wybrane przez użytkownika</param>
        public ZapisJSON(List<Pogoda> doSerializacji, string m)
        {
            _jsonList = doSerializacji;
            ZapiszPlik(m);
        }

        /// <summary>
        /// Zapisuje plik w formacie JSON, wyświetla informację o powodzeniu lub niepowodzeniu serializacji.
        /// </summary>
        /// <param name="m">Miasto wybrane przz użytkownika.</param>
        public void ZapiszPlik(string m)
        {
            string path = Directory.GetCurrentDirectory();
            var data = string.Format("{0} {1:dd-MM-yyyy}", m, DateTime.Now);
            data += ".json";
            try
            {
                File.WriteAllText(path + @"\" + data, JsonConvert.SerializeObject(_jsonList));
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd" + e);
                throw;
            }

            MessageBox.Show("Zapis udany");
        }
    }
}