using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class NastavnikListaKlasa:INastavnikListaKlasa
    {

        // atributi
        private List<NastavnikKlasa> _listaNastavnika; 

        // property
        public List<NastavnikKlasa> ListaNastavnika
        {
            get
            {
                return _listaNastavnika;
            }
            set
            {
                if (this._listaNastavnika != value)
                    this._listaNastavnika = value;
            }
        }

        // konstruktor
        public NastavnikListaKlasa()
        {
            _listaNastavnika = new List<NastavnikKlasa>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(NastavnikKlasa noviNastavnikObjekat)
        {
            _listaNastavnika.Add(noviNastavnikObjekat);
        }

        public void ObrisiElementListe(NastavnikKlasa nastavnikObjekatZaBrisanje)
        {
            _listaNastavnika.Remove(nastavnikObjekatZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaNastavnika.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(NastavnikKlasa stariNastavnikObjekat, NastavnikKlasa noviNastavnikObjekat)
        {
            int indexStarogNastavnika = 0;
            indexStarogNastavnika = _listaNastavnika.IndexOf(stariNastavnikObjekat);
            _listaNastavnika.RemoveAt(indexStarogNastavnika);
            _listaNastavnika.Insert(indexStarogNastavnika, noviNastavnikObjekat);   
        }

           
    }
}
