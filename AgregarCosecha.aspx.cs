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
    public partial class AgregarCosecha : System.Web.UI.Page
    {
        public int IDPlanta = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("/Login/Login.aspx");
            }

            string helper = Request.QueryString["id"];
            IDPlanta = Convert.ToInt32(helper);
        }

        protected void Btn_Listo_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = DBConn.DBConn.connect();
                string query = "insert into BitacoraCosecha (idPlanta, C_Super, C_Extra, C_Primera, C_Mediano, C_Comercial, Fecha) " +
                               "values (@idPlanta, @C_Super, @C_Extra, @C_Primera, @C_Mediano, @C_Comercial, GETDATE());";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@idPlanta", SqlDbType.Int).Value = IDPlanta;
                cmd.Parameters.Add("@C_Super", SqlDbType.Int).Value = Convert.ToInt32(tbx_PiezasSuper.Text);
                cmd.Parameters.Add("@C_Extra", SqlDbType.Int).Value = Convert.ToInt32(tbx_PiezasExtra.Text);
                cmd.Parameters.Add("@C_Primera", SqlDbType.Int).Value = Convert.ToInt32(tbx_PiezasPrimera.Text);
                cmd.Parameters.Add("@C_Mediano", SqlDbType.Int).Value = Convert.ToInt32(tbx_PiezasMediano.Text);
                cmd.Parameters.Add("@C_Comercial", SqlDbType.Int).Value = Convert.ToInt32(tbx_PiezasComercial.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                lblModalTitle.Text = "¡Fumigación Agregada!";
                lblModalBody.Text = "El registro de la fumigación del Árbol fue exitoso";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
            catch(SqlException ex)
            {
                lblModalTitle.Text = "¡Cosecha NO Agregada!";
                lblModalBody.Text = "El registro de la cosecha del Árbol no se realizo exitosamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
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