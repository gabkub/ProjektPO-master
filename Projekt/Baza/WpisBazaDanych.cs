using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Projekt
{/// <summary>
/// Abstrakcyjna klasa, po której dziedziczyć będą wszystkie wpisy z baz danych dodane teraz lub w przyszłości.
/// </summary>
 public abstract class WpisBazaDanych
    {
        public int IdWpisu { get; set; }
        public Nullable<DateTime> Data { get; set; }
    }
}