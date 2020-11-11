using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PlantAppSE
{
    public partial class PlantaCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("/Login/Login.aspx");
            }
        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = DBConn.DBConn.connect();
                string query = "insert PlantaCatalogo(Nombre, NombreCientifico, Clasificacion) Values (@Nombre, @NombreCientifico, @Clasificacion);";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbx_nombre.Text;
                cmd.Parameters.Add("@NombreCientifico", SqlDbType.VarChar).Value = tbx_NombreCientifico.Text;
                cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar).Value = tbx_Clasificaion.Text;

                if (tbx_Clasificaion.Text != "" || tbx_nombre.Text != "" || tbx_NombreCientifico.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    lblModalTitle.Text = "¡Planta Agregada al Cátalogo!";
                    lblModalBody.Text = "El registro de la Planta al Catálogo fue exitoso";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    cmd.Parameters.Add("@Hola", SqlDbType.VarChar).Value = tbx_Clasificaion.Text;
                }
                
            }
            catch (SqlException ex)
            {
                lblModalTitle.Text = "¡Planta NO Agregada Al Catálogo!";
                lblModalBody.Text = "El registro de la Planta al Catálogo no se realizo exitosamente! <br />";
                if (ex.Number == 2627)
                {
                    lblModalBody.Text = lblModalBody.Text + " La planta " + tbx_nombre.Text.ToUpper() + " ya habia sido registrada anteriormente!";
                }
                else
                {
                    lblModalBody.Text = lblModalBody.Text + "Los datos ingresados no son validos, verifiquelos";
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Planta Agregada al Cátalogo!")
            {
                Response.Redirect("/Default.aspx?id=" + 0);
            }
        }
    }
}