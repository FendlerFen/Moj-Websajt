using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace KlaseMapiranja
{
    public class MaperKlasa
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public MaperKlasa(string noviStringKonekcije)
        {
            pStringKonekcije = noviStringKonekcije;
        }
        public string DajSifruZvanjaZaWebServis(string NazivZvanjaIzBazePodatakaParametar)
        {
            string pomIDZvanjaWS = "";
            
            // OVO JE HEURISTIKA:
            // prvo slovo naziva je to sifra u drugom sistemu
            // DAKLE: sifra zvanja za web servis je prvo slovo naziva zvanja, znaci za docent je "d"
            pomIDZvanjaWS = NazivZvanjaIzBazePodatakaParametar[0].ToString();

            return pomIDZvanjaWS;

        }

    }
}
