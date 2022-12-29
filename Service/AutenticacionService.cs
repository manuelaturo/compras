﻿using System;
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
                using (Datos.ComedorEntities context = new Datos.ComedorEntities())
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
        }
    }
}