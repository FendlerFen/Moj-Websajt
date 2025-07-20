using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public interface INastavnikListaKlasa
    {
        List<NastavnikKlasa> ListaNastavnika { get; set; }
        void DodajElementListe(NastavnikKlasa noviNastavnikObjekat);
        void ObrisiElementListe(NastavnikKlasa nastavnikObjekatZaBrisanje);
        void ObrisiElementNaPoziciji(int pozicija);
        void IzmeniElementListe(NastavnikKlasa stariNastavnikObjekat, NastavnikKlasa noviNastavnikObjekat);

    }
}
