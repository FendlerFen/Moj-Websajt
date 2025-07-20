using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;
using KlaseMapiranja;

namespace PoslovnaLogika
{
    public class ZaposljavanjeKlasa
    {
        // TREBALO BI DA SE PRERADI IZ 3 KLASE:
        // Sistematizacija radnih mesta - izdvaja ogranicenje
        // Opterecenje - stanje u BP povodom broja nastavnika
        // Zaposljavanje - proverava i uporedjuje podatke iz sistematizacije i opterecenja
        
        // atributi
        private string _stringKonekcije;

        // property

        // konstruktor
        public ZaposljavanjeKlasa(string NoviStringKonekcije)
        {
            _stringKonekcije = NoviStringKonekcije;
        }

        // privatne metode

        // public metode

        public int KolikoImaTrenutnoZaposlenih(string NazivZvanjaIzBazePodatakaParametar)
        {
             // ################################################################
            //izracunavanje ID zvanja
            SPZvanjeDBKlasa SPZvanjeDBObjekat = new SPZvanjeDBKlasa(_stringKonekcije);
            string IdZvanjaIzBazePodataka = SPZvanjeDBObjekat.DajSifruZvanjaPoNazivu(NazivZvanjaIzBazePodatakaParametar);

            // ################################################################
            // IZRACUNAVANJE TRENUTNOG BROJA NASTAVNIKA U BAZI PODATAKA U ODNOSU NA SIFRU ZVANJA
            // 
            OpterecenjeKlasa opterecenjeObjekat = new OpterecenjeKlasa(_stringKonekcije);
            return opterecenjeObjekat.DajTrenutnoOpterecenje(IdZvanjaIzBazePodataka);

        }

        public bool DaLiImaMestaZaZaposljavanje(string NazivZvanjaIzBazePodatakaParametar)
        {
            // POSLOVNO PRAVILO:
            // Na fakultetu ne moze biti zaposleno vise nastavnika u odredjenom
            // zvanju nego sto je dozvoljeno maksimalnim brojem prema Sistematizaciji
            // radnih mesta.

            bool imaMesta = false;

            // ################################################################
            // 1. IZRACUNAVANJE TRENUTNOG BROJA NASTAVNIKA U BAZI PODATAKA
            int pomUkupnoNastavnika = this.KolikoImaTrenutnoZaposlenih(NazivZvanjaIzBazePodatakaParametar);

            // ################################################################
            // 2. MAPIRANJE SLOJEVA - uskladjivanje ID Zvanja iz raznih delova programa
            // Web servis ima d - docenta, baza podataka ima 1 - docent
            string pomIdZvanjeWS = "";
            MaperKlasa maperObjekat = new MaperKlasa(_stringKonekcije);
            pomIdZvanjeWS = maperObjekat.DajSifruZvanjaZaWebServis(NazivZvanjaIzBazePodatakaParametar);

            // ################################################################
            // 3. IZDVAJANJE MAX BROJA NASTAVNIKA ZA ODG ZVANJE
            SistematizacijaKlasa sistematizacijaObjekat = new SistematizacijaKlasa();
            int pomMaxBrojNastavnika = sistematizacijaObjekat.DajMaxMestaZaRadnoMesto(pomIdZvanjeWS);

            // ################################################################
            // 4. UPOREDJIVANJE TRENUTNOG BROJA I MAX BROJA NASTAVNIKA
            if (pomUkupnoNastavnika < pomMaxBrojNastavnika)
            {
                imaMesta = true;
            }
            else
            {
                imaMesta = false;
            }
            return imaMesta;
        }
    }
}
