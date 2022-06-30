using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class ClienteA
    {
        public static List<ClienteE> Listar()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Cliente";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var cliente = new List<ClienteE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    ClienteE p = new ClienteE()
                    {
                        IdCliente = Convert.ToInt32(dt.Rows[i]["CodigoCliente"].ToString()),
                        PNombre = dt.Rows[i]["P.Nombre"].ToString(),
                        Snombre = dt.Rows[i]["S.Nombre"].ToString(),
                        PApellido = dt.Rows[i]["P.Apellido"].ToString(),
                        SApellido = dt.Rows[i]["S.Apellido"].ToString(),
                        Celular = dt.Rows[i]["celular"].ToString(),
                        Direccion = dt.Rows[i]["Direccion"].ToString()

                    };

                    cliente.Add(p);
                }

            }

            return cliente;

        }

        public static bool Insert(ClienteE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@IdPersona", p.IdCliente),
                new SqlParameter("@PNombre", p.PNombre),
                new SqlParameter("@SNombre", p.Snombre),
                new SqlParameter("@PApellido", p.PApellido),
                new SqlParameter("@SApellido", p.SApellido),
                new SqlParameter("@Celular", p.Celular),
                new SqlParameter("@Direccion", p.Direccion)

            };
            //cadena de la consulta
            string sql = "SP_Cliente";

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

        public static bool Baja(string IdCliente)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 3),
                new SqlParameter("@IdCliente", int.Parse(IdCliente))

            };

            //cadena de la consulta
            string sql = "SP_Cliente";

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