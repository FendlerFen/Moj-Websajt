using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace PoslovnaLogika
{
    public class OpterecenjeKlasa
    {

        private string _stringKonekcije;

        public OpterecenjeKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        public int DajTrenutnoOpterecenje(string IdZvanjaZaProveru)
            // izracunava iz baze podataka koliko trenutno ima zaposlenih za dato zvanje
        {
            int pomUkupnoNastavnika = 0;
            SPNastavnikDBKlasa SPNastavnikDBObjekat = new SPNastavnikDBKlasa(_stringKonekcije);
            
            // u slucaju da ima praznina u ID vrednosti
            string parametarZaProveru = IdZvanjaZaProveru.Replace(" ", ""); 

            pomUkupnoNastavnika = SPNastavnikDBObjekat.DajUkupnoNastavnikaZaZvanje(parametarZaProveru);            
            return pomUkupnoNastavnika;
        }


    }
}
