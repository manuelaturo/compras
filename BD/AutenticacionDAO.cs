using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class AutenticacionDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;

        public bool checkUsuario(string correo, string password)
        {
            try
            {
                int idUser;
                bool result = false;
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    idUser = db.QueryFirst<int>("SELECT Id_Usuario FROM Usuarios  WHERE Correo=@correo AND Password=@password",
                        new { correo = correo, password = password });
                    db.Close();
                }
                if (idUser > 0) {
                    result = true;
                }
                return result;
            }
            catch(Exception ex)
            {
                return false;

            }
        }
    }
}