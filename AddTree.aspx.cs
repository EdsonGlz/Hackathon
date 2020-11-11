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
    public partial class Contact : Page
    {
        public int IDUbicacion { get; set; }
        public int IDPlanta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("/Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select idUbicacion, NombreSector from Ubicacion;";
                SqlCommand cmd = new SqlCommand(query, conn);
                DDL_Ubicacion.DataSource = cmd.ExecuteReader();
                DDL_Ubicacion.DataBind();
                setDDLs();
                DDl_Estado.SelectedValue = 6.ToString();
            }


            this.Wizard1.StartNextButtonText = "Siguiente";
            this.Wizard1.StepNextButtonText = "Siguiente";
            this.Wizard1.FinishPreviousButtonText = "Anterior";
            this.Wizard1.StepPreviousButtonText = "Anterior";
            this.Wizard1.FinishCompleteButtonText = "Terminar";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                string fileName = FileUploadControl.FileName;
                FileUploadControl.SaveAs("~/UploadedContent/" + fileName);
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string er = "<br />";
            bool error = false;
            string filename = "";
            int id = 0;
            string query = "";

            try
            {
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        StatusLabel.Visible = true;
                        filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                        FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + cleanDate(getDate()));
                        StatusLabel.Text = "Upload status: File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Visible = true;
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;

                    }
                }
                SqlConnection sqlConnection = DBConn.DBConn.connect();
                if (FileUploadControl.HasFile)
                {
                    query = "insert into Planta (idPlantaCatalogo, idUbicacion, idEstadoCiudad, AnioPlatancion, AlturaCentimetros, Donador, ValorComercial, ImagenUrl ) Values (@idPlantaCatalogo, @idUbicacion, @idEstadoCiudad, @AnioPlantacion , @AlturaCentimetros, @Donador, @ValorComercial, @Url); SELECT SCOPE_IDENTITY();";
                }
                else
                {
                    query = "insert into Planta (idPlantaCatalogo, idUbicacion, idEstadoCiudad, AnioPlatancion, AlturaCentimetros, Donador, ValorComercial) Values (@idPlantaCatalogo, @idUbicacion, @idEstadoCiudad, @AnioPlantacion , @AlturaCentimetros, @Donador, @ValorComercial); SELECT SCOPE_IDENTITY();";
                }
                    
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@idPlantaCatalogo", SqlDbType.Int).Value = Convert.ToInt32(DDL_PlantaCatalogo.SelectedValue);
                cmd.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = Convert.ToInt32(DDL_Ubicacion.SelectedValue);
                cmd.Parameters.Add("@idEstadoCiudad", SqlDbType.Int).Value = getidEstadoCiudad();
                cmd.Parameters.Add("@AnioPlantacion", SqlDbType.Int).Value = Convert.ToInt32(DDL_AñoPlantacion.SelectedValue);
                try
                {
                    cmd.Parameters.Add("@AlturaCentimetros", SqlDbType.Int).Value = Convert.ToInt32(tbx_Altura.Text);
                    
                }
                catch
                {
                    er = er + "El valor de la altura no es valido!" + "<br />";
                    error = true;
                }
                try
                {
                    cmd.Parameters.Add("@Donador", SqlDbType.VarChar).Value = tbx_Donador.Text;
                }
                catch
                {
                    er = er + "El valor de la altura no es valido!" + "<br />";
                    error = true;
                }
                cmd.Parameters.Add("@ValorComercial", SqlDbType.Int).Value = Convert.ToInt32(DDl_Valor.SelectedValue);
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = "http://localhost:58587/Uploads/" + filename;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                IDPlanta = id;
                Response.Redirect("./Default?id=" + IDPlanta);

            }
            catch
            {
                lblModalTitle.Text = "Planta no Agregada";
                lblModalBody.ForeColor = System.Drawing.Color.Red;
                lblModalBody.Text = "Error:" + er;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            finally
            {
                if (!error)
                {
                    lblModalTitle.Text = "¡Planta Agregada Exitosamente!";
                    lblModalBody.ForeColor = System.Drawing.Color.Red;
                    lblModalBody.Text = "Error:" + er;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }

        }

        public int getID(string nombre)
        {
            int id = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idPlanta from Planta where Nombre = @nombre;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                 id = Convert.ToInt32( reader[0]);
            }
            return id;
        }

        public int getidEstadoCiudad()
        {
            int id = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoCiudad from EstadoCiudad where idEstado = @idEstado and idMunicipio = @idMunicipio;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idEstado", DDl_Estado.SelectedValue);
            cmd.Parameters.AddWithValue("@idMunicipio", DDL_Ciudad.SelectedValue);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader[0]);
            }
            return id;
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

        public void setDDLs()
        {
            setDDLEstado();
            setDDlAño();
            setDDlCiudad(6);
            setDDLValor();
            setDDLPlantaCatalogo();
        }

        public void setDDLEstado()
        {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select idEstado, EstadoNombre from Estado order by EstadoNombre asc";
                SqlCommand cmd = new SqlCommand(query, conn);
                DDl_Estado.DataSource = cmd.ExecuteReader();
                DDl_Estado.DataBind();
                conn.Close();
        }

        public void setDDLPlantaCatalogo()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idPlantaCatalogo, Nombre from PlantaCatalogo order by Nombre asc";
            SqlCommand cmd = new SqlCommand(query, conn);
            DDL_PlantaCatalogo.DataSource = cmd.ExecuteReader();
            DDL_PlantaCatalogo.DataBind();
            conn.Close();
        }
        public void setDDLValor()
        {
            for (int i = 50; i <= 3000; i+=50)
            {
                DDl_Valor.Items.Add(i.ToString());
            }
        }

        public void setDDlAño()
        {
            for (int i = DateTime.Now.Year; i >= 1980; i--)
            {
                DDL_AñoPlantacion.Items.Add(i.ToString());
            }
        }

        public void setDDlCiudad(int estado)
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select Municipio.NombreMunicipio, Municipio.idMunicipio from EstadoCiudad inner join Municipio on (Municipio.idMunicipio = EstadoCiudad.idMunicipio) where idEstado = @idEstado  order by Municipio.NombreMunicipio asc";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idEstado", estado);
            DDL_Ciudad.DataSource = cmd.ExecuteReader();
            DDL_Ciudad.DataBind();
            conn.Close();
        }

        protected void DDl_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDDlCiudad(Convert.ToInt32 (DDl_Estado.SelectedValue));
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Planta Agregada Exitosamente!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}