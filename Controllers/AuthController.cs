using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;


namespace SFI_Farmacia_Jully.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authentication(string usuario, string contraseña)
        {

            //llamar la entidad usuario; que contiene los campos de la base de datos
            _ = new UsuarioE();
            UsuarioE DatosUsuario = UsuarioA.Get(usuario);


            if (Isvalid(DatosUsuario, usuario, contraseña))
            {

                Session["UsuarioLogeado"] = DatosUsuario.Usuario;

                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View("Login");

            }


        }

        private bool Isvalid(UsuarioE ClassUsuario, string usuario, string contraseña)
        {
            if (usuario == ClassUsuario.Usuario && contraseña == ClassUsuario.Contraseña)
            {

                return true;
            }
            else if (usuario != ClassUsuario.Usuario)
            {

                ViewBag.Notification = "EL usuario no se encontro en el servidor, por favor, verifique su nombre de usuario.";
                return false;
            }
            else if (contraseña != ClassUsuario.Contraseña)
            {
                ViewBag.Notification = "La contraseña es incorrecta.";
                return false;
            }
            else
            {
                return false;
            }
        }

        private bool ContraseñaSegura(string contraseña)
        {

            int NumeroCracters = contraseña.Length;

            if (NumeroCracters >= 8)
            {
                ViewBag.Notification = "La contraseña debe ser mayor a 8 carcateres.";
                return false;
            }
            else
            {

            }
            return true;

        }

        public ActionResult Salir()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Auth");
        }

    }
}
