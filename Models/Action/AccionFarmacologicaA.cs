using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class AccionFarmacologicaA
    {

        public static List<AccionFarmacologicaE> Listar()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Accion";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Accion = new List<AccionFarmacologicaE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    AccionFarmacologicaE p = new AccionFarmacologicaE()
                    {
                        IdAccionFarmacologica = Convert.ToInt32(dt.Rows[i]["Codigo Accion Farmacologica"].ToString()),
                        AccionFarmacologica = dt.Rows[i]["Accion Farmacologica"].ToString(),
                        Descripcion = dt.Rows[i]["Descripcion"].ToString()

                    };

                    Accion.Add(p);
                }

            }

            return Accion;

        }

        public static bool Insert(AccionFarmacologicaE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@AccionFarmacologica", p.AccionFarmacologica),
                new SqlParameter("@Descripcion", p.Descripcion),

            };
            //cadena de la consulta
            string sql = "SP_Accion";

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