using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class ClienteE
    {
        //datso de la tabla persona
        public int IdCliente { get; set; }
        public string Direccion { get; set; }
        public int IdPersona { get; set; }
        public string PNombre { get; set; }
        public string Snombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public int Sexo { get; set; }
        public string Celular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
    }
}