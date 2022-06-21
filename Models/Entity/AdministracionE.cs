using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class AdministracionE
    {
        public int IdPersona { get; set; }
        public string PNombre { get; set; }
        public string Snombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Celular { get; set; }
        public DateTime FechaIngreso { get; set; }
        public  int IdEmpleado{ get; set; }
        public int IdRol{ get; set; }
        public int Estado{ get; set; }
        public string  Usuario{ get; set; }
        public string Contraseña{ get; set; }
        public string ClaveRec{ get; set; }
        public string Rol { get; set; }
    }
}