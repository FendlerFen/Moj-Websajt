using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class ZvanjeParametarStampe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }      

        protected void FilterStampaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZvanjeStampa.aspx?filter=" + FilterTextBox.Text);
        }
    }
}