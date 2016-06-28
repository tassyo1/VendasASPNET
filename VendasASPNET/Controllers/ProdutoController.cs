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

            ViewBag.Produto = new Produto
            {
                Categoria = new Categoria()
            };
            return View(categorias);
        }

        
        public ActionResult Adiciona(Produto produto)
        {
            int idInformatica = 1;
            if (produto.Categoria.ID.Equals(idInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da" +
                    " categoria informática devem custar pelo menos 100 reais");
            }
            Contexto contexto = new Contexto();
            if (ModelState.IsValid)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                contexto.Dispose();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                IList<Categoria>categorias = contexto.Categorias.OrderBy(c => c.Nome).ToList();
                return View("Form", categorias);
            }
        }
    }
}