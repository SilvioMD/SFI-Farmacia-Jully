using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class VentasA
    {
        public static bool InsertVenta(decimal Total, int TipoPago)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                   new SqlParameter("@TotalPagoVenta",Total),
                   new SqlParameter("@Descuento",1),
                   new SqlParameter("@IdCliente",1),
                   new SqlParameter("@IdUsuario",1),
                   new SqlParameter("@IdTipoPago",TipoPago)
            };

            //cadena de la consulta
            string sql = "SP_Venta";

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

        public static bool InsertDetalleVenta(decimal Precio, int Cantidad, int NoFactura, int IdMedicamento)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {

                   new SqlParameter("@NoFactura",NoFactura),
                   new SqlParameter("@IdMedicamento",IdMedicamento),
                   new SqlParameter("@Cantidad",Cantidad),
                   new SqlParameter("@Precio",Precio)
            };

            //cadena de la consulta
            string sql = "SP_DetalleVenta";

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

        public static int IdVenta()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {

            };

            //cadena de la consulta
            string sql = "SP_IdVenta";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            int NoFact = 0;

            if (dt.Rows.Count > 0)
            {

                NoFact = Convert.ToInt16(dt.Rows[0]["NoFactura"].ToString());

            }

            return NoFact;

        }
    }
}