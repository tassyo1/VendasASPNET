using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasASPNET.DAO;
using VendasASPNET.Filtros;
using VendasASPNET.Models;
namespace VendasASPNET.Controllers
{
    [AutenticacaoFilter]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            Contexto contexto = new Contexto();
            IList<Categoria> categorias = contexto.Categorias.OrderBy(c => c.Nome).ToList();
            contexto.Dispose();
            return View(categorias);
        }

        public ActionResult Form()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Categoria categoria)
        {
            Contexto contexto = new Contexto();
            

            if (ModelState.IsValid)
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
                contexto.Dispose();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", categoria);
            }
        }

        public ActionResult Visualiza(int id)
        {
            Contexto contexto = new Contexto();
            Categoria categoria = contexto.Categorias.Find(id);
            return View(categoria);
        }


    }
}