using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class DashboardA
    {
        public static string ObtenerInfo(int tipo)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", tipo)
            };
            string nambrecolumna = "(No column name)";

            if (tipo == 1)
            {
                nambrecolumna = "Ventas";
            }
            else if (tipo == 2)
            {
                nambrecolumna = "Compras";
            }
            else if (tipo == 3)
            {
                nambrecolumna = "Inventario";
            }
            //cadena de la consulta
            string sql = "SP_Dashboard";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            string resultado = "";

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    resultado = dt.Rows[i][nambrecolumna].ToString();
                }

            }

            return resultado;

        }
    }
}