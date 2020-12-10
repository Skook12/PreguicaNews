using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PreguicaNews
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute( //Pagina de Jogos
                name: "Jogos",
                url: "Jogos/MostrarJogos/666",
                defaults: new { controller = "Jogos", action = "MostrarJogos", id = 1212}
            );
            routes.MapRoute( //Pagina de Mangas
                name: "Manga",
                url: "Manga/MostrarManga/666",
                defaults: new { controller = "Jogos", action = "MostrarJogos", id = 1212 }
            );

        }
    }
}
