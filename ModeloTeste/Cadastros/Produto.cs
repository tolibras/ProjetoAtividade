using ModeloTeste.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeloTeste.Cadastros
{
    public class Produto 
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }
        public long? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}