using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class SPNastavnikDBKlasa
    {
        // atributi
        private string _stringKonekcije;

        // property
        // 1. nacin
        public string StringKonekcije
        {
            get
            {
                return _stringKonekcije;
            }
        }
        // konstruktor
        // 2. nacin prijema vrednosti stringa konekcije spolja i dodele atributu
        public SPNastavnikDBKlasa(string noviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            _stringKonekcije = noviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveNastavnike()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet PodaciDataSet = new DataSet();

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();
            SqlCommand pomKomanda = new SqlCommand("DajSveNastavnikeSaJoin", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = pomKomanda;
            adapter.Fill(PodaciDataSet);
            pomKonekcija.Close();
            pomKonekcija.Dispose();
            
            return PodaciDataSet;
        }

        public DataSet DajNastavnikaPoPrezimenu(string prezimeFilter)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet PodaciDataSet = new DataSet();

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();
            SqlCommand pomKomanda = new SqlCommand("DajNastavnikaPoPrezimenu", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            pomKomanda.Parameters.Add("@NastavnikPrezime", SqlDbType.NVarChar).Value = prezimeFilter;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = pomKomanda;
            adapter.Fill(PodaciDataSet);
            pomKonekcija.Close();
            pomKonekcija.Dispose();

            return PodaciDataSet;
        }


        public DataSet DajNastavnikaPoJMBG(string JMBGFilter)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet PodaciDataSet = new DataSet();

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();
            SqlCommand pomKomanda = new SqlCommand("DajNastavnikaPoJMBG", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            pomKomanda.Parameters.Add("@NastavnikJMBG", SqlDbType.NVarChar).Value = JMBGFilter;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = pomKomanda;
            adapter.Fill(PodaciDataSet);
            pomKonekcija.Close();
            pomKonekcija.Dispose();

            return PodaciDataSet;
        }

        public int DajUkupnoNastavnikaZaZvanje(string IDZvanjaFilter)
        {
            int ukupnoNastavnika=0;
            DataSet PodaciDataSet = new DataSet();
            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();
            SqlCommand pomKomanda = new SqlCommand("DajBrojNastavnikaPremaSifriZvanja", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            pomKomanda.Parameters.Add("@SifraZvanja", SqlDbType.NVarChar).Value = IDZvanjaFilter;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = pomKomanda;
            adapter.Fill(PodaciDataSet);
            pomKonekcija.Close();
            pomKonekcija.Dispose();
            ukupnoNastavnika = int.Parse(PodaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());  
            return ukupnoNastavnika;
        } 


        private NastavnikListaKlasa DajListuSvihNastavnika()
        {
            // PRIPREMA PROMENLJIVIH
            NastavnikListaKlasa nastavnikListaObjekat = new NastavnikListaKlasa();
            DataSet podaciDataSetNastavnika = new DataSet();
            NastavnikKlasa NastavnikObjekat;
            ZvanjeKlasa ZvanjeObjekat;

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();
            SqlCommand pomKomanda = new SqlCommand("DajSveNastavnikeSaJoinSifromZvanja", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = pomKomanda;
            adapter.Fill(podaciDataSetNastavnika);
            pomKonekcija.Close();
            pomKonekcija.Dispose();

            // FORMIRANJE OBJEKATA I UBACIVANJE U LISTU
            for (int brojac = 0; brojac < podaciDataSetNastavnika.Tables[0].Rows.Count; brojac++)
            {
                ZvanjeObjekat = new ZvanjeKlasa();
                ZvanjeObjekat.Sifra = podaciDataSetNastavnika.Tables[0].Rows[brojac].ItemArray[4].ToString();
                ZvanjeObjekat.Naziv = podaciDataSetNastavnika.Tables[0].Rows[brojac].ItemArray[3].ToString();

                NastavnikObjekat = new NastavnikKlasa();
                NastavnikObjekat.JMBG = podaciDataSetNastavnika.Tables[0].Rows[brojac].ItemArray [0].ToString (); 
                NastavnikObjekat.Prezime = podaciDataSetNastavnika.Tables[0].Rows[brojac].ItemArray [0].ToString (); 
                NastavnikObjekat.Ime = podaciDataSetNastavnika.Tables[0].Rows[brojac].ItemArray [0].ToString ();
                NastavnikObjekat.Zvanje = ZvanjeObjekat;
                nastavnikListaObjekat.DodajElementListe (NastavnikObjekat);
            }

            return nastavnikListaObjekat;
        }
        

        public bool SnimiNovogNastavnika(NastavnikKlasa noviNastavnikObjekat)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;

            SqlConnection pompomKonekcija = new SqlConnection(_stringKonekcije);
            pompomKonekcija.Open();

            SqlCommand pompomKomanda = new SqlCommand("DodajNovogNastavnika", pompomKonekcija);
            pompomKomanda.CommandType = CommandType.StoredProcedure;
            pompomKomanda.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = noviNastavnikObjekat.JMBG;
            pompomKomanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Prezime;
            pompomKomanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Ime;
            pompomKomanda.Parameters.Add("@IDZvanja", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Zvanje.Sifra;

            brojSlogova = pompomKomanda.ExecuteNonQuery();
            pompomKonekcija.Close();
            pompomKonekcija.Dispose();
     
            // 2. varijanta
            return (brojSlogova > 0);

        }

        public bool ObrisiNastavnika(string JMBGNastavnikaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();

            SqlCommand pomKomanda = new SqlCommand("ObrisiNastavnika", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            pomKomanda.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = JMBGNastavnikaZaBrisanje;
            brojSlogova = pomKomanda.ExecuteNonQuery();
            pomKonekcija.Close();
            pomKonekcija.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniNastavnika(NastavnikKlasa stariNastavnikObjekat, NastavnikKlasa noviNastavnikObjekat)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;
            // 1. varijanta - skolska 
            //bool uspehSnimanja= false;

            SqlConnection pomKonekcija = new SqlConnection(_stringKonekcije);
            pomKonekcija.Open();

            SqlCommand pomKomanda = new SqlCommand("IzmeniZvanje", pomKonekcija);
            pomKomanda.CommandType = CommandType.StoredProcedure;
            pomKomanda.Parameters.Add("@StariJMBG", SqlDbType.NVarChar).Value = stariNastavnikObjekat.JMBG;
            pomKomanda.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = noviNastavnikObjekat.JMBG;
            pomKomanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Prezime;
            pomKomanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Ime;
            pomKomanda.Parameters.Add("@IDZvanja", SqlDbType.NVarChar).Value = noviNastavnikObjekat.Zvanje.Sifra;
            brojSlogova = pomKomanda.ExecuteNonQuery();
            pomKonekcija.Close();
            pomKonekcija.Dispose();

            return (brojSlogova > 0);

        }

        


    }
}
