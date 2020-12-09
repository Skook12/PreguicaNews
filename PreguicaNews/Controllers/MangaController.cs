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
            //String Nome= "", Nota, Resumo, Imagem;
            //SqlConnection ligacao = new SqlConnection();
            //ligacao.ConnectionString = @"Server = localhost\SQLEXPRESSS; Database = GameDB; Trusted_Connection = True";
            //ligacao.Open();

            //SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Games", ligacao);
            //DataTable dados = new DataTable();
            //adaptador.Fill(dados);
            //foreach( DataRow linha in dados.Rows)
            //{
            //    Nome = linha["Nome"].ToString();
            //    Nota = linha["Nota"].ToString();
            //    Resumo = linha["Resumo"].ToString();
            //    Imagem = linha["Imagem"].ToString();
            //    return Content(Nome);
            //}
            //return Content(Nome);
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
    }
}