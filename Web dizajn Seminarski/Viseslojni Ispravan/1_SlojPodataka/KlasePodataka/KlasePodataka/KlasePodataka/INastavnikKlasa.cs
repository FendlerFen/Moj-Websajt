using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public interface INastavnikKlasa
    {
        string JMBG { get; set; }
        string Prezime { get; set; }
        string Ime { get; set; }
        ZvanjeKlasa Zvanje
        {
            get; set;
        }

    }
}
