﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capitu.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ACapituDBEntities : DbContext
    {
        public ACapituDBEntities()
            : base("name=ACapituDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Contato> Contato { get; set; }
        public DbSet<FotosPerfil> FotosPerfil { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Avatar> Avatar { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}