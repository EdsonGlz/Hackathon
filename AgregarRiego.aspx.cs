using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

using PlantAppSE.DBConn;

namespace PlantAppSE
{
    public partial class Historia1 : System.Web.UI.Page
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

            for (int i = 1; i <= 20; i++)
            {
                Litros.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
            }

        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = DBConn.DBConn.connect();
                string query = "insert BitacoraRiego(idPlanta, FechaHora, LitrosAgua) Values (@id, GETDATE(), @Valor);";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDPlanta;
                cmd.Parameters.Add("@Valor", SqlDbType.Int).Value = Convert.ToInt32(Litros.SelectedItem.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                lblModalTitle.Text = "¡Riego Agregado!";
                lblModalBody.Text = "El registro del riego del Árbol fue exitoso";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            catch
            {
                lblModalTitle.Text = "¡Riego NO Agregado!";
                lblModalBody.Text = "El registro del riego del Árbol no se realizo exitosamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            btnClose_Click(sender, e);
        }

        protected void Imagen_Home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx?id=" + IDPlanta);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Riego Agregado!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}