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
        public ActionResult Agregar(string NombreProveedor,string NoTelefono, string DirProveedor,string IdProveedor)
        {
            if (IdProveedor is null)
            {
                IdProveedor = "0";
            }

            //llamar la entidad usuario; que contiene los campos de la base de datos
            ProveedorE p = new ProveedorE
            {
                IdProveedor = int.Parse(IdProveedor),
                NombreProveedor = NombreProveedor,
                Telefono = NoTelefono,
                Dirección = DirProveedor
            };

            ProveedorA.Insert(p);
            return Redirect("~/Proveedor/AgregarProveedor");
        }

        [HttpPost]
        public ActionResult Baja(string IdProveedor)
        {
           
            ProveedorA.Baja(IdProveedor);
            return Redirect("~/Proveedor/AgregarProveedor");
        }

    }
}


