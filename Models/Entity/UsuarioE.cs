using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class UsuarioE
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Clave { get; set; }
        public int Cargo
        {
            get; set;
        }
    }
}