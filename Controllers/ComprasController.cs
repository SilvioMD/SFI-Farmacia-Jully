using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Compra()
        {
            if (Session["UsuarioLogeado"] != null)
            {

                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View(ProductoA.Listar());

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }


        }

        public ActionResult VerCompras()
        {
            if (Session["UsuarioLogeado"] != null)
            {

                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View(ReportesA.MostrarCompras());

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }


        }

        [HttpPost]
        public ActionResult GuardarCompra(List<CompraE> Productos)
        {
            try
            {
                decimal Total = 0;

                for (var i = 0; i <= Productos.Count - 1; i++)
                {
                    Total += Productos[i].Precio * Productos[i].Cantidad;
                }

                //se insertan datos general de la factura
                if (CompraA.InsertCompra(Total, Productos[0].NoFactura, Productos[0].IdProveedor) == true)
                {
                    //insertar los detalles de la factura
                    for (var cant = 0; cant <= Productos.Count - 1; cant++)
                    {
                        CompraA.InsertDetalleCompra(Productos[0].NoFactura, Productos[0].IdProveedor, Productos[cant].IdMedicamento,
                            Convert.ToDateTime((Productos[cant].FechaVenc)), Productos[cant].PrecioCompra, Productos[cant].Precio, Productos[cant].Cantidad);
                    }
                }

                return Json(new { result = "Redirect", url = Url.Action("Compra", "Compras") });
            }
            catch (System.Exception)
            {
                return Json(new { result = "Problema" }, JsonRequestBehavior.AllowGet);


            }

        }

    }
}
