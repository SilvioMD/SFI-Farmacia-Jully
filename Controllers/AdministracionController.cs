using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Web.Mvc;


namespace SFI_Farmacia_Jully.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Inventario
        public ActionResult AgregarUsuario()
        {

            return View(AdministracionA.Listar());
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(string IdEmpleado, string PNombre, string SNombre, string PApellido, string SApellido, string Celular, string Usuario, string Contraseña, string ClaR, string Tipo)
        {
            AdministracionE p;

            if (IdEmpleado is null)
            {
                IdEmpleado = "0";

            }

            if (IdEmpleado == "")
            {
                p = new AdministracionE
                {
                    IdRol = int.Parse(Tipo),
                    PNombre = PNombre,
                    Snombre = SNombre,
                    PApellido = PApellido,
                    SApellido = SApellido,
                    Celular = Celular,
                    Usuario = Usuario,
                    Contraseña = Contraseña,
                    ClaveRec = ClaR

                };

                AdministracionA.Insert(p);
            }
            else
            {
                p = new AdministracionE
                {
                    IdEmpleado = int.Parse(IdEmpleado),
                    IdRol = int.Parse(Tipo),
                    PNombre = PNombre,
                    Snombre = SNombre,
                    PApellido = PApellido,
                    SApellido = SApellido,
                    Celular = Celular,
                    Usuario = Usuario,
                    Contraseña = Contraseña,
                    ClaveRec = ClaR

                };

                AdministracionA.Insert(p);
            }


            AdministracionA.Insert(p);

            return Redirect("~/Administracion/AgregarUsuario");
        }

        [HttpPost]
        public ActionResult Baja(string IdEmpleado)
        {

            if (AdministracionA.Baja(IdEmpleado) == false)
            {
                return Json(new { result = "ProblemaBaja" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "Redirect", url = Url.Action("AgregarUsuario", "Administracion") });

            }

        }
    }
}
