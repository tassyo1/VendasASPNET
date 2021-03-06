﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasASPNET.DAO;
using VendasASPNET.Models;
using VendasASPNET.Filtros;


namespace VendasASPNET.Controllers
{
    [AutenticacaoFilter]
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

        [ValidateAntiForgeryToken]
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
                IList<Categoria> categorias = contexto.Categorias.OrderBy(c => c.Nome).ToList();
                return View("Form", categorias);
            }
        }

        public ActionResult Visualiza(int id)
        {
            Contexto contexto = new Contexto();
            Produto produto = contexto.Produtos.Find(id);
            return View(produto);
        }

        public ActionResult DecrementaQuantidade(int produtoID)
        {
            Contexto contexto = new Contexto();
            Produto produto = contexto.Produtos.Find(produtoID);
            if (produto.Quantidade > 0)
            {
                produto.Quantidade--;
            }
            contexto.SaveChanges();
            return Json(produto);
        }

        public ActionResult AumentaQuantidade(int produtoID)
        {
            Contexto contexto = new Contexto();
            Produto produto = contexto.Produtos.Find(produtoID);
            produto.Quantidade++;
            contexto.SaveChanges();
            return Json(produto);
        }
    }
}