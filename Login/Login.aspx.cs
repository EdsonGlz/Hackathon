using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PlantAppSE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            string user = tbx_User.Text;
            Console.WriteLine(user);
            string pass = tbx_Pass.Text;
            Console.WriteLine(pass);
            if (LoginOps.validateUsers(user, pass))
            {
                if (Session["prevUrl"] != null)
                {
                    Session["User_ID"] = tbx_User.Text;
                    Response.Redirect(Session["prevUrl"].ToString()); //Will redirect to previous page
                }
                else
                {
                    Session["User_ID"] = tbx_User.Text;
                    Response.Redirect("../Terrenos.aspx");
                }
            }
        }
    }
}