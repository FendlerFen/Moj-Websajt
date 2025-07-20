using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaZvanjeUnosKlasa
    {
        // atributi
        private string _stringKonekcije;
        private string _sifra;
        private string _naziv;
        
        // property
        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        public FormaZvanjeUnosKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            SPZvanjeDBKlasa ZvanjeDBObjekat = new SPZvanjeDBKlasa(this._stringKonekcije);
            ZvanjeKlasa ZvanjeObjekat = new ZvanjeKlasa();
            ZvanjeObjekat.Sifra = this._sifra;
            ZvanjeObjekat.Naziv = this._naziv;
            uspehSnimanja=ZvanjeDBObjekat.SnimiNovoZvanje(ZvanjeObjekat);

            return uspehSnimanja;

        }




        }
}
