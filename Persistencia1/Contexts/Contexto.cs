using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<Contexto>(
            new DropCreateDatabaseIfModelChanges<Contexto>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}