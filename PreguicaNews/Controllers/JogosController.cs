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
    public class JogosController : Controller
    {
        // GET: Jogos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarJogos()//funcao que ira mostrar a lista de itens na tela
        {
            List<EntertainmentModel> jogos = new List<EntertainmentModel>();//lista onde sera armazenada os itens

            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();

            jogos = entertainmentDAO.FetchAll(0);//para saber sobre o FetchALL olhe a classe entertainmentDAO

            return View("MostrarJogos", jogos);//retorna a lista
        }
        public ActionResult Details(int id)//funcao que ira mostrar os detalhes sobre um item
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            EntertainmentModel entertainment = entertainmentDAO.FetchOne(id,0);//para saber sobre o FetchOne olhe a classe entertainmentDAO
            return View("Details", entertainment);
        }
        public ActionResult Create()//Ira encaminhar para a pagina EntertainmentForm
        {
            return View("EntertainmentForm");
        }

        public ActionResult Pcreate(EntertainmentModel entertainmentModel)//funcao que ira criar um novo item e adiciona-lo a base de dados
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            entertainmentDAO.Create(entertainmentModel,0);//para saber sobre o Create olhe a classe entertainmentDAO
            return View("Details", entertainmentModel);
        }
        public ActionResult Delete(int id)//funcao que ira deletar um item do banco de dados
        {
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            entertainmentDAO.Delete(id,0);//para saber sobre o Delete olhe a classe entertainmentDAO
            List<EntertainmentModel> entertainments = entertainmentDAO.FetchAll(0);
            return View("MostrarJogos", entertainments);
        }
        public ActionResult SearchForm()//Ira encaminhar para a pagina SearchForm
        {

            return View("SearchForm");
        }

        public ActionResult SearchForEntertainment(string searchWord)//funcao que ira procurar um item no banco
        {
            //pega uma lista com os resultados da database
            EntertainmentDAO entertainmentDAO = new EntertainmentDAO();
            List<EntertainmentModel> searchResults = entertainmentDAO.SearchForEntertainment(searchWord,0);
            return View("MostrarJogos", searchResults);
        }
    }
}