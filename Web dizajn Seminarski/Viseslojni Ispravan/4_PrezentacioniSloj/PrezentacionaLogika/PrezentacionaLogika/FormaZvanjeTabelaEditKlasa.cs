using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaZvanjeTabelaEditKlasa
    {
        // atributi
        private string _stringKonekcije;

        // property

        // konstruktor
        public FormaZvanjeTabelaEditKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet PodaciDataSet = new DataSet();
            SPZvanjeDBKlasa SPZvanjeDBObjekat = new SPZvanjeDBKlasa(_stringKonekcije);            
            if (filter.Equals(""))
            {
                PodaciDataSet = SPZvanjeDBObjekat.DajSvaZvanja(); 
            }
            else
            {
                PodaciDataSet = SPZvanjeDBObjekat.DajZvanjaPoNazivu(filter); 
            }
            return PodaciDataSet;
        }
    }
}
