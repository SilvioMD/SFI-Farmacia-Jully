using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Carrito()
        {
            return View(ProductoA.Listar());

        }

    }
}
