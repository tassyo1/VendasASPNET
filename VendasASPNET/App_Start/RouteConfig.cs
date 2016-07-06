using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VendasASPNET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ListaProdutos",
                            "produtos",
                            new { controller = "Produto", action = "Index" });

            routes.MapRoute("CriaProdutos",
                             "produtos/novo",
                             new { controller = "Produto", action = "Form" });

            routes.MapRoute("VisualizaProdutos", 
                            "produtos/{id}",
                            new { controller = "Produto", action = "Visualiza" });

            routes.MapRoute("ListaCategorias",
                            "categorias",
                            new { action = "Index", controller = "Categoria" });

            routes.MapRoute("VisualizaCategorias",
                            "categorias/{id}",
                            new { action = "Visualiza", controller = "Categoria" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
