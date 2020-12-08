using PreguicaNews.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PreguicaNews.Data
{
    internal class EntertainmentDAO
    {
        //Vai fazer todas as operções da DataBase de entreterimento criar,deletar,pegar...
        public List<EntertainmentModel> FetchAll(int tipo)
        {
            List<EntertainmentModel> returnList = new List<EntertainmentModel>();
            //acessando a database
            SqlConnection ligacao = new SqlConnection();
            string tipoD="",tipoS="";
            if(tipo == 0)
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }else if (tipo == 1)
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = localhost\SQLEXPRESSS; Database = "+tipoD +"; Trusted_Connection = True";
            ligacao.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM "+tipoS, ligacao);
            DataTable dados = new DataTable();
            adaptador.Fill(dados);
            //colacando os dados na lista
            
            foreach (DataRow linha in dados.Rows)
            {
                EntertainmentModel entertainmentModel = new EntertainmentModel();
                entertainmentModel.Nome = linha["Nome"].ToString();
                entertainmentModel.Nota = linha["Nota"].ToString();
                entertainmentModel.Resumo = linha["Resumo"].ToString();
                entertainmentModel.Imagem = linha["Imagem"].ToString();
                returnList.Add(entertainmentModel);
            }

            return returnList;
        }
    }
}