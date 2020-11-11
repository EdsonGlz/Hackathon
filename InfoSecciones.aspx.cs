using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;


namespace PlantAppSE
{
    public partial class InfoSecciones : System.Web.UI.Page
    {
        public int IDSeccion { get; set; }
        public string nombreSeccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string helper = Request.QueryString["seccion"];
            IDSeccion = Convert.ToInt32(helper);
            FillDGV();
            if (GVPlantasxSeccion.Rows.Count < 1)
            {
                titulo.InnerText = "Aun no hay arboles en la seccion "+IDSeccion;
            }
            else
            {
                nombreSeccion = getnombreSeccion();
                titulo.InnerText = nombreSeccion;
            }
        }



        public void FillDGV()
        {
            try
            {
                SqlConnection conn = DBConn.DBConn.connect();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select idPlanta, PlantaCatalogo.Nombre, Ubicacion.NombreSector, AnioPlatancion, ImagenUrl from Planta inner join PlantaCatalogo on PlantaCatalogo.idPlantaCatalogo = Planta.idPlantaCatalogo inner join Ubicacion on Ubicacion.idUbicacion = Planta.idUbicacion where Planta.idUbicacion = " + IDSeccion + ";", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GVPlantasxSeccion.DataSource = dtbl;
                GVPlantasxSeccion.DataBind();
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Valio Kbeza\n" + e.ToString());
            }
        }

        public string getnombreSeccion()
        {
            try
            {
                string nombre = "";
                SqlConnection conn = DBConn.DBConn.connect();
                string query = ("select Ubicacion.NombreSector from Ubicacion where idUbicacion  = @id");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", IDSeccion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nombre = reader[0].ToString();
                }
                return nombre;
            }
            catch (SqlException e)
            {
                return e.ToString();
            }
        }

        protected void GVPlantasxSeccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVPlantasxSeccion.PageIndex = e.NewPageIndex;
            GVPlantasxSeccion.DataBind();
            SqlConnection conn = DBConn.DBConn.connect();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select idPlanta, PlantaCatalogo.Nombre, Ubicacion.NombreSector, AnioPlatancion, ImagenUrl from Planta inner join PlantaCatalogo on PlantaCatalogo.idPlantaCatalogo = Planta.idPlantaCatalogo inner join Ubicacion on Ubicacion.idUbicacion = Planta.idUbicacion where Planta.idUbicacion = " + IDSeccion + ";", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GVPlantasxSeccion.DataSource = dtbl;
            GVPlantasxSeccion.DataBind();
            conn.Close();


        }

    }
}