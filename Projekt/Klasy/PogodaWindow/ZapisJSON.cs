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
        /// Konstruktor wykorzystany do stworzenia całości zapisu
        /// </summary>
        /// <param name="doSerializacji">jest to lista obiektów typu Pogoda przesłana z obiektu, który zawiera listę wyświetloną w DataGrid</param>
        public ZapisJSON(List<Pogoda> doSerializacji, string m)
        {
            _jsonList = doSerializacji;
            ZapiszPlik(m);
        }

        /// <summary>
        /// Zapisz do pliku  o nazwie składającej się z daty i godziny utworzenia raportu w formacie JSON. Do otwarcia polecam https://jsonformatter.curiousconcept.com, gdzie należy wkleić zawartość pliku
        /// </summary>
        public void ZapiszPlik(string m)
        {
            string path = Directory.GetCurrentDirectory();
            var data = string.Format("{0}: {1:dd-MM-yyyy_HH-mm-ss}", m, DateTime.Now);
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