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

            ProveedorE p;
            if (IdProveedor is null)
            {
                IdProveedor = "0";
            }
            
            if(IdProveedor == "")
            {
                //llamar la entidad usuario; que contiene los campos de la base de datos
                 p = new ProveedorE
                {
                    NombreProveedor = NombreProveedor,
                    Telefono = NoTelefono,
                    Dirección = DirProveedor
                };
                ProveedorA.Insert(p);
            }
            else
            {
                //llamar la entidad usuario; que contiene los campos de la base de datos
                p = new ProveedorE
                {
                    IdProveedor = int.Parse(IdProveedor),
                    NombreProveedor = NombreProveedor,
                    Telefono = NoTelefono,
                    Dirección = DirProveedor
                };
                ProveedorA.Insert(p);
            }

            
            return Redirect("~/Proveedor/AgregarProveedor");
        }

        [HttpPost]
        public ActionResult Baja(string IdProveedor)
        {
           
            if (ProveedorA.Baja(IdProveedor) == false)
            {
                return Json(new { result = "ProblemaBaja" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "Redirect", url = Url.Action("AgregarProveedor", "Proveedor") });

            }


        }

    }
}


