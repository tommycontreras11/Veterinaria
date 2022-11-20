using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using System.Security;
using System.Web.Security;
using System.Web.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Web.Helpers;
using Capa_Presentacion.Extensions;

namespace Capa_Presentacion.Controllers
{
    public class AccountController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        // GET: Account
        public ActionResult Perfil()
        {
            return View();
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");   
            //}

            return View();
        }

        [HttpPost]
        // GET: Account/Login
        public ActionResult Login(Usuario usuario)
        {
            var autenticarUsuario = _Negocio.Proc_loguearse(usuario);
            if (autenticarUsuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.AddNotification("Usuario y/o Password incorrectos", NotificationType.ERROR);
            }

            return View(usuario);
        }

        public int IsValid(string email) 
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(email);
            var id_Rol = _Negocio.Proc_listarid_RolPorid_Usuario(id_Usuario);

            if (id_Rol == 1)
            {
                return id_Rol;
            }
            else if (id_Rol == 2)
            {
                return id_Rol;
            }
            return 0;
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Usuarios
        public ActionResult Usuarios()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (IsValid(User.Identity.Name) == 2)
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

        public ActionResult listarUsuario() 
        {
            var usuario = _Negocio.Proc_listarUsuario();
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarUsuarioPorid_Usuario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var usuario = _Negocio.Proc_listarUsuarioPorid_Usuario(id_Usuario);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Proc_listarnombre_CompletoPorid_Usuario(List<int> id) 
        {
            var nombre = _Negocio.Proc_listarnombre_CompletoPorid_Usuario(id);
            return Json(nombre, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarNombre_CompletoPorid_Usuario(int id)
        {
            var nombre = _Negocio.Proc_listarNombre_CompletoPorid_Usuario(id);
            return Json(nombre, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarEmailPorid_Usuario(int id)
        {
            var id_Usuario = _Negocio.Proc_listarEmailPorid_Usuario(id);
            return Json(id_Usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarid_UsuarioPorEmail()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            return Json(id_Usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarid_RolPorid_Usuario(int id)
        {
            var usuario = _Negocio.Proc_listarid_RolPorid_Usuario(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getImage(List<int> id)
        {
            //Imagen image1 = db.Imagen.Find(id);

            var imagen = _Negocio.Proc_listarFotoPorid_Usuario(id).FirstOrDefault();

            byte[] byteImage = imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

        public ActionResult getUnaImage(int id)
        {
            //Imagen image1 = db.Imagen.Find(id);

            var imagen = _Negocio.Proc_listarUnaFotoPorid_Usuario(id).FirstOrDefault();

            byte[] byteImage = imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

        public ActionResult getImagePorNombre(string nombre)
        {
            //Imagen image1 = db.Imagen.Find(id);

            var imagen = _Negocio.Proc_listarFotoPorNombreUsuario(nombre).FirstOrDefault();

            byte[] byteImage = imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

        public ActionResult validar(string email)
        {
            var result = "";
            if (User.Identity.Name == email)
            {
                result = "Es igual";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Account/Admin
        public ActionResult Admin()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (IsValid(User.Identity.Name) == 2)
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

        // GET: Account/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Account/Create
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
                            _Negocio.Proc_crearRol_Usuario(2, id_Usuario);
                            this.AddNotification("Se ha creado el usuario exitosamente", NotificationType.SUCCESS);
                            return RedirectToAction("Login", "Account");
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

        // GET: Account/CreateAdmin
        public ActionResult CreateAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (IsValid(User.Identity.Name) == 2) 
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

        // POST: Account/CreateAdmin
        [HttpPost]
        public ActionResult CreateAdmin(Usuario usuario)
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (IsValid(User.Identity.Name) == 2)
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

        // POST: Account/Edit/5
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
            }
            else
            {
                if (fileBase.ContentLength > 233472)
                {
                    this.AddNotification("No se permite imagenes con más de 228 kilobytes", NotificationType.WARNING);
                }
                else {
                    if (fileBase.FileName.EndsWith(".jpg"))
                    {
                        WebImage image = new WebImage(fileBase.InputStream);

                        usuario.foto = image.GetBytes();


                        // TODO: Add update logic here
                        _Negocio.Proc_actualizarUsuario(usuario);
                        this.AddNotification("Se ha actualizado el usuario exitosamente", NotificationType.SUCCESS);
                        return RedirectToAction("Usuarios", "Account");
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

        // GET: Account/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Account/Delete/5
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO: Add delete logic here
            if (User.Identity.IsAuthenticated)
            {
                if (IsValid(User.Identity.Name) == 2)
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
            return RedirectToAction("Usuarios", "Account");
        }
    }
}
