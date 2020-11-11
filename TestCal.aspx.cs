using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlantAppSE
{
    public partial class TestCal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            TextBox tbFechaInicial = (TextBox)calCGMFechaInicial.FindControl("tbFecha");
            TextBox tbFechaFinal = (TextBox)calCGMFechaFinal.FindControl("tbFecha");
            lblMensaje.Text = "Fecha inicial :  " + tbFechaInicial.Text + " Fecha final : "+tbFechaFinal.Text;
        }
    }
}