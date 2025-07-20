using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaNastavnikSpisakKlasa
    {
        // atributi
        private string _stringKonekcije;

        // property

        // konstruktor
        public FormaNastavnikSpisakKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet PodaciDataSet = new DataSet();
            SPNastavnikDBKlasa objNastavnikDB = new SPNastavnikDBKlasa(_stringKonekcije);
            if (filter.Equals(""))
            {
                PodaciDataSet = objNastavnikDB.DajSveNastavnike(); 
            }
            else
            {
                PodaciDataSet = objNastavnikDB.DajNastavnikaPoPrezimenu(filter);
            }
            return PodaciDataSet;
        }

    }
}
