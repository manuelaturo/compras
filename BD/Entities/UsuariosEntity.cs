﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class UsuariosEntity
    {

        public string noEmpledo { get; set; }
        public string nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string curp { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int perfil { get; set; }

        public UsuariosEntity() { }
        public UsuariosEntity(int noEmpledo, string nombre, 
            string APaterno, string AMaterno, string curp, 
            DateTime fechaNacimiento, string email, string password, int perfil) {

            this.noEmpledo = noEmpledo.ToString();
            this.nombre = nombre;
            this.APaterno = APaterno;
            this.curp = curp;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.AMaterno = AMaterno;
            this.password = password;
            this.perfil =perfil;
        
        }
    }
}