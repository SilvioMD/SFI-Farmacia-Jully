using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace SFI_Farmacia_Jully.Models.Action
{
    public class ReportesA
    {
        public static List<CompraE> ReporteGeneralCompras(DateTime Inicio, DateTime Fin)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 11),
                new SqlParameter("@Inicio", Inicio),
                new SqlParameter("@Fin", Fin)
            };

            //cadena de la consulta
            string sql = "SP_ReportesCompras_ventas";

            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Compras = new List<CompraE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    CompraE p = new CompraE()
                    {

                        NoFactura = dt.Rows[i]["NoFactura"].ToString(),
                        Proveedor = dt.Rows[i]["Proveedor"].ToString(),
                        Total = Convert.ToDecimal(dt.Rows[i]["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString())

                    };

                    Compras.Add(p);
                }


            }

            return Compras;

        }

        public static List<CompraE> MostrarCompras()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 111)
            };

            //cadena de la consulta
            string sql = "SP_ReportesCompras_ventas";

            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Compras = new List<CompraE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    CompraE p = new CompraE()
                    {

                        NoFactura = dt.Rows[i]["NoFactura"].ToString(),
                        Proveedor = dt.Rows[i]["Proveedor"].ToString(),
                        Total = Convert.ToDecimal(dt.Rows[i]["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString())

                    };

                    Compras.Add(p);
                }


            }

            return Compras;

        }


        public static DataTable ReporteGeneralVentas(DateTime Inicio, DateTime Fin)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 22),
                new SqlParameter("@Inicio", Inicio),
                new SqlParameter("@Fin", Fin)
            };

            //cadena de la consulta
            string sql = "SP_ReportesCompras_ventas";

            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            dt.TableName = "Ventas";

            return dt;

        }


        public static List<VentaE> MostrarVentas()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 222)
            };

            //cadena de la consulta
            string sql = "SP_ReportesCompras_ventas";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Ventas = new List<VentaE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    VentaE p = new VentaE()
                    {
                        NoFactura = Convert.ToInt32(dt.Rows[i]["NoFactura"].ToString()),
                        FormaPago = dt.Rows[i]["Forma de Pago"].ToString(),
                        Total = Convert.ToDecimal(dt.Rows[i]["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString())

                    };

                    Ventas.Add(p);
                }


            }

            return Ventas;

        }

    }
}