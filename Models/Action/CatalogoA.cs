using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class CatalogoA
    {
        public static List<LaboratorioE> ListarLab()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Catalogos";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Lab = new List<LaboratorioE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    LaboratorioE l = new LaboratorioE()
                    {
                        IdLaboratorio = Convert.ToInt32(dt.Rows[i]["IdLaboratorio"].ToString()),
                        Laboratorio = dt.Rows[i]["Laboratorio"].ToString()
                    };

                    Lab.Add(l);
                }

            }

            return Lab;

        }

        public static List<AccionFarmacologicaE> ListarAccionFarm()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2)
            };

            //cadena de la consulta
            string sql = "SP_Catalogos";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var AF = new List<AccionFarmacologicaE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    AccionFarmacologicaE a = new AccionFarmacologicaE()
                    {
                        IdAccionFarmacologica = Convert.ToInt32(dt.Rows[i]["IdAccionFarmacologica"].ToString()),
                        AccionFarmacologica = dt.Rows[i]["AccionFarmacologica"].ToString(),

                    };

                    AF.Add(a);
                }

            }

            return AF;

        }

        public static List<PresentacionE> ListarPresentacion()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 3)
            };
            //cadena de la consulta
            string sql = "SP_Catalogos";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Presentacion = new List<PresentacionE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    PresentacionE p = new PresentacionE()
                    {
                        IdPresentacion = Convert.ToInt32(dt.Rows[i]["IdPresentacion"].ToString()),
                        Presentacion = dt.Rows[i]["Presentacion"].ToString(),
                    };

                    Presentacion.Add(p);
                }
            }

            return Presentacion;

        }

        public static List<RolE> ListarRol()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 6)
            };
            //cadena de la consulta
            string sql = "SP_Catalogos";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var Rol = new List<RolE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    RolE r = new RolE()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["IdRol"].ToString()),
                        Rol = dt.Rows[i]["DescripcionRol"].ToString(),
                    };

                    Rol.Add(r);
                }
            }

            return Rol;

        }
    }
}