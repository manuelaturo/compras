using compras.BD.Entities;
using compras.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class UsuariosDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

        public  List<Usuario> GetUsuario()
        {

            try
            {
                List<Usuario> lista = new List<Usuario>();
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    lista = db.Query<Usuario>("SELECT * FROM Usuarios").ToList();
                    db.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
      

        public List<UsuariosEntity> GetUsuariosByquestions(string email)
        {

            try
            {
                List<UsuariosEntity> lista = new List<UsuariosEntity>();
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@email", email);
                    lista = db.Query<UsuariosEntity>("SELECT Id_Usuario, Correo as email ,Nombre +' '+ Apellido_Paterno + ' ' + Apellido_Materno as nombre" +
                        " FROM Usuarios where  Correo like @email", queryParameters, commandType: CommandType.Text).ToList();
                    db.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UsuariosEntity GetUsuariosByquestions(int idUser)
        {

            try
            {
                UsuariosEntity lista = new UsuariosEntity();
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@Id_Usuario", idUser);
                    lista = db.Query<UsuariosEntity>("SELECT Id_Usuario, Correo as email ,Nombre +' '+ Apellido_Paterno + ' ' + Apellido_Materno as nombre" +
                        " FROM Usuarios where  Id_Usuario like @Id_Usuario", queryParameters, commandType: CommandType.Text).FirstOrDefault();
                    db.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool AddUsuario(UsuariosEntity us)
        {
            try
            {
                DateTime insertdate = DateTime.Now;
                var usr = 1;
                
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    _ = db.Execute("INSERT INTO Usuarios" +
         " (Correo" +
         "  , Nombre" +
          " , Apellido_Paterno" +
           ", Apellido_Materno" +
           ", Password" +
           ", Perfil" +
           ", Fecha_Nacimiento" +
           ", Curp" +
           ", Id_Usuario_Crear" +
           ", Fecha_Creacion" +
           ", Numero_Empleado" +
           ", Compañia)" +
     "VALUES ( " +
           "@email" +
      "     , @Nombre" +
      "     , @APaterno" +
       "    , @AMaterno" +
        "   , @password" +
         "  , @perfil" +
          " , @fechaNacimiento" +
           ", @curp" +
           ", @usr" +
           ", @insertdate" +
           ", @noEmpledo" +
           ",@Compañia)",
                        new
                        {
                            us.email,
                            us.nombre,
                            us.APaterno,
                            us.AMaterno,
                            us.password,
                            us.perfil,
                            us.fechaNacimiento,
                            us.curp,
                            usr,
                            insertdate,
                            us.noEmpledo,
                            us.compañia
                        });
                    db.Close();
                    return true;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}