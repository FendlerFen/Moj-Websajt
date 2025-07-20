using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class NastavnikKlasa:INastavnikKlasa
    {
        // atributi
        private string _JMBG;
        private string _prezime;
        private string _ime;
        private ZvanjeKlasa _zvanjeObjekat;

        // property
        public string JMBG
        {
            get { return _JMBG; }
            set { _JMBG = value; }
        }

        

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }
        

        public ZvanjeKlasa Zvanje
        {
            get { return _zvanjeObjekat; }
            set { _zvanjeObjekat = value; }
        }
    }
}
