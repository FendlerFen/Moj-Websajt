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
    public partial class ZvanjeTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            SpisakZvanjaEditGridView.DataSource = ds.Tables[0];
            SpisakZvanjaEditGridView.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormaZvanjeTabelaEditKlasa FormaZvanjeTabelaEditObjekat = new FormaZvanjeTabelaEditKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                NapuniGrid(FormaZvanjeTabelaEditObjekat.DajPodatkeZaGrid(""));
            }
        }
                
        protected void SpisakZvanjaEditGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ZvanjeDetaljiEdit.aspx?Sifra=" + SpisakZvanjaEditGridView.Rows[SpisakZvanjaEditGridView.SelectedIndex].Cells[1].Text);
        }
    }
}