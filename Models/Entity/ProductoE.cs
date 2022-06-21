using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class ProductoE
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public int TipoPoducto { get; set; }
        public string Codigo { get; set; }
        public int IdAccionFarmacologica { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdPresentacion { get; set; }

        public string AccionFarmacologica { get; set; }
        public string Laboratorio { get; set; }
        public string Presentacion { get; set; }
        public string UnidadMedida { get; set; }

        public int TipoEdad { get; set; }
        public int ControlMinsa { get; set; }
        public int Estado { get; set; }
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadMinima { get; set; }

     
    }
}