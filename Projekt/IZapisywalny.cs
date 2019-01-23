using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{/// <summary>
/// Interfejs dla klas obsługujących serializację do pliku (JSON/XML).
/// </summary>
    internal interface IZapisywalny
    {
        void ZapiszPlik(string m);
    }
}