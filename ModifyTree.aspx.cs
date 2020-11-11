using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;
using System.IO;


namespace PlantAppSE
{
    public partial class ModifyTree : System.Web.UI.Page
    {
        public int IdEstadoCiudad { get; set; }
        public int IDPlanta { get; set; }
        public string UrlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("/Login/Login.aspx");
            }
            string helper = Request.QueryString["id"];
            IDPlanta = Convert.ToInt32(helper);
            setIDEstadoCiudad();
            if (!IsPostBack)
            {
                setDDLs();
                DDl_Estado.SelectedValue = getEstado(IdEstadoCiudad).ToString();
                setDDlCiudad(Convert.ToInt32(DDl_Estado.SelectedValue));
                DDL_Ciudad.SelectedValue = getMunicipio(IdEstadoCiudad).ToString();
            }

            this.Wizard1.StartNextButtonText = "Siguiente";
            this.Wizard1.StepNextButtonText = "Siguiente";
            this.Wizard1.FinishPreviousButtonText = "Anterior";
            this.Wizard1.StepPreviousButtonText = "Anterior";
            this.Wizard1.FinishCompleteButtonText = "Terminar";

            Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setParams();
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string filename = "";

            //'10/09/2020 22:10'
            //update Planta set idPlantaCatalogo = @idPlantaCatalogo, idUbicacion = @idUbicacion, idEstadoCiudad = @idEstadoCiudad,  AnioPlatancion = @AnioPlatancion, AlturaCentimetros=@AlturaCentimetros, Donador = @Donador, ValorComercial = @ValorComercial, UltimoRiego =  @UltimoRiego, SiguienteRiego = @SiguienteRiego, UltimaPoda = @UltimaPoda, ProximaFertilizacion = @ProximaFertilizacion, ImagenUrl = @ImagenUrl where idPlanta = @idPlanta;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "";
            if (FileUploadControl.HasFile)
            {
                query = "update Planta set idPlantaCatalogo = @idPlantaCatalogo, idUbicacion = @idUbicacion, idEstadoCiudad = @idEstadoCiudad,  AnioPlatancion = @AnioPlatancion, AlturaCentimetros=@AlturaCentimetros, Donador = @Donador, ValorComercial = @ValorComercial, UltimoRiego =  @UltimoRiego, SiguienteRiego = @SiguienteRiego, UltimaPoda = @UltimaPoda, ProximaFertilizacion = @ProximaFertilizacion, ImagenUrl = @ImagenUrl where idPlanta = @idPlanta;";
            }
            else
            {
                query = "update Planta set idPlantaCatalogo = @idPlantaCatalogo, idUbicacion = @idUbicacion, idEstadoCiudad = @idEstadoCiudad,  AnioPlatancion = @AnioPlatancion, AlturaCentimetros=@AlturaCentimetros, Donador = @Donador, ValorComercial = @ValorComercial, UltimoRiego =  @UltimoRiego, SiguienteRiego = @SiguienteRiego, UltimaPoda = @UltimaPoda, ProximaFertilizacion = @ProximaFertilizacion where idPlanta = @idPlanta;";
            }


            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Parameters.AddWithValue("@idPlantaCatalogo", DDL_PlantaCatalogo.SelectedValue);
                cmd.Parameters.AddWithValue("@idUbicacion", DDL_Ubicacion.SelectedValue);
                cmd.Parameters.AddWithValue("@idEstadoCiudad", getEstadoCiudad());
                cmd.Parameters.AddWithValue("@AnioPlatancion", DDL_AnioPlantacion.SelectedValue);
                cmd.Parameters.AddWithValue("@AlturaCentimetros", tbx_Altura.Text);
                cmd.Parameters.AddWithValue("@Donador", tbx_Donador.Text);
                cmd.Parameters.AddWithValue("@ValorComercial", DDl_Valor.SelectedValue);
                if (CalCGM.tbf.Text != "")
                {
                    cmd.Parameters.AddWithValue("@UltimoRiego", CalCGM.tbf.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UltimoRiego", DBNull.Value);
                }
                if (CalCGM1.tbf.Text != "")
                {
                    cmd.Parameters.AddWithValue("@SiguienteRiego", CalCGM1.tbf.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SiguienteRiego", DBNull.Value);
                }
                if (CalCGM2.tbf.Text != "")
                {
                    cmd.Parameters.AddWithValue("@UltimaPoda", CalCGM2.tbf.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UltimaPoda", DBNull.Value);
                }
                if (CalCGM3.tbf.Text != "")
                {
                    cmd.Parameters.AddWithValue("@ProximaFertilizacion", CalCGM3.tbf.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ProximaFertilizacion", DBNull.Value);
                }
                
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        StatusLabel.Visible = true;
                        filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                        FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + cleanDate(getDate()));
                        StatusLabel.Text = "Upload status: File uploaded!";
                        cmd.Parameters.AddWithValue("@ImagenUrl", "http://fugapp.com/Uploads/" + cleanDate(getDate()));
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Visible = true;
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImagenUrl", "http://fugapp.com/Uploads/" + filename);
                }
                cmd.Parameters.AddWithValue("@idPlanta", IDPlanta);
                cmd.ExecuteNonQuery();
                conn.Close();

                lblModalTitle.Text = "¡Planta Editada exitosamente!";
                lblModalBody.ForeColor = System.Drawing.Color.Black;
                lblModalBody.Text = "La Planta fue editada correctamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            catch (SqlException ex)
            {
                lblModalTitle.Text = "¡Planta NO editada exitosamente!";
                lblModalBody.ForeColor = System.Drawing.Color.Red;
                lblModalBody.Text = "Error no se pudo editar la planta + <br />" + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            conn.Close();

        }

        public void setIDEstadoCiudad()
        {
            int id = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoCiudad from Planta where idPlanta = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", IDPlanta);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader[0].ToString());
            }
            IdEstadoCiudad = id;

            conn.Close();
        }



        public void setParams()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idPlantaCatalogo, idUbicacion, idEstadoCiudad, AnioPlatancion, Donador, ValorComercial, UltimoRiego, SiguienteRiego, UltimaPoda, ProximaFertilizacion, ImagenUrl, AlturaCentimetros from Planta where idPlanta = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", IDPlanta);
            SqlDataReader reader = cmd.ExecuteReader();
            PlantaCat p = new PlantaCat();
            while (reader.Read())
            {
                p.idPlantaCatalogo = Convert.ToInt32(reader[0].ToString());
                p.idUbicacion = Convert.ToInt32(reader[1].ToString());
                p.idEstadoCiudad = Convert.ToInt32(reader[2].ToString());
                p.AnioPlantacion = Convert.ToInt32(reader[3].ToString());
                p.Donador = reader[4].ToString();
                p.ValorComercial = Convert.ToInt32(reader[5].ToString());
                p.UltimoRiego =  reader[6].ToString();
                p.SiguienteRiego = reader[7].ToString();
                p.UltimaPoda = reader[8].ToString();
                p.ProximaFertilizacion = reader[9].ToString();
                p.ImagenUrl = reader[10].ToString();
                p.Altura = Convert.ToDouble(reader[11].ToString());
            }

            DDL_PlantaCatalogo.SelectedValue = p.idPlantaCatalogo.ToString();
            DDL_Ubicacion.SelectedValue = p.idUbicacion.ToString();
            DDl_Estado.SelectedValue = getEstado(p.idEstadoCiudad).ToString();
            DDL_Ciudad.SelectedValue = getMunicipio(p.idEstadoCiudad).ToString();
            DDL_AnioPlantacion.SelectedValue = p.AnioPlantacion.ToString();
            tbx_Altura.Text = p.Altura.ToString();
            tbx_Donador.Text = p.Donador;
            DDl_Valor.SelectedValue = p.ValorComercial.ToString();
            DDL_Ubicacion.SelectedValue = p.idUbicacion.ToString();
            CalCGM.tbf.Text = formatDates(p.UltimoRiego);
            CalCGM1.tbf.Text = formatDates(p.SiguienteRiego);
            CalCGM2.tbf.Text = formatDates(p.UltimaPoda);
            CalCGM3.tbf.Text = formatDates(p.ProximaFertilizacion);


            /*CalCGM1.tbf.Text = p.SiguienteRiego;
            CalCGM2.tbf.Text= p.UltimaPoda;*/

            conn.Close();

        }

        public string formatDates(string test)
        {
            string res = "";
            if (test != null)
            {
                if (test.Contains("p") || test.Contains("a"))
                {
                    if (test[20] == 'p')
                    {
                        test = test.Substring(0, 20);
                        test = test + "pm";
                    }
                    else
                    {
                        test = test.Substring(0, 20);
                        test = test + "am";
                    }
                    DateTime myDate = DateTime.ParseExact(test, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    res = myDate.ToString("yyyy/MM/dd HH:mm:ss");
                }
                return res;
            }
            return test;
        }

        public int getEstado(int idEstadoCiudad)
        {
            int id = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstado from EstadoCiudad where idEstadoCiudad = @id;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idEstadoCiudad);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader[0].ToString());
            }
            conn.Close();
            return id;
            
        }


        public int getMunicipio(int idEstadoCiudad)
        {
            int id = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idMunicipio from EstadoCiudad where idEstadoCiudad = @id;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idEstadoCiudad);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader[0].ToString());
            }
            conn.Close();
            return id;
        }


        public void setDDLs()
        {
            setDDLPlantaCatalogo();
            setDDLUbicacion();
            setDDLEstado();
            setDDlAño();
            setDDLValor();

        }

        public void setDDLUbicacion()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idUbicacion, NombreSector from Ubicacion";
            SqlCommand cmd = new SqlCommand(query, conn);
            DDL_Ubicacion.DataSource = cmd.ExecuteReader();
            DDL_Ubicacion.DataBind();
            conn.Close();
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
            for (int i = 50; i <= 3000; i += 50)
            {
                DDl_Valor.Items.Add(i.ToString());
            }
        }

        public void setDDlAño()
        {
            for (int i = DateTime.Now.Year; i >= 1980; i--)
            {
                DDL_AnioPlantacion.Items.Add(i.ToString());
            }
        }

        public void setDDlCiudad(int estado)
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select Municipio.NombreMunicipio, Municipio.idMunicipio from EstadoCiudad inner join Municipio on (Municipio.idMunicipio = EstadoCiudad.idMunicipio) where idEstado = @idEstado  order by Municipio.NombreMunicipio asc;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idEstado", estado);
            DDL_Ciudad.DataSource = cmd.ExecuteReader();
            DDL_Ciudad.DataBind();
            conn.Close();
        }

        protected void DDl_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDDlCiudad(Convert.ToInt32(DDl_Estado.SelectedValue));
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

        

        public int getEstadoCiudad()
        {
            int EstadoCiudad = 0;
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoCiudad from EstadoCiudad where idEstado = @idEstado and idMunicipio = @idMunicipio;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idEstado", DDl_Estado.SelectedValue);
            cmd.Parameters.AddWithValue("@idMunicipio", DDL_Ciudad.SelectedValue);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                EstadoCiudad = Convert.ToInt32(reader[0].ToString());
            }

            conn.Close();

            return EstadoCiudad;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (lblModalTitle.Text == "¡Planta Editada exitosamente!")
            {
                Response.Redirect("/Default.aspx?id=" + IDPlanta);
            }
        }
    }
}
