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
    public partial class ZvanjeStampa : System.Web.UI.Page
    {
        // atributi

        // nase metode
        private void NapuniGrid(DataSet noviPodaciDataSet)
        {
            // povezivanje grida sa datasetom
            SpisakZvanjaGridView.DataSource = noviPodaciDataSet.Tables[0];
            SpisakZvanjaGridView.DataBind();
        }
        
                
        protected void Page_Load(object sender, EventArgs e)
        {
            string filterVrednost = "";
            FormaZvanjeStampaKlasa objFormaZvanjeStampa = new FormaZvanjeStampaKlasa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);

            try
            {
                if (Request.QueryString["filter"].ToString() != null)
                {
                    filterVrednost = Request.QueryString["filter"].ToString();
                }
                

                if ((filterVrednost.Equals("")) || (filterVrednost==null) || (filterVrednost == "0")) {
                    NaslovLabel.Text = "SPISAK SVIH ZVANJA";
                }
                else
                {
                    NaslovLabel.Text = "FILTRIRANI SPISAK ZVANJA, naziv=" + filterVrednost;
                }

               
            }catch (Exception greska)
            {
                NaslovLabel.Text = "SPISAK SVIH ZVANJA";
            }
            string parametarZaFilter = "";
            if (filterVrednost == "0") 
            { parametarZaFilter = "";
            }
            else
            {
                parametarZaFilter = filterVrednost;
            }
            NapuniGrid(objFormaZvanjeStampa.DajPodatkeZaGrid(parametarZaFilter));

        }
    }
}