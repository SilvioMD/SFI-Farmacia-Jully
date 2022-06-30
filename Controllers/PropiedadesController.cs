using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully.Controllers
{
    public class PropiedadesController : Controller
    {
        // GET: Cliente
        public ActionResult Rpresentacion()
        {

            return View(PresentacionA.Listar());
        }

        [HttpPost]
        public ActionResult AgregarPresentacion(string Presentacion)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            PresentacionE p = new PresentacionE
            {
                Presentacion = Presentacion,

            };

            PresentacionA.Insert(p);
            return Redirect("~/Propiedades/Rpresentacion");
        }

        // GET: Cliente
        public ActionResult RG_propiedades()
        {

            return View(LaboratorioA.Listar());
        }

        [HttpPost]
        public ActionResult AgregarLaboratorio(string Laboratorio)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            LaboratorioE p = new LaboratorioE
            {
                Laboratorio = Laboratorio,

            };

            LaboratorioA.Insert(p);
            return Redirect("~/Propiedades/RG_propiedades");
        }

        // GET: Cliente
        public ActionResult Rpropiedad2()
        {

            return View(AccionFarmacologicaA.Listar());
        }

        [HttpPost]
        public ActionResult AgregarAccion(string Accion, string Descripcion)
        {
            //llamar la entidad usuario; que contiene los campos de la base de datos
            AccionFarmacologicaE p = new AccionFarmacologicaE
            {
                AccionFarmacologica = Accion,
                Descripcion = Descripcion

            };

            AccionFarmacologicaA.Insert(p);
            return Redirect("~/Propiedades/Rpropiedad2");
        }
    }
}