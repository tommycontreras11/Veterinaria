using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class Clase_Negocio
    {
        Clase_Datos _Datos = new Clase_Datos();

        /*----------Tabla Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_loguearse----------*/
        public Proc_loguearse_Result Proc_loguearse(Usuario usuario)
        {
            return _Datos.Proc_loguearse(usuario);
        }

        /*----------Proc_listarUsuario----------*/
        public List<Proc_listarUsuario_Result> Proc_listarUsuario()
        {
            return _Datos.Proc_listarUsuario();
        }

        /*----------Proc_listarUsuarioPorid_Usuario_Result----------*/
        public Proc_listarUsuarioPorid_Usuario_Result Proc_listarUsuarioPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarUsuarioPorid_Usuario(id_Usuario);
        }

        /*----------Proc_listarid_UsuarioPorEmail----------*/
        public int Proc_listarid_UsuarioPorEmail(string email)
        {
            return _Datos.Proc_listarid_UsuarioPorEmail(email);
        }

        /*----------Proc_crearUsuario----------*/
        public void Proc_crearUsuario(Usuario usuario)
        {
            _Datos.Proc_crearUsuario(usuario);
        }

        /*----------Proc_actualizarUsuario----------*/
        public void Proc_actualizarUsuario(Usuario usuario)
        {
            _Datos.Proc_actualizarUsuario(usuario);
        }

        /*----------Proc_eliminarUsuario----------*/
        public void Proc_eliminarUsuario(int id_Usuario)
        {
            _Datos.Proc_eliminarUsuario(id_Usuario);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Usuario----------*/


        /*----------Tabla Rol----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_crearRol----------*/
        public void Proc_crearRol(Rol rol)
        {
            _Datos.Proc_crearRol(rol);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol----------*/


        /*----------Tabla Rol_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarid_RolPorid_Usuario----------*/

        public int Proc_listarid_RolPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarid_RolPorid_Usuario(id_Usuario);
        }

        /*----------Proc_crearRol_Usuario----------*/
        public void Proc_crearRol_Usuario(int id_Rol, int id_Usuario)
        {
            _Datos.Proc_crearRol_Usuario(id_Rol, id_Usuario);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol_Usuario----------*/


        /*----------Tabla Mascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarMascota----------*/
        public List<Proc_listarMascota_Result> Proc_listarMascota()
        {
            return _Datos.Proc_listarMascota();
        }

        /*----------Proc_listarMascotaPorid_Mascota----------*/
        public Proc_listarMascotaPorid_Mascota_Result Proc_listarMascotaPorid_Mascota(int id_Mascota)
        {
            return _Datos.Proc_listarMascotaPorid_Mascota(id_Mascota);
        }

        /*----------Proc_crearMascota----------*/
        public void Proc_crearMascota(Mascota mascota)
        {
            _Datos.Proc_crearMascota(mascota);
        }

        /*----------Proc_actualizarMascota----------*/
        public void Proc_actualizarMascota(Mascota mascota)
        {
            _Datos.Proc_actualizarMascota(mascota);
        }

        /*----------Proc_eliminarMascota----------*/
        public void Proc_eliminarMascota(int id_Mascota)
        {
            _Datos.Proc_eliminarMascota(id_Mascota);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Mascota----------*/


        /*----------Tabla TipoMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarTipoMascota----------*/
        public List<Proc_listarTipoMascota_Result> Proc_listarTipoMascota()
        {
            return _Datos.Proc_listarTipoMascota();
        }

        /*----------Proc_listarTipoMascotaPorid_Tipo----------*/
        public Proc_listarTipoMascotaPorid_Tipo_Result Proc_listarTipoMascotaPorid_Tipo(int id_Tipo)
        {
            return _Datos.Proc_listarTipoMascotaPorid_Tipo(id_Tipo);
        }

        /*----------Proc_crearTipoMascota----------*/
        public void Proc_crearTipoMascota(TipoMascota tipoMascota)
        {
            _Datos.Proc_crearTipoMascota(tipoMascota);
        }

        /*----------Proc_actualizarTipoMascota----------*/
        public void Proc_actualizarTipoMascota(TipoMascota tipoMascota)
        {
            _Datos.Proc_actualizarTipoMascota(tipoMascota);
        }

        /*----------Proc_eliminarTipoMascota----------*/
        public void Proc_eliminarTipoMascota(int id_Tipo)
        {
            _Datos.Proc_eliminarTipoMascota(id_Tipo);
        }

        /*----------Fin de los procedimientos almacenados de la tabla TipoAnimal----------*/


        /*----------Tabla RazaMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRazaMascota----------*/
        public List<Proc_listarRazaMascota_Result> Proc_listarRazaMascota()
        {
            return _Datos.Proc_listarRazaMascota();
        }

        /*----------Proc_listarRazaMascotaPorid_Raza----------*/
        public Proc_listarRazaMascotaPorid_Raza_Result Proc_listarRazaMascotaPorid_Raza(int id_Raza)
        {
            return _Datos.Proc_listarRazaMascotaPorid_Raza(id_Raza);
        }

        /*----------Proc_crearRazaMascota----------*/
        public void Proc_crearRazaMascota(RazaMascota razaMascota)
        {
            _Datos.Proc_crearRazaMascota(razaMascota);
        }

        /*----------Proc_actualizarRazaMascota----------*/
        public void Proc_actualizarRazaMascota(RazaMascota razaMascota)
        {
            _Datos.Proc_actualizarRazaMascota(razaMascota);
        }

        /*----------Proc_eliminarRazaMascota----------*/
        public void Proc_eliminarRazaMascota(int id_Raza)
        {
            _Datos.Proc_eliminarRazaMascota(id_Raza);
        }
    }
}

