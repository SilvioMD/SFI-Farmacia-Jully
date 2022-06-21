using System;
using System.Collections.Generic;
using SFI_Farmacia_Jully.Models.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class AdministracionA
    {
        public static List<AdministracionE> Listar()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Usuario";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var usuario = new List<AdministracionE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    AdministracionE p = new AdministracionE()
                    {
                        IdEmpleado = Convert.ToInt32(dt.Rows[i]["Codigo Empleado"].ToString()),
                        PNombre = dt.Rows[i]["P.Nombre"].ToString(),
                        Snombre = dt.Rows[i]["S.Nombre"].ToString(),
                        PApellido = dt.Rows[i]["P.Apellido"].ToString(),
                        SApellido = dt.Rows[i]["S.Apellido"].ToString(),
                        Celular = dt.Rows[i]["celular"].ToString(),
                        Usuario = dt.Rows[i]["Usuario"].ToString(),
                        Contraseña = dt.Rows[i]["Contraseña"].ToString(),
                        ClaveRec = dt.Rows[i]["Clave de Recuperacion"].ToString(),
                        Rol = dt.Rows[i]["Rol"].ToString()

                    };

                    usuario.Add(p);
                }

            }

            return usuario;

        }

        public static bool Insert(AdministracionE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@IdEmpleado", p.IdPersona),
                new SqlParameter("@PNombre", p.PNombre),
                new SqlParameter("@SNombre", p.Snombre),
                new SqlParameter("@PApellido", p.PApellido),
                new SqlParameter("@SApellido", p.SApellido),
                new SqlParameter("@Celular", p.Celular),
                new SqlParameter("@Usuario", p.Usuario),
                new SqlParameter("@Contraseña", p.Contraseña),
                new SqlParameter("@ClaveRec", p.ClaveRec),
                new SqlParameter("@IdRol", p.IdRol),

            };
            //cadena de la consulta
            string sql = "SP_Usuario";

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

        public static bool Baja(string IdEmpleado)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 3),
                new SqlParameter("@IdEmpleado", int.Parse(IdEmpleado))

            };

            //cadena de la consulta
            string sql = "SP_Usuario";

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