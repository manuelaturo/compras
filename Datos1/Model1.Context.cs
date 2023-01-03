﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace compras.Datos1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ComedorEntities1 : DbContext
    {
        public ComedorEntities1()
            : base("name=ComedorEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cat_Comedor> Cat_Comedor { get; set; }
        public virtual DbSet<Cat_Estatus> Cat_Estatus { get; set; }
        public virtual DbSet<Cat_Roles> Cat_Roles { get; set; }
        public virtual DbSet<Invitado> Invitado { get; set; }
        public virtual DbSet<Kit> Kit { get; set; }
        public virtual DbSet<Kit_Producto> Kit_Producto { get; set; }
        public virtual DbSet<Orden_Compra_Producto> Orden_Compra_Producto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Reporte_Comedor> Reporte_Comedor { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Orden_Compra> Orden_Compra { get; set; }
    
        public virtual int AddEmpleado(string correo, string nombre, string apellido_Paterno, string apellido_Materno, string password, Nullable<int> perfil, Nullable<System.DateTime> fecha_Nacimiento, string curp, Nullable<int> numero_Empleado, string ubicacion, Nullable<int> status, string compañia)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido_PaternoParameter = apellido_Paterno != null ?
                new ObjectParameter("Apellido_Paterno", apellido_Paterno) :
                new ObjectParameter("Apellido_Paterno", typeof(string));
    
            var apellido_MaternoParameter = apellido_Materno != null ?
                new ObjectParameter("Apellido_Materno", apellido_Materno) :
                new ObjectParameter("Apellido_Materno", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var perfilParameter = perfil.HasValue ?
                new ObjectParameter("Perfil", perfil) :
                new ObjectParameter("Perfil", typeof(int));
    
            var fecha_NacimientoParameter = fecha_Nacimiento.HasValue ?
                new ObjectParameter("Fecha_Nacimiento", fecha_Nacimiento) :
                new ObjectParameter("Fecha_Nacimiento", typeof(System.DateTime));
    
            var curpParameter = curp != null ?
                new ObjectParameter("Curp", curp) :
                new ObjectParameter("Curp", typeof(string));
    
            var numero_EmpleadoParameter = numero_Empleado.HasValue ?
                new ObjectParameter("Numero_Empleado", numero_Empleado) :
                new ObjectParameter("Numero_Empleado", typeof(int));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("ubicacion", ubicacion) :
                new ObjectParameter("ubicacion", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            var compañiaParameter = compañia != null ?
                new ObjectParameter("Compañia", compañia) :
                new ObjectParameter("Compañia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddEmpleado", correoParameter, nombreParameter, apellido_PaternoParameter, apellido_MaternoParameter, passwordParameter, perfilParameter, fecha_NacimientoParameter, curpParameter, numero_EmpleadoParameter, ubicacionParameter, statusParameter, compañiaParameter);
        }
    
        public virtual int DeleteEmpleado(Nullable<int> numero_Empleado)
        {
            var numero_EmpleadoParameter = numero_Empleado.HasValue ?
                new ObjectParameter("Numero_Empleado", numero_Empleado) :
                new ObjectParameter("Numero_Empleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteEmpleado", numero_EmpleadoParameter);
        }
    
        public virtual ObjectResult<getUsuarios_Result> getUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUsuarios_Result>("getUsuarios");
        }
    
        public virtual ObjectResult<getUsuariosbynoEmpleado_Result> getUsuariosbynoEmpleado(Nullable<int> noEmpleado)
        {
            var noEmpleadoParameter = noEmpleado.HasValue ?
                new ObjectParameter("noEmpleado", noEmpleado) :
                new ObjectParameter("noEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUsuariosbynoEmpleado_Result>("getUsuariosbynoEmpleado", noEmpleadoParameter);
        }
    
        public virtual int UpDateEmpleado(string correo, string nombre, string apellido_Paterno, string apellido_Materno, string password, Nullable<int> perfil, Nullable<System.DateTime> fecha_Nacimiento, string curp, Nullable<int> numero_Empleado, string ubicacion, Nullable<int> status, string compañia)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellido_PaternoParameter = apellido_Paterno != null ?
                new ObjectParameter("Apellido_Paterno", apellido_Paterno) :
                new ObjectParameter("Apellido_Paterno", typeof(string));
    
            var apellido_MaternoParameter = apellido_Materno != null ?
                new ObjectParameter("Apellido_Materno", apellido_Materno) :
                new ObjectParameter("Apellido_Materno", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var perfilParameter = perfil.HasValue ?
                new ObjectParameter("Perfil", perfil) :
                new ObjectParameter("Perfil", typeof(int));
    
            var fecha_NacimientoParameter = fecha_Nacimiento.HasValue ?
                new ObjectParameter("Fecha_Nacimiento", fecha_Nacimiento) :
                new ObjectParameter("Fecha_Nacimiento", typeof(System.DateTime));
    
            var curpParameter = curp != null ?
                new ObjectParameter("Curp", curp) :
                new ObjectParameter("Curp", typeof(string));
    
            var numero_EmpleadoParameter = numero_Empleado.HasValue ?
                new ObjectParameter("Numero_Empleado", numero_Empleado) :
                new ObjectParameter("Numero_Empleado", typeof(int));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("ubicacion", ubicacion) :
                new ObjectParameter("ubicacion", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            var compañiaParameter = compañia != null ?
                new ObjectParameter("Compañia", compañia) :
                new ObjectParameter("Compañia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpDateEmpleado", correoParameter, nombreParameter, apellido_PaternoParameter, apellido_MaternoParameter, passwordParameter, perfilParameter, fecha_NacimientoParameter, curpParameter, numero_EmpleadoParameter, ubicacionParameter, statusParameter, compañiaParameter);
        }
    }
}