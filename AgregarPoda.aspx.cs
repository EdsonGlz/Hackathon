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
    public partial class AgregarPoda : System.Web.UI.Page
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
            }
        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            string date = getDate();
            string filename = "";
            if (FileUploadControl.HasFile)
            {
                try
                {
                    StatusLabel.Visible = true;
                    filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Podas/") + cleanDate(date));
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Visible = true;
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;

                }

                btnClose_Click1(sender, e);
            }
            try
            {
                SqlConnection sqlConnection = DBConn.DBConn.connect();
                string query = "insert BitacoraPoda(idPlanta, FechaHora, ImagenPodaUrl) Values (@id, GETDATE(), @imagen);";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDPlanta;
                cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = "http://fugapp.com/Podas/" + cleanDate(date);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                lblModalTitle.Text = "¡Poda Agregada!";
                lblModalBody.Text = "El registro de la Poda del Árbol fue exitoso!";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            catch
            {
                lblModalTitle.Text = "¡Registro Fallido!";
                lblModalBody.Text = "El registro de la poda del Árbol fallo!";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }


        }

        protected void Imagen_Home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx?id=" + IDPlanta);
        }

        public string getDate()
        {
            string date = "";
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select GETDATE()";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                date = reader[0].ToString();
            }
            return date;
        }


        public string cleanDate(string date)
        {
            var words = date.Split(' ');
            string split_spaces = "";
            string string_dots = "";
            string final = "";
            foreach (string w in words)
            {
                split_spaces = split_spaces + w;
            }
            var split_slash = split_spaces.Split('/');
            foreach (string w in split_slash)
            {
                string_dots = string_dots + w;
            }
            var stringl = string_dots.Split(':');
            foreach (string w in stringl)
            {
                final = final + w;
            }

            final = final + ".jpg";

            return final;
        }


        protected void btnClose_Click1(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Poda Agregada!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}