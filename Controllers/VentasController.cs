using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Carrito()
        {
            if (Session["UsuarioLogeado"] != null)
            {
                ViewBag.NoFactura = VentasA.IdVenta() + 1;
                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View(ProductoA.Listar());

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
            

        }

        [HttpPost]
        public ActionResult GuardarVenta(List<VentaE> Productos)
        {
            try
            {
                decimal Total = 0;

                for (var i = 0; i <= Productos.Count - 1; i++)
                {
                    Total += Productos[i].Precio * Productos[i].Cantidad;
                }

                //se insertan datos general de la factura
                if (VentasA.InsertVenta(Total, Productos[0].TipoPago) == true)
                {
                    //insertar los detalles de la factura
                    for (var cant = 0; cant <= Productos.Count - 1; cant++)
                    {
                        VentasA.InsertDetalleVenta(Productos[cant].Precio, Productos[cant].Cantidad, Productos[0].NoFactura, Productos[cant].IdProducto);
                    }
                }

                return Json(new { result = "Redirect", url = Url.Action("Carrito", "Ventas") });
            }
            catch (System.Exception)
            {
                return Json(new { result = "Problema" }, JsonRequestBehavior.AllowGet);
                
                
            }
           
        }

    }
}
