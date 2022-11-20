using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using System.Web.Helpers;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using Capa_Presentacion.Extensions;

namespace Capa_Presentacion.Controllers
{
    public class MascotaController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Mascota
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mascota/Mascotas
        public ActionResult Mascotas()
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

        public ActionResult listarMascota()
        {
            var mascota = _Negocio.Proc_listarMascota();
            return Json(mascota, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarNombre_MascotaPorid_Usuario() 
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var mascota = _Negocio.Proc_listarNombre_MascotaPorid_Usuario(id_Usuario);
            return Json(mascota, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarTodoNombre_MascotaPorid_Usuario(List<int> id)
        {
            var mascota = _Negocio.Proc_listarTodoNombre_MascotaPorid_Usuario(id);
            return Json(mascota, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarMascotaPorid_Usuario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var mascota = _Negocio.Proc_listarMascotaPorid_Usuario(id_Usuario);
            return Json(mascota, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getImage(List<int> id)
        {
            //Imagen image1 = db.Imagen.Find(id);

            var imagen = _Negocio.Proc_listarFotoPorid_Mascota(id).FirstOrDefault();

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

            var imagen = _Negocio.Proc_listarUnaFotoPorid_Mascota(id).FirstOrDefault();

            byte[] byteImage = imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                
            }
            else 
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: Mascota/Create
        [HttpPost]
        public ActionResult Create(Mascota mascota)
        {
            try
            {
                // TODO: Add insert logic here

                ViewBag.mensaje = Request.Files[0];
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

                Mascota_Usuario mascota_Usuario = new Mascota_Usuario();

                mascota.sexo = Request.Form["sexo"];
                
                HttpPostedFileBase fileBase = Request.Files[0];

                if (fileBase.ContentLength == 0)
                {
                    this.AddNotification("Es necesario elegir una foto", NotificationType.WARNING);
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

                            mascota.foto = image.GetBytes();

                            _Negocio.Proc_crearMascota(mascota);

                            mascota_Usuario.id_Mascota = _Negocio.Proc_listarid_MascotaPornombre_Completo(mascota.nombre_Completo);
                            mascota_Usuario.id_Usuario = int.Parse(Request.Form["usuario"]);
                            mascota_Usuario.id_Tipo = int.Parse(Request.Form["tipoMascota"]);
                            mascota_Usuario.id_Raza = int.Parse(Request.Form["razaMascota"]);
                            _Negocio.Proc_crearMascota_Usuario(mascota_Usuario);

                            this.AddNotification("Se ha creado la mascota exitosamente", NotificationType.SUCCESS);
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

        // GET: Mascota/Edit/5
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
            var mascota = _Negocio.Proc_listarMascotaPorid_Mascota(id);
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        [HttpPost]
        public ActionResult Edit(Mascota mascota)
        {
            // TODO: Add update logic here
            byte[] imagenActual = null;

            HttpPostedFileBase fileBase = Request.Files[0];

            if (fileBase.ContentLength == 0)
            {
                imagenActual = _Negocio.Proc_listarUnaFotoPorid_Mascota(mascota.id_Mascota).FirstOrDefault();
                mascota.foto = imagenActual;
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

                        mascota.foto = image.GetBytes();
                    }
                    else
                    {
                        this.AddNotification("El sistema solo acepta fotos con formato JPG", NotificationType.WARNING);
                    }
                }

            }

            if (ModelState.IsValid)
            {
                _Negocio.Proc_actualizarMascota(mascota);
                this.AddNotification("Se ha actualizado la mascota exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Mascotas", "Mascota");
            }

            return View(mascota);
        }

        // GET: Mascota/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Mascota/Delete/5
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
            _Negocio.Proc_eliminarMascota(id);
            this.AddNotification("Se ha eliminado la mascota exitosamente", NotificationType.SUCCESS);
            return RedirectToAction("Mascotas", "Mascota");
        }
    }
}
