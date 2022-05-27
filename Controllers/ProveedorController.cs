using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class ProveedorController : Controller
    {
        
        // GET: Proveedor
        public ActionResult AgregarProveedor()
        {
            return View(ProveedorA.Listar());
        }

        [HttpPost]
        public ActionResult Agregar(string NombreProveedor,string NoTelefono, string DirProveedor)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            ProveedorE p = new ProveedorE
            {
                NombreProveedor = NombreProveedor,
                Telefono = NoTelefono,
                Dirección = DirProveedor
            };

            ProveedorA.Insert(p);
            return Redirect("~/Proveedor/AgregarProveedor");
        }

    }
}


