using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class VentaE
    {
        public  int NoFactura { get; set; }
        public int IdCliente { get; set; }
        public int TipoPago { get; set; }
        
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }

        //detalle venta
        public string Codigo { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string FormaPago { get; set; }
    }
}