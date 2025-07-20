using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class ZvanjeUnos : System.Web.UI.Page
    {
        // atributi
        private FormaZvanjeUnosKlasa FormaZvanjaUnosObjekat;

        private void IsprazniKontrole()
        {
            SifraTextBox.Text = "";
            NazivTextBox.Text = "";
        }



            protected void Page_Load(object sender, EventArgs e)
        {
            FormaZvanjaUnosObjekat = new FormaZvanjeUnosKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
        }
                       
        protected void OdustaniButton_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }

        protected void SnimiButton_Click(object sender, EventArgs e)
        {
            bool uspehSnimanja = false;

            FormaZvanjaUnosObjekat.Sifra = SifraTextBox.Text;
            FormaZvanjaUnosObjekat.Naziv = NazivTextBox.Text;
            uspehSnimanja=FormaZvanjaUnosObjekat.SnimiPodatke();
            if (uspehSnimanja)
            {
                StatusLabel.Text = "Uspesno snimljeni podaci!";
            }
            else
            {
                StatusLabel.Text = "Problem snimanja podataka!";
            }
            
        }
    }
}