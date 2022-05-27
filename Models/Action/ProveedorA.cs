﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SFI_Farmacia_Jully.Models.Entity;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class ProveedorA
    {
        public static object With { get; private set; }

        public static List<ProveedorE> Listar()
        {
           
            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 1)
            };
            //cadena de la consulta
            string sql = "SP_Proveedor";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var proveedor = new List<ProveedorE>();

            if (dt.Rows.Count > 0)
            {
                
                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    ProveedorE p = new ProveedorE()
                    {
                       IdProveedor = Convert.ToInt32(dt.Rows[i]["IdProveedor"].ToString()),
                       NombreProveedor = dt.Rows[i]["Nombre"].ToString(),
                       Dirección = dt.Rows[i]["Direccion"].ToString(),
                       Telefono = dt.Rows[i]["Telefono"].ToString()
                    };

                    proveedor.Add(p);
                }
               

            }

               return proveedor;

        }

        public static bool Insert(ProveedorE p)
        {
           
            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@NombreProveedor", p.NombreProveedor),
                new SqlParameter("@DireccionProveedor", p.Dirección),
                new SqlParameter("@NumTelefono", p.Telefono)

            };
            //cadena de la consulta
            string sql = "SP_Proveedor";

            int result = Data.Data.QueryInsert(sql, parametros, CommandType.StoredProcedure, Conexion);
            if (result > 0)
            {
                return true;
            } else
            {
                return false;
            }

        }

        public static bool Edit(ProveedorE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@NombreProveedor", p.NombreProveedor),
                new SqlParameter("@DireccionProveedor", p.Dirección),
                new SqlParameter("@NumTelefono", p.Telefono)

            };

            //cadena de la consulta
            string sql = "SP_Proveedor";

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

        public static bool Baja(int Idproveedor)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@TIPO", 3),
                    new SqlParameter("@IdProveedor", Idproveedor),

                };

            //cadena de la consulta
            string sql = "SP_Proveedor";

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