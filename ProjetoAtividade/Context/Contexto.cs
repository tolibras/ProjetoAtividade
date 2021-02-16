using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjetoAtividade.Models;

namespace ProjetoAtividade.Context
{
    public class Contexto : DbContext
    {
    public Contexto() : base("Asp_Net_MVC_CS") { }
    public DbSet<Categoria> Categorias { get; set; }
    }
}