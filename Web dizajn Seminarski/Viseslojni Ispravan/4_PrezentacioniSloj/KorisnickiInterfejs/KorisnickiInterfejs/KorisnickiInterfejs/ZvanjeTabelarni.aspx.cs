using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration;
using System.Data;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class ZvanjeTabelarni : System.Web.UI.Page
    {
              
        
        private void NapuniGrid(DataSet PodaciDataSet)
        {
            // povezivanje grida sa datasetom
            SpisakZvanjaGridView.DataSource = PodaciDataSet.Tables[0];
            SpisakZvanjaGridView.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FiltrirajButton_Click(object sender, EventArgs e)
        {
            FormaZvanjeTabelaEditKlasa FormaZvanjeTabelaEditObjekat = new FormaZvanjeTabelaEditKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(FormaZvanjeTabelaEditObjekat.DajPodatkeZaGrid(FilterTextBox.Text));
        }

        protected void SviButton_Click(object sender, EventArgs e)
        {
            FormaZvanjeTabelaEditKlasa FormaZvanjeTabelaEditObjekat = new FormaZvanjeTabelaEditKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(FormaZvanjeTabelaEditObjekat.DajPodatkeZaGrid(""));
        }
    }
}