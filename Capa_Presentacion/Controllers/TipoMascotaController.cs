using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace Capa_Presentacion.Controllers
{
    public class TipoMascotaController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController accountController = new AccountController();

        // GET: TipoMascota
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoMascota/Tipo
        public ActionResult Tipo()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (accountController.IsValid(User.Identity.Name) == 2)
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

        public ActionResult TipoJson()
        {
            var tipoMascota = _Negocio.Proc_listarTipoMascota();
            return Json(tipoMascota, JsonRequestBehavior.AllowGet);
        }

        // GET: TipoMascota/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (accountController.IsValid(User.Identity.Name) == 2)
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

        // POST: TipoMascota/Create
        [HttpPost]
        public ActionResult Create(TipoMascota tipoMascota)
        {
            try
            {
                // TODO: Add insert logic here
                _Negocio.Proc_crearTipoMascota(tipoMascota);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMascota/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (accountController.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            var tipoAnimal = _Negocio.Proc_listarTipoMascotaPorid_Tipo(id);
            return View(tipoAnimal);
        }

        // POST: TipoMascota/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoMascota tipoMascota)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarTipoMascota(tipoMascota);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMascota/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TipoMascota/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (User.Identity.IsAuthenticated)
                {
                    if (accountController.IsValid(User.Identity.Name) == 2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
                _Negocio.Proc_eliminarTipoMascota(id);
                return RedirectToAction("Tipo", "TipoMascota");
            }
            catch
            {
                return View();
            }
        }
    }
}
