using compras.BD;
using compras.BD.Entities;
using compras.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class UsuarioService
    {
        public static List<Usuario> GetUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                UsuariosDAO us = new UsuariosDAO();
                lista = us.GetUsuario();
                return lista;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public static Usuario GetUsuarioBynoEmpleado(int noEmpleado)
        {

            try
            {
                //List<Usuario> usuarios1 = new List<Usuario>();
                //using (Datos.ComedorEntities context = new Datos.ComedorEntities())
                //{
                //    var usuarios = (from d in context.Usuarios
                //                    where d.Numero_Empleado == noEmpleado
                //                    select d).FirstOrDefault();

                //    if (usuarios != null)
                //    {
                //        Usuario usuario = new Usuario();
                //        //usuario.noEmpledo = usuarios.Numero_Empleado;
                //        //usuario.nombre = usuarios.Nombre;
                //        //usuario.APaterno = usuarios.Apellido_Paterno;
                //        //usuario.AMaterno = usuarios.Apellido_Materno;
                //        //usuario.curp = usuarios.Curp;
                //        //usuario.fechaNacimiento = usuarios.Fecha_Nacimiento;
                //        //usuario.email = usuarios.Correo;
                //        return usuario;
                //    }
                //    else
                //    {
                //        Usuario usuario = new Usuario();
                //        return usuario;
                //    }
                //}
                Usuario usuario = new Usuario();
                return usuario;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public bool AddUsuario(Usuario usuario)
        {

            try
            {
                UsuariosDAO us = new UsuariosDAO();
                UsuariosEntity usuariosEntity = new
                UsuariosEntity(usuario.Numero_Empleado, usuario.Nombre,
                usuario.Apellido_Paterno, usuario.Apellido_Materno, usuario.Curp,
                usuario.Fecha_Nacimiento, usuario.Correo, usuario.password, usuario.perfil);
                us.AddUsuario(usuariosEntity);
                return true;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public static int UpDateUsuario(Usuario usuario)
        {

            try
            {
                //using (Datos.ComedorEntities context = new Datos.ComedorEntities())
                //{
                //    //var UpDate = context.UpDateEmpleado(usuario.email, usuario.nombre, usuario.APaterno, usuario.AMaterno, usuario.fechaNacimiento, usuario.curp, usuario.noEmpledo);
                //    //if (UpDate == 0)
                //    //{
                //    //    return 1;
                //    //}
                //    //else
                //    //{
                //    return 0;
                //    //}
                //}
                return 0;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public static int DeleteUsuario(int noEmpleado)
        {

            try
            {
                //using (Datos.ComedorEntities context = new Datos.ComedorEntities())
                //{
                //    var Delete = context.DeleteEmpleado(noEmpleado);
                //    if (Delete == 0)
                //    {
                //        return 1;
                //    }
                //    else
                //    {
                //        return 0;
                //    }
                //}
                return 0;
            }
            catch (Exception x)
            {

                throw;
            }
        }
    }
}