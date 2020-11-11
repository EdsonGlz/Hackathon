using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantAppSE
{
    public class Planta
    {
        public int idPlanta { get; set; }
        public int idUbicacion { get; set; }
        public string Ubicacion { get; set; }
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public string Clasificacion { get; set; }
        public DateTime UltimoRiego { get; set; }
        public DateTime SiguienteRiego { get; set; }
        public DateTime UltimaPoda { get; set; }
        public DateTime ProximaFertilizacion { get; set; }
        public string ImagenUrl { get; set; }








    }
}