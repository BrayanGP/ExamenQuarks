﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen_Quarks
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModeloData : DbContext
    {
        public ModeloData()
            : base("name=ModeloData")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<domicilio> domicilio { get; set; }
        public virtual DbSet<DomicilioConsulta> DomicilioConsulta { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<contacto> contacto { get; set; }
    }
}
