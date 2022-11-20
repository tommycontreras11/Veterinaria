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
    public class Mascota_UsuarioController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Mascota_Usuarios
        public ActionResult Index()
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
            var mascota_Usuario = _Negocio.Proc_listarMascota_Usuario();
            return View(mascota_Usuario);
        }

        public ActionResult listarMascotaUsuario()
        {
            var mascota_Usuario = _Negocio.Proc_listarMascota_Usuario();
            return Json(mascota_Usuario, JsonRequestBehavior.AllowGet);
        }

        // GET: Mascota_Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mascota_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascota_Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascota_Usuario/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (account.IsValid(User.Identity.Name) == 2)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    var mascota_Usuario = _Negocio.Proc_listarMascotaPorid_Mascota(id);
        //    return View(mascota_Usuario);
        //}

        // POST: Mascota_Usuario/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Mascota_Usuario mascota_Usuario)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        _Negocio.Proc_actualizarMascota_Usuario(mascota_Usuario);
        //        this.AddNotification("Se ha actualizado la mascota del usuario exitosamente", NotificationType.SUCCESS);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Mascota_Usuario/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Mascota_Usuario/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        if (User.Identity.IsAuthenticated) 
        //        {
        //            if (account.IsValid(User.Identity.Name) == 2) 
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else 
        //        {
        //            return RedirectToAction("Login", "Account");
        //        }

        //        _Negocio.Proc_eliminarMascota_Usuario(id);
        //        this.AddNotification("Se ha eliminado la mascota del usuario exitosamente", NotificationType.SUCCESS);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
