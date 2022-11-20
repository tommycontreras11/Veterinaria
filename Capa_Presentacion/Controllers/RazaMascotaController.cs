using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using Capa_Presentacion.Extensions;

namespace Capa_Presentacion.Controllers
{
    public class RazaMascotaController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Raza
        public ActionResult Index()
        {
            return View();
        }

        // GET: RazaMascota/Razas
        public ActionResult Razas()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult listarRazaMascota()
        {
            var raza = _Negocio.Proc_listarRazaMascota();
            return Json(raza, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarSoloRazaMascotaPorid_Raza(List<int> id) 
        {
            var raza = _Negocio.Proc_listarSoloRazaMascotaPorid_Raza(id);
            return Json(raza, JsonRequestBehavior.AllowGet);
        }

        // GET: RazaMascota/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: RazaMascota/Create
        [HttpPost]
        public ActionResult Create(RazaMascota razaMascota)
        {
            try
            {
                _Negocio.Proc_crearRazaMascota(razaMascota);
                // TODO: Add insert logic here
                this.AddNotification("Se ha creado la raza de mascota exitosamente", NotificationType.SUCCESS);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RazaMascota/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            var raza = _Negocio.Proc_listarRazaMascotaPorid_Raza(id);
            return View(raza);
        }

        // POST: RazaMascota/Edit/5
        [HttpPost]
        public ActionResult Edit(RazaMascota razaMascota)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarRazaMascota(razaMascota);
                this.AddNotification("Se ha actualizado la raza de mascota exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Razas", "RazaMascota");
            }
            catch
            {
                return View();
            }
        }

        // GET: RazaMascota/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: RazaMascota/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Add delete logic here
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            _Negocio.Proc_eliminarRazaMascota(id);
            this.AddNotification("Se ha eliminado la raza de mascota exitosamente", NotificationType.SUCCESS);
            return RedirectToAction("Razas", "RazaMascota");
        }
    }
}
