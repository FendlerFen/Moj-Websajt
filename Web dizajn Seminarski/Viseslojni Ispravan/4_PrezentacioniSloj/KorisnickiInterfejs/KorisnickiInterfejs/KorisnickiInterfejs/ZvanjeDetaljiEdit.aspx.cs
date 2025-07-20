using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using PrezentacionaLogika;
using System.Configuration; 

namespace KorisnickiInterfejs
{
    public partial class ZvanjeDetaljiEdit : System.Web.UI.Page
    {
        // atributi
        private string _sifra = "";
        FormaZvanjeDetaljiEditKlasa FormaZvanjeDetaljiEditObjekat; 

        // nase metode
        private void IsprazniKontrole()
        {
            SifraTextBox.Text = "";
            NazivTextBox.Text = ""; 

        }

        private void AktivirajKontrole()
        {
            SifraTextBox.Enabled = true;
            NazivTextBox.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            SifraTextBox.Enabled = false ;
            NazivTextBox.Enabled = false;
        }

        private void PrikaziPodatke(FormaZvanjeDetaljiEditKlasa FormaZvanjeDetaljiEditObjekat)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
            SifraTextBox.Text = FormaZvanjeDetaljiEditObjekat.SifraPreuzetogZvanja;
            NazivTextBox.Text = FormaZvanjeDetaljiEditObjekat.NazivPreuzetogZvanja; 

        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            FormaZvanjeDetaljiEditObjekat = new FormaZvanjeDetaljiEditKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            _sifra = Request.QueryString["Sifra"].ToString();
            FormaZvanjeDetaljiEditObjekat.SifraPreuzetogZvanja = _sifra;
            // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
            if (!IsPostBack)
            {
                PrikaziPodatke(FormaZvanjeDetaljiEditObjekat);
            }  
        }
                
        protected void ObrisiButton_Click(object sender, EventArgs e)
        {
            FormaZvanjeDetaljiEditObjekat.SifraPreuzetogZvanja = SifraTextBox.Text;
            bool uspehBrisanja = FormaZvanjeDetaljiEditObjekat.ObrisiZvanje();
            if (uspehBrisanja)
            {
                StatusLabel.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                StatusLabel.Text = "NEUSPEH BRISANJA zapisa!";
            }
        }

        protected void IzmeniButton_Click(object sender, EventArgs e)
        {
            // PREUZIMANJE POCETNIH, STARIH VREDNOSTI - OVDE NEMA POTREBE JER SE URADI NA PAGE LOAD
            //objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja = txbSifra.Text;
            // - ovo se izracuna iz sifre, pa se ne moze ni dodeliti: objFormaZvanjeDetaljiEdit.NazivPreuzetogZvanja = txbNaziv.Text; 
            AktivirajKontrole();
            SifraTextBox.Focus();
        }

        protected void SnimiIzmenuButton_Click(object sender, EventArgs e)
        {
            FormaZvanjeDetaljiEditObjekat.SifraIzmenjenogZvanja = SifraTextBox.Text;
            FormaZvanjeDetaljiEditObjekat.NazivIzmenjenogZvanja = NazivTextBox.Text;
            bool uspehIzmene = FormaZvanjeDetaljiEditObjekat.IzmeniZvanje();
            if (uspehIzmene)
            {
                StatusLabel.Text = "Uspesno izmenjen zapis!";
                IsprazniKontrole();
            }
            else
            {
                StatusLabel.Text = "NEUSPEH BRISANJA zapisa!";
            }
            DeaktivirajKontrole();
        }
    }
}