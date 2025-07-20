using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public interface IZvanjeListaKlasa
    {
        List<ZvanjeKlasa> ListaZvanja { get; set; }
        void DodajElementListe(ZvanjeKlasa novoZvanjeObjekat);
        void ObrisiElementListe(ZvanjeKlasa zvanjeObjekatZaBrisanje);
        void ObrisiElementNaPoziciji(int pozicija);
        void IzmeniElementListe(ZvanjeKlasa staroZvanjeObjekat, ZvanjeKlasa novoZvanjeObjekat);
    }
}
