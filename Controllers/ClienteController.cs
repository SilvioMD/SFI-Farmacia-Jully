using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            return View(ClienteA.Listar());
        }

        [HttpPost]
        public ActionResult Agregar(string PNombre, string SNombre, string PApellido, string SApellido, string NumTelefono, string Direccion)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            ClienteE p = new ClienteE
            {
                PNombre = PNombre, 
                Snombre = SNombre,
                PApellido = PApellido,
                SApellido = SApellido,
                Celular = NumTelefono,
                Direccion = Direccion

            };

            ClienteA.Insert(p);
            return Redirect("~/Cliente/AgregarCliente");
        }


    }
}
