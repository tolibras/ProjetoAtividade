using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo.Tabelas;
using Servico.Tabelas;
using Servico.Cadastros;

namespace ProjetoAtividade.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        // Metodo Privado
        private void PopularViewBag(Categoria categoria = null)
        {
            if (categoria == null)
            {
                ViewBag.ProdutoId = new SelectList(produtoServico.ObterProdutosClassificadosPorNome(),
                "ProdutoId", "Nome");
            }
            else
            {
                ViewBag.ProdutoId = new SelectList(produtoServico.ObterProdutosClassificadosPorNome(),
                "ProdutoId", "Nome", categoria.ProdutoId);
            }
        }
        // Metodo Privado
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }
        // POST: Categorias/Edit
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // GET: Categorias/Edit
        public ActionResult Edit(long? id)
        {
            PopularViewBag(categoriaServico.ObterCategoriaPorId((long)id));
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // POST: Produtos/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}