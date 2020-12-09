using PreguicaNews.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PreguicaNews.Data;

namespace PreguicaNews.Controllers
{
    public class MangaController : Controller
    {
        // GET: Manga
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MostrarManga()
        {
            List<EntertainmentModel> jogos = new List<EntertainmentModel>();

            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();

            jogos = entertainmentDAO.FetchAll(1);

            return View("MostrarManga", jogos);
            
        }
        public ActionResult Details(int id)
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            EntertainmentModel entertainment = entertainmentDAO.FetchOne(id, 1);
            return View("Details", entertainment);
        }

        public ActionResult Create()
        {
            return View("EntertainmentForm");
        }

        public ActionResult Pcreate(EntertainmentModel entertainmentModel)
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            entertainmentDAO.Create(entertainmentModel,1);
            return View("Details", entertainmentModel);
        }
        public ActionResult Delete(int id)
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            entertainmentDAO.Delete(id, 1);
            List<EntertainmentModel> entertainments = entertainmentDAO.FetchAll(1);
            return View("MostrarManga", entertainments);
        }

        public ActionResult SearchForm()
        {

            return View("SearchForm");
        }

        public ActionResult SearchForEntertainment(string searchWord)
        {
            //pega uma lista com os resultados da database
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            List<EntertainmentModel> searchResults = entertainmentDAO.SearchForEntertainment(searchWord, 1);
            return View("MostrarManga", searchResults);
        }
    }
}