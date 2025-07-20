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
    public partial class NastavnikSpisak : System.Web.UI.Page
    {
        // atributi
        private FormaNastavnikSpisakKlasa FormaNastavnikSpisakObjekat;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            NastavniciGridView.DataSource = ds.Tables[0];
            NastavniciGridView.DataBind();
        }

      
         
        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            FormaNastavnikSpisakObjekat = new FormaNastavnikSpisakKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);  
        }

        protected void FiltrirajButton_Click(object sender, EventArgs e)
        {
            NapuniGrid(FormaNastavnikSpisakObjekat.DajPodatkeZaGrid(FilterTextBox.Text));
        }

        protected void SviButton_Click(object sender, EventArgs e)
        {
            NapuniGrid(FormaNastavnikSpisakObjekat.DajPodatkeZaGrid(""));
        }
    }
}