using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PlantAppSE
{
    public partial class AgregarSupervicion : System.Web.UI.Page
    {
        public int IDPlanta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("/Login/Login.aspx");
            }
            string helper = Request.QueryString["id"];
            IDPlanta = Convert.ToInt32(helper);


            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
                getEstadoTronco();
                getEstadoRamas();
                getEstadoHojas();
            }
        }

        public void getEstadoTronco()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoTronco, EstadoTronco from EstadoTronco;";
            SqlCommand cmd = new SqlCommand(query, conn);
            DDL_EstadoTronco.DataSource = cmd.ExecuteReader();
            DDL_EstadoTronco.DataBind();
        }

        public void getEstadoRamas()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoRamas, EstadoRamas from EstadoRamas;";
            SqlCommand cmd = new SqlCommand(query, conn);
            DDL_EstadoRamas.DataSource = cmd.ExecuteReader();
            DDL_EstadoRamas.DataBind();
        }

        public void getEstadoHojas()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoHojas, EstadoHojas from EstadoHojas;";
            SqlCommand cmd = new SqlCommand(query, conn);
            DDL_EstadoHojas.DataSource = cmd.ExecuteReader();
            DDL_EstadoHojas.DataBind();
        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "insert into BitacoraSupervision (idPlanta, idEstadoTronco, idEstadoRamas, idEstadohojas, Fecha, Observaciones ) values (@idPlanta, @idETronco, @idERamas, @idEHojas, GETDATE(), @Observaciones);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@idPlanta", SqlDbType.Int).Value = IDPlanta;
            cmd.Parameters.Add("@idETronco", SqlDbType.Int).Value = Convert.ToInt32(DDL_EstadoTronco.SelectedValue);
            cmd.Parameters.Add("@idERamas", SqlDbType.Int).Value = Convert.ToInt32(DDL_EstadoRamas.SelectedValue);
            cmd.Parameters.Add("@idEHojas", SqlDbType.Int).Value = Convert.ToInt32(DDL_EstadoHojas.SelectedValue);
            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = tbx_Observacioness.Text;
            cmd.ExecuteNonQuery();
            conn.Close();

            lblModalTitle.Text = "¡Supervisión Agregada!";
            lblModalBody.Text = "El registro de la supervisión del Árbol fue exitoso";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();

            btnClose_Click(sender, e);
        }

        protected void Imagen_Home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx?id=" + IDPlanta);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
        }

        protected void btnClose_Click1(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Supervisión Agregada!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}