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
    public partial class AgregarFumigacion : System.Web.UI.Page
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
            getMotivo();
            getQuimico();
        }

        public void getMotivo()
        {
            if (!IsPostBack)
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select * from Motivo;";
                SqlCommand cmd = new SqlCommand(query, conn);
                DDL_Motivo.DataSource = cmd.ExecuteReader();
                DDL_Motivo.DataBind();
            }
        }

        public void getQuimico()
        {
            if (!IsPostBack)
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select * from Quimico;";
                SqlCommand cmd = new SqlCommand(query, conn);
                DDL_Quimico.DataSource = cmd.ExecuteReader();
                DDL_Quimico.DataBind();
            }
        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "insert into BitacoraFumigacion (idPlanta, idMotivo, idQuimico, Fecha) " +
                           "values (@idPlanta, @idMotivo, @idQuimico, GETDATE());";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@idPlanta", SqlDbType.Int).Value = IDPlanta;
            cmd.Parameters.Add("@idMotivo", SqlDbType.Int).Value = Convert.ToInt32(DDL_Motivo.SelectedValue);
            cmd.Parameters.Add("@idQuimico", SqlDbType.Int).Value = Convert.ToInt32(DDL_Quimico.SelectedValue);
            cmd.ExecuteNonQuery();
            conn.Close();

            lblModalTitle.Text = "¡Fumigación Agregada!";
            lblModalBody.Text = "El registro de la fumigación del Árbol fue exitoso";
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
            if (lblModalTitle.Text == "¡Fumigación Agregada!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}