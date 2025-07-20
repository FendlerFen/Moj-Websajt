using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaZvanjeDetaljiEditKlasa
    {
   // atributi i property
        private string _stringKonekcije;
        private SPZvanjeDBKlasa SPZvanjeDBObjekat;

        private ZvanjeKlasa preuzetoZvanjeObjekat;
        private ZvanjeKlasa izmenjenoZvanjeObjekat;

        private string _sifraPreuzetogZvanja;
        private string _nazivPreuzetogZvanja;

        private string _sifraIzmenjenogZvanja;
        private string _nazivIzmenjenogZvanja;
        
// PROPERTY

        public string SifraPreuzetogZvanja
        {
            get { return _sifraPreuzetogZvanja; }
            set { _sifraPreuzetogZvanja = value; _nazivPreuzetogZvanja = DajNaziv(_sifraPreuzetogZvanja); }
        }

        public string NazivPreuzetogZvanja
        {
            get { return _nazivPreuzetogZvanja; }
            // OVO NECEMO DA OMOGUCIMO, JER SE RACUNA IZ SIFRE set { pNazivPreuzetogZvanja = value; }
        }

        public string SifraIzmenjenogZvanja
        {
            get { return _sifraIzmenjenogZvanja; }
            set { _sifraIzmenjenogZvanja = value; }
        }


        public string NazivIzmenjenogZvanja
        {
            get { return _nazivIzmenjenogZvanja; }
            set { _nazivIzmenjenogZvanja = value; }
        }


    // konstruktor
        public FormaZvanjeDetaljiEditKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            SPZvanjeDBObjekat = new SPZvanjeDBKlasa(_stringKonekcije);
        }

        // privatne metode
        private string DajNaziv(string pomSifra)
        {
            string pomNaziv ="";
            DataSet PodaciDataSet = new DataSet();
            pomNaziv = SPZvanjeDBObjekat.DajNazivPremaIDZvanja(pomSifra); 

            return pomNaziv;
        }

        // javne metode
        public bool ObrisiZvanje()
        {
            // zvanje koje je trenutno u atributima dato, TJ. preuzeta sifra je bitna
            bool uspehBrisanja = false;
            uspehBrisanja = SPZvanjeDBObjekat.ObrisiZvanje(_sifraPreuzetogZvanja);  

            return uspehBrisanja;

        }

        public bool IzmeniZvanje()
        {
            bool uspehIzmene = false;
            preuzetoZvanjeObjekat = new ZvanjeKlasa();
            izmenjenoZvanjeObjekat = new ZvanjeKlasa();

            preuzetoZvanjeObjekat.Sifra = _sifraPreuzetogZvanja;
            preuzetoZvanjeObjekat.Naziv = _nazivPreuzetogZvanja;

            izmenjenoZvanjeObjekat.Sifra = _sifraIzmenjenogZvanja;
            izmenjenoZvanjeObjekat.Naziv = _nazivIzmenjenogZvanja;

            uspehIzmene = SPZvanjeDBObjekat.IzmeniZvanje(preuzetoZvanjeObjekat, izmenjenoZvanjeObjekat);  

            return uspehIzmene;
        }
    }
}
