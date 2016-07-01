using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasASPNET.DAO;
using VendasASPNET.Models;

namespace VendasASPNET.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            Contexto contexto = new Contexto();
            IList<Usuario> usuarios = contexto.Usuarios.ToList();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Usuario usuario)
        {
            Contexto contexto = new Contexto();
            
            if (ModelState.IsValid)
            {
                var senhaCriptografada = Criptografia.Codifica(usuario.Senha);
                usuario.Senha = senhaCriptografada;

                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                contexto.Dispose();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", usuario);
            }
            
        }
    }
}