using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        public ActionResult Compra()
        {
            return View(ProductoA.Listar());
        }


    }
}
