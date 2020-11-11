using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantAppSE
{
    public class Historia
    {
        public int idHistoria { get; set; }
        public int idPlanta { get; set; }
        public int AnioPlantacion { get; set; }
        public int Edad { get; set; }
        public double AlturaCentimetros { get; set; }
        public string Donador { get; set; }
        public string LugarOrigen { get; set; }
        public double valorComercial { get; set;  }


        public int getEdad(int plantacion)
        {
            int year = DateTime.Now.Year;
            return year-AnioPlantacion;
        }

    }
}