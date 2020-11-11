using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantAppSE
{
    public partial class PlantaCat
    {
        public int idPlantaCatalogo { get; set; }
        public int idUbicacion { get; set; }
        public int idEstadoCiudad { get; set; }
        public int AnioPlantacion { get; set; }
        public double Altura { get; set; }
        public string Donador { get; set; }
        public int ValorComercial { get; set; }
        public string UltimoRiego { get; set; }
        public string SiguienteRiego { get; set; }
        public string UltimaPoda { get; set; }
        public string ProximaFertilizacion { get; set; }
        public string ImagenUrl { get; set; }

    }
}