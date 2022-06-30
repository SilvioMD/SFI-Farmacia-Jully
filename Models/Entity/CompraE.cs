using System;

namespace SFI_Farmacia_Jully.Models.Entity
{
    public class CompraE
    {

        //compra
        public string NoFactura { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        //detalle de compras
        public int IdMedicamento { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Precio { get; set; }
        public string FechaVenc { get; set; }
        //extras
        public string Proveedor { get; set; }
    }
}