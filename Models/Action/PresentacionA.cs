using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class PresentacionA
    {
        public static List<PresentacionE> Listar()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Presentacion";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var presentacion = new List<PresentacionE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    PresentacionE p = new PresentacionE()
                    {
                        IdPresentacion = Convert.ToInt32(dt.Rows[i]["Codigo Presentacion"].ToString()),
                        Presentacion = dt.Rows[i]["Presentacion"].ToString(),

                    };

                    presentacion.Add(p);
                }

            }

            return presentacion;

        }

        public static bool Insert(PresentacionE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@Presentacion", p.Presentacion),

            };
            //cadena de la consulta
            string sql = "SP_Presentacion";

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