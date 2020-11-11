using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using PlantAppSE.DBConn;
using PlantAppSE;
using System.Globalization;

namespace PlantAppSE
{
    public partial class _Default : Page
    {
        public static string FutureEvent { get; set; }
        public int idEstadoCiudad { get; set; }
        public int idPlanta { get; set; }
        public string nombre { get; set; }
        public string imagenUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            string helper = Request.QueryString["id"];
            idPlanta = Convert.ToInt32(helper);
            getidEstadoCiudad();
            if (!IsPostBack)
            {
                setParamsPlanta();
            }
            Session["prevUrl"] = Request.Url;
            if (Session["User_ID"] != null)
            {
                lbl_User.Text = " | " +Session["User_ID"].ToString();
                Agregar_Button.Visible = true;
                toolbox.Visible = true;
                Img_ProximaFertilizacion.Visible = true;
                Img_SiguienteRiego.Visible = true;
                Editar_Button.Visible = true;
            }
            else
            {
                lbl_User.Text = " | " + "Guest";
                Agregar_Button.Visible = false;
                Img_ProximaFertilizacion.Visible = false;
                Img_SiguienteRiego.Visible = false;
                Editar_Button.Visible = false;
            }
        }

        public void getidEstadoCiudad()
        {
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select idEstadoCiudad from Planta where idPlanta = @id;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idPlanta);
            SqlDataReader reader = cmd.ExecuteReader();
            Planta p = new Planta();
            while (reader.Read())
            {
                idEstadoCiudad = Convert.ToInt32(reader[0].ToString());
            }
        }
        public void setParamsPlanta()
        {
            makelbl_visible();
            DateTime helper;
            try
            { 
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select PlantaCatalogo.Nombre, PlantaCatalogo.NombreCientifico, PlantaCatalogo.Clasificacion, Ubicacion.NombreSector, Planta.UltimoRiego, Planta.SiguienteRiego, Planta.UltimaPoda, Planta.ProximaFertilizacion, Planta.ImagenUrl from Planta inner join PlantaCatalogo on ( PlantaCatalogo.idPlantaCatalogo = Planta.idPlantaCatalogo) inner join Ubicacion on ( Ubicacion.idUbicacion = Planta.idUbicacion) where idPlanta = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPlanta);
                SqlDataReader reader = cmd.ExecuteReader();
                Planta p = new Planta();
                while (reader.Read())
                {
                    p.Nombre = reader[0].ToString();
                    p.NombreCientifico = reader[1].ToString();
                    p.Clasificacion = reader[2].ToString();
                    p.Ubicacion = reader[3].ToString();
                    if (DateTime.TryParse(reader[4].ToString(), out helper) && helper != DateTime.Parse("01/01/1900 12:00:00 am"))
                    {
                        p.UltimoRiego = Convert.ToDateTime(reader[4]);
                        Valor4.Text = p.UltimoRiego.ToString();
                    }
                    else
                    {
                        Valor4.Text = "No hay informacion disponible del Ultimo Riego AÚN";
                    }

                    if (DateTime.TryParse(reader[5].ToString(), out helper) && helper != DateTime.Parse("01/01/1900 12:00:00 am"))
                    {
                        p.SiguienteRiego = Convert.ToDateTime(reader[5]);
                        Valor5.Text = p.SiguienteRiego.ToString();
                    }
                    else
                    {
                        Valor5.Text = "No hay informacion disponible del Siguiente Riego AÚN";
                    }

                    if (DateTime.TryParse(reader[6].ToString(), out helper) && helper != DateTime.Parse("01/01/1900 12:00:00 am"))
                    {
                        p.UltimaPoda = Convert.ToDateTime(reader[6]);
                        Valor6.Text = p.UltimaPoda.ToString();
                    }
                    else
                    {
                        Valor6.Text = "No hay informacion disponible de la Ultima Poda AÚN";
                    }
                    if (DateTime.TryParse(reader[7].ToString(), out helper) && helper != DateTime.Parse("01/01/1900 12:00:00 am"))
                    {
                        p.ProximaFertilizacion = Convert.ToDateTime(reader[7]);
                        Valor7.Text = p.ProximaFertilizacion.ToString();
                    }
                    else
                    {
                        Valor7.Text = "No hay informacion disponible de la Proxima Fertilizacion AÚN";
                    }
                    if (reader[8].ToString() != "")
                    {
                        p.ImagenUrl = reader[8].ToString();
                    }
                    else
                    {
                        p.ImagenUrl = "https://st.depositphotos.com/1169502/2025/v/450/depositphotos_20257115-stock-illustration-abstract-eco-green-plant-with.jpg";
                    }
                    
                }

                nombre = p.Nombre;
                imagenUrl = p.ImagenUrl;
                NombrePlanta.Text = "Planta #" + idPlanta + " | " + p.Nombre;
                Valor1.Text = p.NombreCientifico;
                Valor2.Text = p.Clasificacion;
                ImagenPlanta.Attributes["src"] = p.ImagenUrl;
                Valor3.Text = p.Ubicacion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void ImageHistoria_Click(object sender, ImageClickEventArgs e)
        {
            makelbl_visible();
            ImagenPlanta.Visible = true;
            Img_ProximaFertilizacion.Visible = false;
            GVBitacoraCosecha.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            GVBitacoraPoda.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacoraSupervision.Visible = false;
            try
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "select Planta.AnioPlatancion, Planta.AlturaCentimetros, Planta.Donador, Planta.ValorComercial  from Planta where idPlanta = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", idPlanta);
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                Historia h = new Historia();
                while (reader.Read())
                {
                    h.AnioPlantacion = Convert.ToInt32(reader[0]);
                    h.Edad = h.getEdad(h.AnioPlantacion);
                    h.AlturaCentimetros = Convert.ToDouble(reader[1]);
                    h.Donador = reader[2].ToString();
                    h.LugarOrigen = getLugarOrigen();
                    h.valorComercial = Convert.ToDouble(reader[3]);
                }
                NombrePlanta.Text = "Planta #" + idPlanta + " | " + nombre;
                Propiedad1.Text = "Año de Plantacion: ";
                Valor1.Text = h.AnioPlantacion.ToString();
                Propiedad2.Text = "Edad :";
                Valor2.Text = h.Edad.ToString() + " años ";
                ImagenPlanta.Attributes["src"] = imagenUrl;
                Propiedad3.Text = "Altura: ";
                Valor3.Text = h.AlturaCentimetros.ToString() + " cm. ";
                Propiedad4.Text = "Donado por: ";
                Valor4.Text = h.Donador;
                Propiedad5.Text = "Lugar de Origen: ";
                Valor5.Text = h.LugarOrigen;
                Propiedad6.Text = "Valor Comercial";
                Valor6.Text = h.valorComercial.ToString() + " $ ";
                Propiedad7.Visible = false;
                Valor7.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public void ImageBitacoraRiego_Click(object sender, ImageClickEventArgs e)
        {

            makelbl_invisible();
            ImagenPlanta.Visible = true;
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            GVBitacoraCosecha.Visible = false;
            GVBitacoraPoda.Visible = false;
            GVBitacoraRiego.Visible = true;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            ImagenPlanta.Visible = true;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from BitacoraRiego where BitacoraRiego.idPlanta = " +idPlanta+ " order by FechaHora desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraRiego.DataSource = dtbl;
            GVBitacoraRiego.DataBind();
        }

        public void ImageBitacoraFumigacion_Click(object sender, ImageClickEventArgs e)
        {
            makelbl_invisible();
            ImagenPlanta.Visible = true;
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            GVBitacoraPoda.Visible = false;
            GVBitacoraCosecha.Visible = false;
            Calendario.Visible = false;
            ImagenPlanta.Visible = true;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = true;
            GVBitacoraSupervision.Visible = false; ;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Motivo.MotivoDescripcion, Quimico.Nombre, BitacoraFumigacion.Fecha from BitacoraFumigacion inner join Motivo on Motivo.idMotivo = BitacoraFumigacion.idMotivo inner join Quimico on Quimico.idQuimico=BitacoraFumigacion.idQuimico where idPlanta = " + idPlanta + " order by Fecha desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacorFumigacion.DataSource = dtbl;
            GVBitacorFumigacion.DataBind();
        }

        public void ImageBitacoraSupervision_Click(object sender, ImageClickEventArgs e)
        {

            makelbl_invisible();
            ImagenPlanta.Visible = true;
            GVBitacoraPoda.Visible = false;
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacoraCosecha.Visible = false;
            Calendario.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = true;
            ImagenPlanta.Visible = true;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select EstadoTronco.EstadoTronco, EstadoHojas.EstadoHojas, EstadoRamas.EstadoRamas, BitacoraSupervision.Fecha, BitacoraSupervision.Observaciones from BitacoraSupervision inner join EstadoTronco on BitacoraSupervision.idEstadoTronco = EstadoTronco.idEstadoTronco inner join EstadoHojas on BitacoraSupervision.idEstadoHojas = EstadoHojas.idEstadoHojas inner join EstadoRamas on BitacoraSupervision.idEstadoRamas = EstadoRamas.idEstadoRamas  where BitacoraSupervision.idPlanta = " + idPlanta + " order by Fecha desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraSupervision.DataSource = dtbl;
            GVBitacoraSupervision.DataBind();
        }

        public string getLugarOrigen()
        {
            string LugarOrigen = "";
            SqlConnection conn = DBConn.DBConn.connect();
            string query = "select Estado.EstadoNombre, Municipio.NombreMunicipio from EstadoCiudad inner join Estado on (Estado.idEstado = EstadoCiudad.idEstado) inner join Municipio on (Municipio.idMunicipio = EstadoCiudad.idMunicipio) where idEstadoCiudad = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", idEstadoCiudad);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LugarOrigen = LugarOrigen + reader[1] + ", " + reader[0];
            }

            return LugarOrigen;

        }


        public void makelbl_invisible()
        {
            NombrePlanta.Visible = false;
            Propiedad1.Visible = false;
            Valor1.Visible = false;
            Propiedad2.Visible = false;
            Valor2.Visible = false;
            Propiedad3.Visible = false;
            Valor3.Visible = false;
            Propiedad4.Visible = false;
            Valor4.Visible = false;
            Propiedad5.Visible = false;
            Valor5.Visible = false;
            Propiedad6.Visible = false;
            Valor6.Visible = false;
            Propiedad7.Visible = false;
            Valor7.Visible = false;
        }

        public void makelbl_visible()
        {
            NombrePlanta.Visible = true;
            Propiedad1.Visible = true; ;
            Valor1.Visible = true;
            Propiedad2.Visible = true;
            Valor2.Visible = true;
            Propiedad3.Visible = true;
            Valor3.Visible = true;
            Propiedad4.Visible = true;
            Valor4.Visible = true;
            Propiedad5.Visible = true;
            Valor5.Visible = true;
            Propiedad6.Visible = true;
            Valor6.Visible = true;
            Propiedad7.Visible = true;
            Valor7.Visible = true;
        }

        public bool SignedIn()
        {
            if (nombre != null)
            {
                return true;
            }
            return false;
        }

        protected void ImagenPoda_Click(object sender, ImageClickEventArgs e)
        {
            GVBitacoraPoda.Visible = true;
            ImagenPlanta.Visible = true;
            GVBitacoraCosecha.Visible = false;
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            makelbl_invisible();
            Calendario.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            ImagenPlanta.Visible = true;
            try
            {
                SqlConnection conn = DBConn.DBConn.connect();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select C_Super, C_Extra, C_Primera, C_Mediano, C_Comercial, Fecha  where idPlanta = " + idPlanta + "order by Fecha desc; ", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GVBitacoraPoda.DataSource = dtbl;
                GVBitacoraPoda.DataBind();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Fallo");
            }
            

        }

        protected void ImagenCosecha_Click(object sender, ImageClickEventArgs e)
        {
            GVBitacoraCosecha.Visible = true;
            GVBitacoraPoda.Visible = false;
            ImagenPlanta.Visible = true;
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            makelbl_invisible();
            Calendario.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            ImagenPlanta.Visible = true;

            try
            {
                SqlConnection conn = DBConn.DBConn.connect();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select C_Super, C_Extra,C_Primera, C_Mediano, C_Comercial, Fecha from BitacoraCosecha where idPlanta = " + idPlanta + " order by Fecha desc;", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GVBitacoraCosecha.DataSource = dtbl;
                GVBitacoraCosecha.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fallo");
            }


        }

        protected void GVBitacoraRiego_PageIndexChanged1(object sender, GridViewPageEventArgs e)
        {
            GVBitacoraRiego.PageIndex = e.NewPageIndex;
            GVBitacoraRiego.DataBind();
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            makelbl_invisible();
            GVBitacoraPoda.Visible = false;
            GVBitacoraRiego.Visible = true;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            GVBitacoraCosecha.Visible = false;
            ImagenPlanta.Visible = true;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from BitacoraRiego where BitacoraRiego.idPlanta = " + idPlanta + " order by BitacoraRiego.FechaHora desc; ", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraRiego.DataSource = dtbl;
            GVBitacoraRiego.DataBind();
            conn.Close();
        }

        protected void GVBitacorFumigacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVBitacorFumigacion.PageIndex = e.NewPageIndex;
            GVBitacorFumigacion.DataBind();

            makelbl_invisible();
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            GVBitacoraPoda.Visible = false;
            ImagenPlanta.Visible = true;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = true;
            GVBitacoraSupervision.Visible = false;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select Motivo.MotivoDescripcion, Quimico.Nombre, BitacoraFumigacion.Fecha from BitacoraFumigacion inner join Motivo on Motivo.idMotivo = BitacoraFumigacion.idMotivo inner join Quimico on Quimico.idQuimico=BitacoraFumigacion.idQuimico where idBitacoraFumigacion = " + idPlanta + " order by BitacoraFumigacion.Fecha desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacorFumigacion.DataSource = dtbl;
            GVBitacorFumigacion.DataBind();
        }

        protected void GVBitacoraSupervision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVBitacoraSupervision.PageIndex = e.NewPageIndex;
            GVBitacoraSupervision.DataBind();
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            makelbl_invisible();
            GVBitacoraPoda.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = true;
            ImagenPlanta.Visible = true;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select EstadoTronco.EstadoTronco, EstadoHojas.EstadoHojas, EstadoRamas.EstadoRamas, BitacoraSupervision.Fecha, BitacoraSupervision.Observaciones from BitacoraSupervision inner join EstadoTronco on BitacoraSupervision.idEstadoTronco = EstadoTronco.idEstadoTronco inner join EstadoHojas on BitacoraSupervision.idEstadoHojas = EstadoHojas.idEstadoHojas inner join EstadoRamas on BitacoraSupervision.idEstadoRamas = EstadoRamas.idEstadoRamas  where BitacoraSupervision.idPlanta = " + idPlanta + "order by Fecha desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraSupervision.DataSource = dtbl;
            GVBitacoraSupervision.DataBind();
        }

        protected void GVBitacoraPoda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVBitacoraPoda.PageIndex = e.NewPageIndex;
            GVBitacoraPoda.DataBind();
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            GVBitacoraPoda.Visible = true;
            makelbl_invisible();
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            ImagenPlanta.Visible = true;

            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select FechaHora, ImagenPodaUrl from BitacoraPoda where idPlanta = " + idPlanta + " order by FechaHora desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraPoda.DataSource = dtbl;
            GVBitacoraPoda.DataBind();
        }


        protected void AgregarRiego_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AgregarRiego.aspx?id=" + idPlanta);
        }

        protected void AgregarPoda_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AgregarPoda.aspx?id=" + idPlanta);
        }

        protected void AgregarSupervision_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AgregarSupervision.aspx?id=" + idPlanta);
        }

        protected void AgregarFumigacion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AgregarFumigacion.aspx?id=" + idPlanta);
        }

        public void populate_DDLs()
        {

            DDl_Year.Items.Add(DateTime.Now.Year.ToString());
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length; i++)
            {
                DDl_Months.Items.Add(new ListItem(months[i].ToUpper(), (i+1).ToString()));
            }
            ListItem removeItem = DDl_Months.Items.FindByText("");
            DDl_Months.Items.Remove(removeItem);

            for (int i = 0; i <= 23; i++)
            {
                if (i.ToString().Length < 2)
                {
                    DDl_Horas.Items.Add(new ListItem("0" + i.ToString(), i.ToString()));
                }
                else
                {
                    DDl_Horas.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                
            }

            for (int i = 0; i <= 59; i++)
            {
                if (i.ToString().Length < 2)
                {
                    DDl_Minutos.Items.Add(new ListItem("0"+i.ToString(), i.ToString()));
                }
                else
                {
                    DDl_Minutos.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                
            }

            Populate_days();
        }


        public void Populate_days()
        {
            DDl_Days.Items.Clear();
            if (Convert.ToInt32(DDl_Months.SelectedValue) <= 7)
            {
                if (Convert.ToInt32(DDl_Months.SelectedValue) == 2)
                {
                    if (DateTime.Now.Year % 4 == 0)
                    {
                        for (int i = 1; i <= 29; i++)
                        {
                            DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i );
                            string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                            DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 28; i++)
                        {
                            DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i);
                            string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                            DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                        }
                    }
                }

                else if (Convert.ToInt32(DDl_Months.SelectedValue) % 2 == 0)
                {
                    for (int i = 1; i <= 30; i++)
                    {
                        DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i);
                        string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                        DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    for (int i = 1; i <= 31; i++)
                    {
                        DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i);
                        string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                        DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                    }
                }
            }
            else
            {
                if (Convert.ToInt32(DDl_Months.SelectedValue) % 2 == 0)
                {
                    for (int i = 1; i <= 31; i++)
                    {
                        DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i);
                        string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                        DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    for (int i = 1; i <= 30; i++)
                    {
                        DateTime dateValue = new DateTime(Convert.ToInt32(DDl_Year.SelectedValue), Convert.ToInt32(DDl_Months.SelectedValue), i);
                        string name = dateValue.ToString("dddd", new CultureInfo("es-ES"));
                        DDl_Days.Items.Add(new ListItem(name.ToUpper() + " " + i.ToString(), i.ToString()));
                    }
                }
            }
        }

        protected void AddFutureEvents(object sender, ImageClickEventArgs e)
        {
            populate_DDLs();
            DDl_Months.SelectedValue = DateTime.Now.Month.ToString();
            DDl_Horas.SelectedValue = DateTime.Now.Hour.ToString();
            DDl_Minutos.SelectedValue = DateTime.Now.Minute.ToString();
            Populate_days();
            DDl_Days.SelectedValue = DateTime.Now.Day.ToString();
            Calendario.Visible = true;

            HttpCookie futureevent = new HttpCookie("futureevent");

            if (((ImageButton)sender).ID.ToString() == "Img_SiguienteRiego")
            {
                futureevent.Value = "Img_SiguienteRiego";
                futureevent.Expires = DateTime.Now.AddYears(50);

                Response.Cookies.Add(futureevent);
            }
            else if (((ImageButton)sender).ID.ToString() == "Img_ProximaFertilizacion")
            {
                futureevent.Value = "Img_ProximaFertilizacion";
                futureevent.Expires = DateTime.Now.AddYears(50);

                Response.Cookies.Add(futureevent);
            }

        }

        public string converttoDate()
        {

            string hour = DDl_Horas.SelectedValue.ToString();
            string minute = DDl_Minutos.SelectedValue.ToString();

            string year = DDl_Year.SelectedValue.ToString();
            string month = DDl_Months.SelectedValue.ToString();
            string day = DDl_Days.SelectedValue.ToString();




            string date = day + "/" + month + "/" + year + " " + hour + ":" + minute ;

            return date;
        }

        protected void btn_CalendarioListo_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["futureevent"];
            if (myCookie.Value.ToString() == "Img_SiguienteRiego")
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "update Planta set SiguienteRiego = CONVERT(datetime, @fecha, 103) where idPlanta = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = converttoDate();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPlanta;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else if (myCookie.Value.ToString() == "Img_ProximaFertilizacion")
            {
                SqlConnection conn = DBConn.DBConn.connect();
                string query = "update Planta set ProximaFertilizacion = CONVERT(datetime, @fecha, 103) where idPlanta = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = converttoDate();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPlanta;
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void AgregarPlantaCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlantaCatalogo.aspx?id=" + idPlanta);
        }

        protected void Editar_Button_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/ModifyTree.aspx?id=" + idPlanta);
        }

        protected void AgregarCosecha_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/AgregarCosecha.aspx?id=" + idPlanta);
        }

        protected void GVBitacoraCosecha_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVBitacoraCosecha.PageIndex = e.NewPageIndex;
            GVBitacoraSupervision.DataBind();
            Img_ProximaFertilizacion.Visible = false;
            Img_SiguienteRiego.Visible = false;
            Calendario.Visible = false;
            makelbl_invisible();
            GVBitacoraPoda.Visible = false;
            GVBitacoraRiego.Visible = false;
            GVBitacorFumigacion.Visible = false;
            GVBitacoraSupervision.Visible = false;
            GVBitacoraCosecha.Visible = true;
            ImagenPlanta.Visible = false;
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select C_Super, C_Extra, C_Primera, C_Mediano, C_Comercial, Fecha  where idPlanta = " + idPlanta + "order by Fecha desc;", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVBitacoraCosecha.DataSource = dtbl;
            GVBitacoraCosecha.DataBind();
        }
    }

}