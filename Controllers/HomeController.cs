using SFI_Farmacia_Jully.Models.Action;
using System;
using System.Web.Mvc;


namespace SFI_Farmacia_Jully.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View(ProductoA.Listar());
        }

        public ActionResult Dashboard()
        {

            if (Session["UsuarioLogeado"] != null)
            {
                ViewBag.Ventas = DashboardA.ObtenerInfo(1);
                ViewBag.Compras = DashboardA.ObtenerInfo(2);
                ViewBag.Inventario = DashboardA.ObtenerInfo(3);
                ViewBag.Fecha = DateTime.Now;

                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }



        }


    }
}
