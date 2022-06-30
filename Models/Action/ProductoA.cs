using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SFI_Farmacia_Jully.Models.Action
{
    public class ProductoA
    {
        public static List<ProductoE> Listar()
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 3)
            };

            //cadena de la consulta
            string sql = "SP_Productos";


            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);

            var producto = new List<ProductoE>();

            if (dt.Rows.Count > 0)
            {

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    //llamar la entidad usuario; que contiene los campos de la base de datos
                    ProductoE p = new ProductoE()
                    {
                        IdMedicamento = Convert.ToInt16(dt.Rows[i]["IdMedicamento"].ToString()),
                        Codigo = dt.Rows[i]["Codigo"].ToString(),
                        Nombre = dt.Rows[i]["NombreProducto"].ToString(),
                        UnidadMedida = dt.Rows[i]["UnidadMedida"].ToString(),
                        Presentacion = dt.Rows[i]["Presentacion"].ToString(),
                        AccionFarmacologica = dt.Rows[i]["AccionFarmacologica"].ToString(),
                        Laboratorio = dt.Rows[i]["Laboratorio"].ToString(),
                        Precio = Convert.ToDecimal(dt.Rows[i]["Precio"].ToString()),
                        CantidadDisponible = Convert.ToInt16(dt.Rows[i]["Cantidad"].ToString())
                    };

                    producto.Add(p);
                }


            }

            return producto;

        }

        public static ProductoE ProductoAEditar(int codigo)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 5),
                new SqlParameter("@IdMedicamento", codigo)
            };

            //cadena de la consulta
            string sql = "SP_Productos";

            //crear data table para almacenar los datos
            _ = new DataTable();
            DataTable dt = Data.Data.Query(sql, parametros, CommandType.StoredProcedure, Conexion);
            ProductoE p = new ProductoE();

            if (dt.Rows.Count > 0)
            {
                //llamar la entidad usuario; que contiene los campos de la base de datos
                p.IdMedicamento = Convert.ToInt16(dt.Rows[0]["IdMedicamento"].ToString());
                p.Nombre = dt.Rows[0]["NombreProducto"].ToString();
                p.UnidadMedida = dt.Rows[0]["UnidadMedida"].ToString();
                p.Presentacion = dt.Rows[0]["Presentacion"].ToString();
                p.AccionFarmacologica = dt.Rows[0]["AccionFarmacologica"].ToString();
                p.Laboratorio = dt.Rows[0]["Laboratorio"].ToString();
                p.Precio = Convert.ToDecimal(dt.Rows[0]["Precio"].ToString());
                p.CantidadDisponible = Convert.ToInt16(dt.Rows[0]["Cantidad"].ToString());

                return p;

            }
            else
            {

                return p;
            }

        }

        public static bool Insert(ProductoE p)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Tipo", 1),
                new SqlParameter("@IdMedicamento",p.IdMedicamento),
               new SqlParameter("@NombreProducto",p.Nombre),
               new SqlParameter("@IdTipoProducto",p.TipoPoducto),
               new SqlParameter("@CostoUnitario",150),
               new SqlParameter("@PrecioUnitario",p.Precio),
               new SqlParameter("@CantidadDisponible",p.CantidadDisponible),
               new SqlParameter("@CantidadMinima",p.CantidadMinima),
               new SqlParameter("@UnidadMedida",p.UnidadMedida),
               new SqlParameter("@IdAccionFarmacologica",p.IdAccionFarmacologica),
               new SqlParameter("@IdLaboratorio",p.IdLaboratorio),
               new SqlParameter("@IdEstadoControl",1),
               new SqlParameter("@IdPresentacion",p.IdPresentacion),
               new SqlParameter("@IdTipoEdad",1),
               new SqlParameter("@EstadoProducto",1),
               new SqlParameter("@Descripcion",p.Descripcion)
            };

            //cadena de la consulta
            string sql = "SP_Productos";

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

        public static bool Baja(string IdProducto)
        {

            //se guarda la cedena de conexion con la base de datos 
            string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //agregar los comandos
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@TIPO", 2),
                new SqlParameter("@IdMedicamento", int.Parse(IdProducto))

            };

            //cadena de la consulta
            string sql = "SP_Productos";

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