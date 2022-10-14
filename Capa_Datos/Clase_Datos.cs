using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class Clase_Datos
    {
        /*----------Tabla Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_loguearse----------*/
        public Proc_loguearse_Result Proc_loguearse(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_loguearse(usuario.email, usuario.password).FirstOrDefault();
            }
        }

        /*----------Proc_listarUsuario----------*/
        public List<Proc_listarUsuario_Result> Proc_listarUsuario() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarUsuario().ToList();
            }
        }

        /*----------Proc_listarUsuarioPorid_Usuario_Result----------*/
        public Proc_listarUsuarioPorid_Usuario_Result Proc_listarUsuarioPorid_Usuario(int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarUsuarioPorid_Usuario(id_Usuario).FirstOrDefault();
            }
        }

        /*----------Proc_listarid_UsuarioPorEmail----------*/
        public int Proc_listarid_UsuarioPorEmail(string email) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_UsuarioPorEmail @email",
                    new SqlParameter("@email", email)).FirstOrDefault();
            }
        }

        /*----------Proc_crearUsuario----------*/
        public void Proc_crearUsuario(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearUsuario(usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.email, usuario.password);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarUsuario----------*/
        public void Proc_actualizarUsuario(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_actualizarUsuario(usuario.id_Usuario, usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.email, usuario.password);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarUsuario----------*/
        public void Proc_eliminarUsuario(int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_eliminarUsuario(id_Usuario);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Usuario----------*/


        /*----------Tabla Rol----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_crearRol----------*/
        public void Proc_crearRol(Rol rol) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearRol(rol.nombre);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol----------*/


        /*----------Tabla Rol_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarid_RolPorid_Usuario----------*/

        public int Proc_listarid_RolPorid_Usuario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_RolPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id_Usuario)).FirstOrDefault();
            }
        }

        /*----------Proc_crearRol_Usuario----------*/
        public void Proc_crearRol_Usuario(int id_Rol, int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearRol_Usuario(id_Rol, id_Usuario);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol_Usuario----------*/


        /*----------Tabla Mascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarMascota----------*/
        public List<Proc_listarMascota_Result> Proc_listarMascota() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarMascota().ToList();
            }
        }

        /*----------Proc_listarMascotaPorid_Mascota----------*/
        public Proc_listarMascotaPorid_Mascota_Result Proc_listarMascotaPorid_Mascota(int id_Mascota) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarMascotaPorid_Mascota(id_Mascota).FirstOrDefault();
            }
        }

        /*----------Proc_crearMascota----------*/
        public void Proc_crearMascota(Mascota mascota) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearMascota(mascota.id_Usuario, mascota.id_Tipo, mascota.id_Raza, mascota.nombre_Completo, mascota.sexo, mascota.peso, mascota.foto, DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), mascota.fecha_Modificacion);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarMascota----------*/
        public void Proc_actualizarMascota(Mascota mascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarMascota(mascota.id_Mascota, mascota.id_Usuario, mascota.id_Tipo, mascota.id_Raza, mascota.nombre_Completo, mascota.sexo, mascota.peso, mascota.foto, DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), mascota.fecha_Modificacion);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarMascota----------*/
        public void Proc_eliminarMascota(int id_Mascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarMascota(id_Mascota);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Mascota----------*/


        /*----------Tabla TipoMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarTipoMascota----------*/
        public List<Proc_listarTipoMascota_Result> Proc_listarTipoMascota() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarTipoMascota().ToList();
            }
        }

        /*----------Proc_listarTipoMascotaPorid_Tipo----------*/
        public Proc_listarTipoMascotaPorid_Tipo_Result Proc_listarTipoMascotaPorid_Tipo(int id_Tipo)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarTipoMascotaPorid_Tipo(id_Tipo).FirstOrDefault();
            }
        }

        /*----------Proc_crearTipoMascota----------*/
        public void Proc_crearTipoMascota(TipoMascota tipoMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearTipoMascota(tipoMascota.tipo);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarTipoMascota----------*/
        public void Proc_actualizarTipoMascota(TipoMascota tipoMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarTipoMascota(tipoMascota.id_Tipo, tipoMascota.tipo);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarTipoMascota----------*/
        public void Proc_eliminarTipoMascota(int id_Tipo)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarTipoMascota(id_Tipo);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla TipoAnimal----------*/


        /*----------Tabla RazaMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRazaMascota----------*/
        public List<Proc_listarRazaMascota_Result> Proc_listarRazaMascota()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarRazaMascota().ToList();
            }
        }

        /*----------Proc_listarRazaMascotaPorid_Raza----------*/
        public Proc_listarRazaMascotaPorid_Raza_Result Proc_listarRazaMascotaPorid_Raza(int id_Raza)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarRazaMascotaPorid_Raza(id_Raza).FirstOrDefault();
            }
        }

        /*----------Proc_crearRaza----------*/
        public void Proc_crearRazaMascota(RazaMascota razaMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearRazaMascota(razaMascota.raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarRazaMascota----------*/
        public void Proc_actualizarRazaMascota(RazaMascota razaMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarRazaMascota(razaMascota.id_Raza, razaMascota.raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarRazaMascota----------*/
        public void Proc_eliminarRazaMascota(int id_Raza)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarRazaMascota(id_Raza);
                db.SaveChanges();
            }
        }
    }
}
