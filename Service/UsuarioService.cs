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
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    //DynamicParameters par = new DynamicParameters();

                    //var result =  context.QueryAsync<Usuario>(sql: "", param: par, commandType: CommandType.StoredProcedure);
                    var usuarios = (from d in context.Usuarios

                    select d).ToList();

                    if (usuarios.Count > 0)
                    {
                    foreach (var obj in usuarios)
                        {
                            Usuario usuario = new Usuario();
                            usuario.noEmpledo = obj.Numero_Empleado;
                            usuario.nombre = obj.Nombre;
                            usuario.APaterno = obj.Apellido_Paterno;
                            usuario.AMaterno = obj.Apellido_Materno;
                            usuario.Rol = obj.Perfil;
                            usuario.Contraseña = obj.Password;
                            usuario.curp = obj.Curp;
                            usuario.fechaNacimiento = obj.Fecha_Nacimiento;
                            usuario.Compañia = obj.Compañia;
                            usuario.email = obj.Correo;
                            usuario.ubicacion = obj.ubicacion;
                            usuario.status = obj.status;
                            lista.Add(usuario);
                        }
                        return lista;
                    }
                    else
                    {
                        return lista;
                    }
                }
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
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    var usuarios = (from d in context.Usuarios
                                    where d.Numero_Empleado == noEmpleado
                                    select d).FirstOrDefault();

                    if (usuarios != null)
                    {
                        Usuario usuario = new Usuario();
                        usuario.noEmpledo = usuarios.Numero_Empleado;
                        usuario.nombre = usuarios.Nombre;
                        usuario.APaterno = usuarios.Apellido_Paterno;
                        usuario.AMaterno = usuarios.Apellido_Materno;
                        usuario.Rol = usuarios.Perfil;
                        usuario.Contraseña = usuarios.Password;
                        usuario.curp = usuarios.Curp;
                        usuario.fechaNacimiento = usuarios.Fecha_Nacimiento;
                        usuario.Compañia = usuarios.Compañia;
                        usuario.email = usuarios.Correo;
                        usuario.ubicacion = usuarios.ubicacion;
                        usuario.status = usuarios.status;
                        return usuario;
                    }
                    else
                    {
                        Usuario usuario = new Usuario();
                        return usuario;
                    }
                }
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public static int AddUsuario(Usuario usuario)
        {

            try
            {
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    var add = context.AddEmpleado(usuario.email, usuario.nombre, usuario.APaterno, usuario.AMaterno, usuario.Contraseña, usuario.Rol, usuario.fechaNacimiento, usuario.curp, usuario.noEmpledo, usuario.ubicacion, usuario.status, usuario.Compañia);
                    if (add == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
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
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    var UpDate = context.UpDateEmpleado(usuario.email, usuario.nombre, usuario.APaterno, usuario.AMaterno, usuario.Contraseña, usuario.Rol, usuario.fechaNacimiento, usuario.curp, usuario.noEmpledo, usuario.ubicacion, usuario.status, usuario.Compañia);
                    if (UpDate == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
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
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    var Delete = context.DeleteEmpleado(noEmpleado);
                    if (Delete == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception x)
            {

                throw;
            }
        }
    }
}