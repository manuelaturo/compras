using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models
{
    public class Usuario
    {
        public int noEmpledo { get; set; }
        public string nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public int Rol { get; set; }
        public string Contraseña { get; set; }
        public string curp { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string email { get; set; }

        public string ubicacion { get; set; }
        public int? status { get; set; }
        public string Compañia { get; set; }

        public string password { get; set; }
        public int perfil { get; set; }

    }
}