using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SFI_Farmacia_Jully.Models.Entity;

namespace SFI_Farmacia_Jully.Models.Action
{
    public static class UsuarioA
    {
        public static UsuarioE Get(string name)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            UsuarioE u = new UsuarioE();
            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("name", name)
            };
            //cadena de la consulta
            string sql = "SELECT TOP 1 * FROM TblCatEmpleado WHERE Usuario like @name";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.Text, Conexion);

            if (dt.Rows.Count > 0)
            {
                u.Id = Convert.ToInt32(dt.Rows[0]["IdEmpleado"].ToString());
                u.Usuario = dt.Rows[0]["Usuario"].ToString();
                u.Contraseña = dt.Rows[0]["Contraseña"].ToString();
                u.Cargo = int.Parse(dt.Rows[0]["IdRol"].ToString());
            }

            return u;
        }

        public static bool Insert(string nombres, string apellidos, string usuario, string contraseña, string cargo, string clave)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("Nombres", nombres),
                new SqlParameter("Apellidos", apellidos),
                new SqlParameter("Usuario", usuario),
                new SqlParameter("Contraseña", contraseña),
                new SqlParameter("Rol", int.Parse(cargo)),
                new SqlParameter("Clave",clave)
            };

            //cadena de la consulta
            string sql = "insert TblCatUsuario(Nombres, Apellidos, FechaIngreso, Usuario, Contraseña,IdRol,ClaveRec)" +
                "values(@Nombres,@Apellidos,GETDATE(),@Usuario,@Contraseña,@Rol,@Clave)";

            
            if (Data.Data.QueryInsert(sql, parametros, CommandType.Text, Conexion) > 0)
            {
                return true;
            }


            return false;
        }
    }
}