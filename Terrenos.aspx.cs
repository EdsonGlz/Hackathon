using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlantAppSE
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Info.Visible = false;
                noTerrenos.Visible = true;
            }
            else
            {
                Info.Visible = true;
                noTerrenos.Visible = false;
                lbl_User.Text = " | " + Session["User_ID"].ToString();
            }
        }
    }
}