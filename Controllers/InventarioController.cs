using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult AgregarProducto()
        {
            if (Session["UsuarioLogeado"] != null)
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
            }
           
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(string NombreProducto,string Tipo,string UnidadMedida,string descripcion, string Precio, string CantDisp, string CantMinima,string CboLaboratorio, string CboAccionFarm, string CboPresentacion)
        {

            ProductoE p;
            p = new ProductoE
            {
                Nombre = NombreProducto,
                TipoPoducto = int.Parse(Tipo),
                UnidadMedida = UnidadMedida,
                Descripcion = descripcion,
                Precio = decimal.Parse(Precio),
                CantidadDisponible = int.Parse(CantDisp),
                CantidadMinima = int.Parse(CantMinima),
                IdLaboratorio = int.Parse(CboLaboratorio),
                IdAccionFarmacologica = int.Parse(CboAccionFarm),
                IdPresentacion = int.Parse(CboPresentacion)
            };

            ProductoA.Insert(p);

            return Redirect("~/Inventario/AgregarProducto");
        }

        [HttpPost]
        public ActionResult Baja(string IdProducto)
        {

            if (ProductoA.Baja(IdProducto) == false)
            {
                return Json(new { result = "ProblemaBaja" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "Redirect", url = Url.Action("AgregarProducto", "Inventario") });

            }

        }

    }
}
