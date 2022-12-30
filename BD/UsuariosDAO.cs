using compras.BD.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class UsuariosDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["dapper"].ConnectionString;

        public bool AddComedor(UsuariosEntity us)
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
           ", Numero_Empleado)" +
     "VALUES" +
           "@Correo," +
      "     , @Nombre" +
      "     , @Apellido_Paterno" +
       "    , @Apellido_Materno" +
        "   , @Password" +
         "  , @Perfil" +
          " , @Fecha_Nacimiento" +
           ", @Curp" +
           ", @Id_Usuario_Crear" +
           ", @Fecha_Creacion" +
           ", @Numero_Empleado)",
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
                            us.noEmpledo
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