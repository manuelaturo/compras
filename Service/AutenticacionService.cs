
﻿using System;

﻿using compras.BD;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class AutenticacionService
    {
        public bool checkUsuario(string correo, string password)
        {

            bool response =false;
            try
            {
                using (Datos1.ComedorEntities1 context = new Datos1.ComedorEntities1())
                {
                    //DynamicParameters par = new DynamicParameters();

                    //var result =  context.QueryAsync<Usuario>(sql: "", param: par, commandType: CommandType.StoredProcedure);
                    int idUsuario = (from d in context.Usuarios
                     where d.Correo == correo && d.Password == password
                                     select d.Id_Usuario).FirstOrDefault();

                    if (idUsuario > 0)
                    {
                        response = true;
                        return response;
                    }
                    else
                    {
                        return response;
                    }
                }
            }
            catch (Exception x)
            {

                throw;
            }

            AutenticacionDAO dao = new AutenticacionDAO();
           return dao.checkUsuario(correo, password);

        }
    }
}