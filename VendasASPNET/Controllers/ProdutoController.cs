using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasASPNET.DAO;
using VendasASPNET.Models;


namespace VendasASPNET.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            Contexto contexto = new Contexto();
            IList<Produto> produtos = contexto.Produtos.OrderBy(p => p.Nome).ToList();
            contexto.Dispose();
            return View(produtos);
        }

        public ActionResult Form()
        {
            Contexto contexto = new Contexto();
            IList<Categoria> categorias = contexto.Categorias.OrderBy(c => c.Nome).ToList();
            contexto.Dispose();
            return View(categorias);
        }

        public ActionResult Adiciona(Produto p)
        {
            Contexto contexto = new Contexto();
            

            contexto.Produtos.Add(p);
            contexto.SaveChanges();
            contexto.Dispose();

            return RedirectToAction("Index");

        }
    }
}