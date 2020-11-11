using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;

namespace PlantAppSE.UserControls
{
    public partial class CalCGM : System.Web.UI.UserControl
    {
        public TextBox tbf;

        public CalCGM()
        {
            if (tbFecha != null)
                tbf = tbFecha;
            else
            {
                tbf = new TextBox();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Hora = " ";
                if (DateTime.Now.Hour.ToString().Length < 2)
                {
                    Hora = Hora + "0" + DateTime.Now.Hour.ToString() + ":";
                }
                else
                {
                    Hora = Hora + DateTime.Now.Hour.ToString() + ":";
                }
                if (DateTime.Now.Minute.ToString().Length < 2)
                {
                    Hora = Hora + "0" + DateTime.Now.Minute.ToString();
                }
                else
                {
                    Hora = Hora + DateTime.Now.Minute.ToString();
                }

                tbFecha.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + Hora;

                for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
                {
                    ddlAno.Items.Add(i.ToString());
                }
                for (int i = 0; i < 24; i++)
                {
                    if (i < 10)
                    {
                        ddl_Horas.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddl_Horas.Items.Add(i.ToString());
                    }
                }
                for (int i = 0; i < 60; i++)
                {
                    if (i < 10)
                    {
                        ddl_Minutos.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddl_Minutos.Items.Add(i.ToString());
                    }
                }
                var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                for (int i = 0; i < months.Length; i++)
                {
                    ddlMes.Items.Add(new ListItem(months[i], i.ToString()));
                }


                ddl_Horas.SelectedIndex = ddl_Horas.Items.IndexOf(ddl_Horas.Items.FindByText(DateTime.Now.Hour.ToString()));
                ddl_Minutos.SelectedIndex = ddl_Minutos.Items.IndexOf(ddl_Minutos.Items.FindByText(DateTime.Now.Minute.ToString()));
                ddlMes.SelectedIndex = ddlMes.Items.IndexOf(ddlMes.Items.FindByValue((DateTime.Now.Month - 1).ToString()));
                ddlAno.SelectedIndex = ddlAno.Items.IndexOf(ddlAno.Items.FindByText(DateTime.Now.Year.ToString()));
            }
            if (tbFecha != null)
                tbf = tbFecha;
        }

        protected void btnVerCalendario_Click(object sender, EventArgs e)
        {
            phCalendario.Visible = !phCalendario.Visible;
            btnVerCalendario.Text = (phCalendario.Visible == true ? "Ocultar calendario" : "Ver calendario");
        }

        protected void calendario_SelectionChanged(object sender, EventArgs e)
        {

            tbFecha.Text = calendario.SelectedDate.Year.ToString() + "/" + calendario.SelectedDate.Month.ToString() + "/" + calendario.SelectedDate.Day.ToString() + " " + ddl_Horas.SelectedItem.ToString() + ":" + ddl_Minutos.SelectedItem.ToString();
            phCalendario.Visible = false;
            btnVerCalendario.Text = "Ver calendario";
            if (tbFecha != null)
                tbf = tbFecha;
        }

        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            calendario.VisibleDate = new DateTime(Convert.ToInt16(ddlAno.SelectedValue), Convert.ToInt16(ddlMes.SelectedValue) + 1, 1);
        }
    }
}