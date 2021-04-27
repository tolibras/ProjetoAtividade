﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Cadastros;

namespace Modelo.Tabelas
{
    public class Categoria
    {
        public long? CategoriaId { get; set; }
        public string Nome { get; set; }
        public long? ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}