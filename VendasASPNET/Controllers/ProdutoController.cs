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
            return View(produtos);
        }
    }
}