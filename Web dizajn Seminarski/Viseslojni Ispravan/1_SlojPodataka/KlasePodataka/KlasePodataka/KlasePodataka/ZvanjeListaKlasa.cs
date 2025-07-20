using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class ZvanjeListaKlasa:IZvanjeListaKlasa
    {
        // atributi
        private List<ZvanjeKlasa> _listaZvanja; 

        // property
        public List<ZvanjeKlasa> ListaZvanja
        {
            get
            {
                return _listaZvanja;
            }
            set
            {
                if (this._listaZvanja != value)
                    this._listaZvanja = value;
            }
        }

        // konstruktor
        public ZvanjeListaKlasa()
        {
            _listaZvanja = new List<ZvanjeKlasa>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(ZvanjeKlasa novoZvanjeObjekat)
        {
            _listaZvanja.Add(novoZvanjeObjekat);
        }

        public void ObrisiElementListe(ZvanjeKlasa zvanjeObjekatZaBrisanje)
        {
            _listaZvanja.Remove(zvanjeObjekatZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaZvanja.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(ZvanjeKlasa staroZvanjeObjekat, ZvanjeKlasa novoZvanjeObjekat)
        {
            int indexStarogZvanja = 0;
            indexStarogZvanja = _listaZvanja.IndexOf(staroZvanjeObjekat);  
            _listaZvanja.RemoveAt(indexStarogZvanja); 
            _listaZvanja.Insert(indexStarogZvanja, novoZvanjeObjekat);   
        }

           

     




    }
}
