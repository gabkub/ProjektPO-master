using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Projekt
{
    public abstract class WpisBazaDanych
    {
        public int IdWpisu { get; set; }
        public Nullable<DateTime> Data { get; set; }
    }
}