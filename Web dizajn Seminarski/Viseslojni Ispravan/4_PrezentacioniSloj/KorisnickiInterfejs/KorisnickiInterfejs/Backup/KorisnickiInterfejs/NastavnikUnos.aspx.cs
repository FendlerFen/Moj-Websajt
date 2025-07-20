using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class NastavnikUnos : System.Web.UI.Page
    {
        // atributi
        FormaNastavnikUnosKlasa FormaNastavnikUnosObjekat; 
        
        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet ZvanjaDataSet = new DataSet();
            ZvanjaDataSet = FormaNastavnikUnosObjekat.DajPodatkeZaCombo();

            int ukupno = ZvanjaDataSet.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ZvanjeDropDownList.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ZvanjeDropDownList.Items.Add(ZvanjaDataSet.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
            JMBGTextBox.Text = "";
            PrezimeTextBox.Text = "";
            ImeTextBox.Text = "";
            ZvanjeDropDownList.Text ="Izaberite...";
            StatusLabel.Text = ""; 
        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            FormaNastavnikUnosObjekat = new FormaNastavnikUnosKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            if (!IsPostBack)
            {
                NapuniCombo();
            }
        }

        protected void SnimiButton_Click(object sender, EventArgs e)
        {
            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            FormaNastavnikUnosObjekat.JMBG = JMBGTextBox.Text;
            FormaNastavnikUnosObjekat.Prezime = PrezimeTextBox.Text;
            FormaNastavnikUnosObjekat.Ime = ImeTextBox.Text;
            FormaNastavnikUnosObjekat.NazivZvanja = ZvanjeDropDownList.Text;

            string porukaStatusaSnimanja = "";
            // *********** provera ispravnosti vrednosti
            if (ZvanjeDropDownList.Text == "Izaberite...")
            {
                porukaStatusaSnimanja = "NISTE IZABRALI NAZIV ZVANJA!";
            }
            else
            {   
                try
                {
                    porukaStatusaSnimanja = FormaNastavnikUnosObjekat.SnimiPodatke();
                }
                catch (Exception greska)
                {
                    porukaStatusaSnimanja = "GRESKA:" + greska;
                }
                
            }
            StatusLabel.Text = porukaStatusaSnimanja;

        }

        protected void PonistiButton_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }
    }
}