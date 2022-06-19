using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class CompraA
    {

        public static bool InsertCompra(decimal Total, string NoFactura, int Proveedor)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                   new SqlParameter("@IdProveedor",Proveedor),
                   new SqlParameter("@NoFacturaCompra",NoFactura),
                   new SqlParameter("@Descuento",1),
                   new SqlParameter("@TotalPago",Total)
            };

            //cadena de la consulta
            string sql = "SP_Compra";

            int result = Data.Data.QueryInsert(sql, parametros, CommandType.StoredProcedure, Conexion);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool InsertDetalleCompra(string NoFactura, int Proveedor, int IdProducto, DateTime Vencimiento, decimal Precio, decimal CambioPrecio,int Cantidad)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                   new SqlParameter("@IdProveedor",Proveedor),
                   new SqlParameter("@NoFacturaCompra",NoFactura),
                   new SqlParameter("@IdDetalleProducto",IdProducto),
                   new SqlParameter("@FechaVencimientoProducto",Vencimiento),
                   new SqlParameter("@CantidadCompra",Cantidad),
                   new SqlParameter("@PrecioCompra",Precio),
                   new SqlParameter("@Precio",CambioPrecio)
            };

            //cadena de la consulta
            string sql = "SP_DetalleCompra";

            int result = Data.Data.QueryInsert(sql, parametros, CommandType.StoredProcedure, Conexion);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}