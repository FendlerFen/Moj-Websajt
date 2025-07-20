using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class FormaNastavnikUnosKlasa
    {
        // atributi
        private string _stringKonekcije;
        private string _JMBG; // string je zbog vodece nule koja je moguca u JMBG broju
        private string _prezime;
        private string _ime;
        private string _nazivZvanja;

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
        
        public string NazivZvanja
        {
            get { return _nazivZvanja; }
            set { _nazivZvanja = value; }
        }
        
        // konstruktor
        public FormaNastavnikUnosKlasa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaCombo()
        {
            DataSet PodaciDataSet = new DataSet();
            SPZvanjeDBKlasa ZvanjeDBObjekat = new SPZvanjeDBKlasa(this._stringKonekcije);
            PodaciDataSet = ZvanjeDBObjekat.DajSvaZvanja() ; 
            return PodaciDataSet;
        }

        public bool DaLiJeSvePopunjeno()
        {
            bool svePopunjeno = false;

            if (this._nazivZvanja.Equals("Izaberite..."))
            {
                svePopunjeno = false;
            }
            else
            {
                if ((this._JMBG.Length > 0) && (this._prezime.Length > 0) && (this._ime.Length > 0) && (this._nazivZvanja.Length > 0))
                {
                    svePopunjeno = true;
                }
                else
                {
                    svePopunjeno = false;
                }
            }          

            return svePopunjeno;
        }


        public bool DaLiJeJedinstvenZapis()
        {
            bool jedinstvenZapis = false;
            DataSet PodaciDataSet = new DataSet();
            SPNastavnikDBKlasa SPNastavnikDBObjekat = new SPNastavnikDBKlasa(this._stringKonekcije);
            PodaciDataSet = SPNastavnikDBObjekat.DajNastavnikaPoJMBG(this._JMBG);
            
            if (PodaciDataSet.Tables[0].Rows.Count == 0)
            {
                jedinstvenZapis = true;
            }
            else
            {
                jedinstvenZapis = false;
            }

            return jedinstvenZapis;

        }

        public bool DaLiSuPodaciUskladjeniSaPoslovnimPravilima()
        {
            // POSLOVNO PRAVILO:
            // Na fakultetu ne moze biti zaposleno vise nastavnika u odredjenom
            // zvanju nego sto je dozvoljeno maksimalnim brojem prema Sistematizaciji
            // radnih mesta.
            
            bool uskladjeniPodaci = false;

            // klasa poslovne logike
            ZaposljavanjeKlasa ZaposljavanjeObjekat = new ZaposljavanjeKlasa(this._stringKonekcije);
                        
            uskladjeniPodaci = ZaposljavanjeObjekat.DaLiImaMestaZaZaposljavanje(this._nazivZvanja);

            return uskladjeniPodaci;
        }

        public string SnimiPodatke()
        {
            string porukaUspehaSnimanja="";
            bool uspehSnimanja = false;

            // 1. provera popunjenosti
            bool SvePopunjeno = this.DaLiJeSvePopunjeno();
            if (SvePopunjeno==true) {
                porukaUspehaSnimanja = "Sve je popunjeno!";
             }
            else
            {
                porukaUspehaSnimanja = "NIJE SVE POPUNJENO!";
                return porukaUspehaSnimanja;
            }

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = this.DaLiJeJedinstvenZapis();
            if (JedinstvenZapis==true)
            {
                porukaUspehaSnimanja = porukaUspehaSnimanja + "Jeste jedinstven zapis!";
            }
            else
            {
                porukaUspehaSnimanja = porukaUspehaSnimanja + "NIJE JEDINSTVEN ZAPIS!";
                return porukaUspehaSnimanja;
            }

            // 3. provera ispravnosti - provera uskladjenosti podataka sa poslovnim pravilima
            bool UskladjenoSaPoslovnimPravilima = this.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();

            if (UskladjenoSaPoslovnimPravilima==true)
             {
                porukaUspehaSnimanja = porukaUspehaSnimanja + "Jeste uskladjeno sa poslovnim pravilima!";
            }
            else
            {
               porukaUspehaSnimanja = porukaUspehaSnimanja + "PODACI NISU USKLADJENI SA POSLOVNIM PRAVILIMA - ogranicenje broja nastavnog osoblja u odnosu na sistematizaciju radnih mesta!";
               return porukaUspehaSnimanja;
            }
            
            if ((SvePopunjeno==true) && (JedinstvenZapis==true) && (UskladjenoSaPoslovnimPravilima==true)){
                SPNastavnikDBKlasa objNastavnikDB = new SPNastavnikDBKlasa(_stringKonekcije);

                NastavnikKlasa NastavnikObjekat = new NastavnikKlasa();
                NastavnikObjekat.JMBG = _JMBG; // nije dobro sto je JMBG integer, jer moze poceti sa nula
                NastavnikObjekat.Prezime = _prezime;
                NastavnikObjekat.Ime = _ime;

                ZvanjeKlasa ZvanjeObjekat = new ZvanjeKlasa();

                SPZvanjeDBKlasa SPZvanjeDBObjekat = new SPZvanjeDBKlasa(_stringKonekcije);
                ZvanjeObjekat.Sifra = SPZvanjeDBObjekat.DajSifruZvanjaPoNazivu(_nazivZvanja);
                ZvanjeObjekat.Naziv = _nazivZvanja;

                NastavnikObjekat.Zvanje = ZvanjeObjekat;

                uspehSnimanja = objNastavnikDB.SnimiNovogNastavnika(NastavnikObjekat);
                if (uspehSnimanja)
                {
                    porukaUspehaSnimanja = porukaUspehaSnimanja +  "Uspesno snimljeni novi podaci!";
                }
                else
                {
                    porukaUspehaSnimanja = porukaUspehaSnimanja + "GRESKA SNIMANJA PODATAKA!";
                }
                return porukaUspehaSnimanja;
            }
            else
            {
                return "NEUSPEH SNIMANJA!";
            }
            
        }

        
    }
}
