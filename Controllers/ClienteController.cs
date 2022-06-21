
using System.Web.Mvc;
using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;

namespace SFI_Farmacia_Jully.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult AgregarCliente()
        {
            if (Session["UsuarioLogeado"] != null)
            {

                ViewBag.NombreUsuario = Session["UsuarioLogeado"].ToString();
                return View(ClienteA.Listar());

            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
            
        }

        [HttpPost]
        public ActionResult Agregar(string IdCliente, string PNombre, string SNombre, string PApellido, string SApellido, string NumTelefono, string Direccion)
        {
            ClienteE p;

            if (IdCliente is null)
            {
                IdCliente = "0";

            }

            if (IdCliente == "")
            {
                //llamar la entidad usuario; que contiene los campos de la base de datos
                p = new ClienteE
                {
                    PNombre = PNombre,
                    Snombre = SNombre,
                    PApellido = PApellido,
                    SApellido = SApellido,
                    Celular = NumTelefono,
                    Direccion = Direccion

                };

                ClienteA.Insert(p);
            }
            else
            {
                p = new ClienteE
                {
                    IdCliente = int.Parse(IdCliente),
                    PNombre = PNombre,
                    Snombre = SNombre,
                    PApellido = PApellido,
                    SApellido = SApellido,
                    Celular = NumTelefono,
                    Direccion = Direccion

                };

                ClienteA.Insert(p);

            }
            //llamar la entidad usuario; que contiene los campos de la base de datos

            return Redirect("~/Cliente/AgregarCliente");
        }

        [HttpPost]
        public ActionResult Baja(string IdCliente)
        {

            if (ClienteA.Baja(IdCliente) == false)
            {
                return Json(new { result = "ProblemaBaja" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = "Redirect", url = Url.Action("AgregarCliente", "Cliente") });

            }


        }


    }
}
