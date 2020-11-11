using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace PlantAppSE
{
    public partial class EventosFuturos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ready_Click(object sender, EventArgs e)
        {
            prueba.Text = Request["datetime"];
            prueba.Text = prueba.Text.Replace('/', '-');
            string bien = "";
            if (prueba.Text.Length != 19)
            {
                bien = prueba.Text.Insert(11, "0");
            }
            else
            {
                bien = prueba.Text;
            }
            DateTime oDate = DateTime.ParseExact(bien, "MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }

    }
}