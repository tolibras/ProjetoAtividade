using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoAtividade.Models;
using ProjetoAtividade.Context;

namespace ProjetoAtividade.Controllers
{
    public class CategoriaController : Controller
    {
        public Contexto context = new Contexto();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        // GET: Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            categoria.CategoriaId = context.Categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            context.Categorias.Remove(context.Categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            context.Categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        // GET: Details
        public ActionResult Details(long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        // GET: Delete
        public ActionResult Delete(long id)
        {
            return View(context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            context.Categorias.Remove(context.Categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}