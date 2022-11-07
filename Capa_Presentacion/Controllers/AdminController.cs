using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace Capa_Presentacion.Controllers
{
    public class AdminController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Admins
        public ActionResult Admins()
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

        public ActionResult listarAdmin()
        {
            var admin = _Negocio.Proc_listarAdmin();
            return Json(admin, JsonRequestBehavior.AllowGet);
        }


        // GET: Admin/Create
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

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                _Negocio.Proc_crearUsuario(usuario);
                var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(usuario.email);
                _Negocio.Proc_crearRol_Usuario(1, id_Usuario);

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
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
            var usuario = _Negocio.Proc_listarUsuarioPorid_Usuario(id);
            return View(usuario);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarUsuario(usuario);

                return RedirectToAction("Admins", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Admin/Delete/5
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            try
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

                _Negocio.Proc_eliminarUsuario(id);
                return RedirectToAction("Admins", "Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
