using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantAppSE
{
    public class BitRiego
    {
        public int idBitacoraRiego { get; set; }
        public int idPlanta { get; set; }
        public DateTime FechaHora { get; set; }
        public double LitrosAgua { get; set;}
    }
}