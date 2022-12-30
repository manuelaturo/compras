
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
                AutenticacionDAO dao = new AutenticacionDAO();
                return dao.checkUsuario(correo, password);
            }
            catch (Exception x)
            {

                throw;
            }
        }
    }
}