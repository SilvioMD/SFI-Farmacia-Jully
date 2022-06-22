using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult AgregarProducto()
        {
            /*if (Session["UsuarioLogeado"] != null)
            {
                ViewBag.CboLaboratorio = new SelectList(CatalogoA.ListarLab(), "IdLaboratorio", "Laboratorio");
                ViewBag.CboAccionFarm = new SelectList(CatalogoA.ListarAccionFarm(), "IdAccionFarmacologica", "AccionFarmacologica");
                ViewBag.CboPresentacion = new SelectList(CatalogoA.ListarPresentacion(), "IdPresentacion", "Presentacion");

                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View(ProductoA.Listar());
                
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }*/
            ViewBag.CboLaboratorio = new SelectList(CatalogoA.ListarLab(), "IdLaboratorio", "Laboratorio");
            ViewBag.CboAccionFarm = new SelectList(CatalogoA.ListarAccionFarm(), "IdAccionFarmacologica", "AccionFarmacologica");
            ViewBag.CboPresentacion = new SelectList(CatalogoA.ListarPresentacion(), "IdPresentacion", "Presentacion");

            
            return View(ProductoA.Listar());
        }

        public JsonResult Listar()
        {
            return Json(new { data = ProductoA.Listar() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DatosEditar(string Codigo)
        {
            return Json(new { data = ProductoA.ProductoAEditar(Convert.ToInt32(Codigo))}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(ProductoE p)
        {
           
            return Json(new { result = ProductoA.Insert(p) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Baja(string IdMedicamento)
        {

            return Json(new { result = ProductoA.Baja(IdMedicamento) }, JsonRequestBehavior.AllowGet);

        }

    }
}
