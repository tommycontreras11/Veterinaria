using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using System.Web.Helpers;
using Capa_Presentacion.Extensions;

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

        public ActionResult listarNombreCompletoAdmin()
        {
            var admin = _Negocio.Proc_listarNombreCompletoAdmin();
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
                HttpPostedFileBase fileBase = Request.Files[0];

                if (fileBase.ContentLength == 0)
                {
                    this.AddNotification("Es necesario elegir una imagen", NotificationType.WARNING);
                }
                else
                {
                    if (fileBase.ContentLength > 233472)
                    {
                        this.AddNotification("No se permite imagenes con más de 228 kilobytes", NotificationType.WARNING);
                    }
                    else
                    {
                        if (fileBase.FileName.EndsWith(".jpg"))
                        {
                            WebImage image = new WebImage(fileBase.InputStream);

                            usuario.foto = image.GetBytes();

                            // TODO: Add insert logic here
                            // TODO: Add insert logic here
                            _Negocio.Proc_crearUsuario(usuario);
                            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(usuario.email);
                            _Negocio.Proc_crearRol_Usuario(1, id_Usuario);
                            this.AddNotification("Se ha creado el usuario exitosamente", NotificationType.SUCCESS);
                            return RedirectToAction("Admins", "Admin");
                        }
                        else
                        {
                            this.AddNotification("El sistema solo acepta fotos con formato JPG", NotificationType.WARNING);
                        }

                    }
                }

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
            // TODO: Add update logic here
            byte[] imagenActual = null;

            HttpPostedFileBase fileBase = Request.Files[0];

            if (fileBase.ContentLength == 0)
            {
                imagenActual = _Negocio.Proc_listarUnaFotoPorid_Usuario(usuario.id_Usuario).FirstOrDefault();
                usuario.foto = imagenActual;
                _Negocio.Proc_actualizarUsuario(usuario);
                this.AddNotification("Se ha actualizado el usuario exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Admins", "Admin");
            }
            else
            {
                if (fileBase.ContentLength > 233472)
                {
                    this.AddNotification("No se permite imagenes con más de 228 kilobytes", NotificationType.WARNING);
                }
                else
                {
                    if (fileBase.FileName.EndsWith(".jpg"))
                    {
                        WebImage image = new WebImage(fileBase.InputStream);

                        usuario.foto = image.GetBytes();


                        // TODO: Add update logic here
                        _Negocio.Proc_actualizarUsuario(usuario);
                        this.AddNotification("Se ha actualizado el usuario exitosamente", NotificationType.SUCCESS);
                        return RedirectToAction("Admins", "Admin");
                    }
                    else
                    {
                        this.AddNotification("El sistema solo acepta fotos con formato JPG", NotificationType.WARNING);
                    }

                }
            }

            //if (ModelState.IsValid)
            //{

            //    // TODO: Add update logic here
            //    _Negocio.Proc_actualizarUsuario(usuario);

            //    return RedirectToAction("Usuarios", "Account");
            //}
            var usuario2 = _Negocio.Proc_listarUsuarioPorid_Usuario(usuario.id_Usuario);
            return View(usuario2);
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
            this.AddNotification("Se ha eliminado el usuario exitosamente", NotificationType.SUCCESS);
            return RedirectToAction("Admins", "Admin");
        }
    }
}
