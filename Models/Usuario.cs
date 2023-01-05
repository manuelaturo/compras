using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models
{
    public class Usuario
    {
        public int Numero_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Curp { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Correo { get; set; }
        public int Rol { get; set; }
        public string ubicacion { get; set; }
        public int? status { get; set; }
        public string Compania { get; set; }

        public string password { get; set; }
        public int perfil { get; set; }

    }
}