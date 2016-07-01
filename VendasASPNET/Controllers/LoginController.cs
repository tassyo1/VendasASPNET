using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasASPNET.DAO;
using VendasASPNET.Models;
namespace VendasASPNET.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login (Usuario usuario)
        {
            Contexto contexto = new Contexto();
            
            var buscaU = from u in contexto.Usuarios.AsEnumerable()
                         let compara = Criptografia.Compara(usuario.Senha, u.Senha)
                         where u.Nome == usuario.Nome 
                            && compara
                             select u;

            IList<Usuario> lista = buscaU.ToList();

            if (lista.Count == 1)
            {
                Session["usuario"] = usuario;
                return RedirectToRoute("ListaProdutos");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}