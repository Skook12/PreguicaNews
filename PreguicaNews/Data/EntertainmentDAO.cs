using PreguicaNews.Models;
using System;
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
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD +"; Trusted_Connection = True";
            ligacao.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM "+tipoS, ligacao);
            DataTable dados = new DataTable();
            adaptador.Fill(dados);
       
            //colacando os dados na lista
            
            foreach (DataRow linha in dados.Rows)
            {
                EntertainmentModel entertainmentModel = new EntertainmentModel();
                entertainmentModel.Id = Int32.Parse(linha["Id"].ToString());
                entertainmentModel.Nome = linha["Nome"].ToString();
                entertainmentModel.Nota = linha["Nota"].ToString();
                entertainmentModel.Resumo = linha["Resumo"].ToString();
                entertainmentModel.Imagem = linha["Imagem"].ToString();
                returnList.Add(entertainmentModel);
            }

            return returnList;
        }
        public EntertainmentModel FetchOne(int Id , int tipo)
        {
            //acessando a database
            SqlConnection ligacao = new SqlConnection();
            string tipoD = "", tipoS = "";
            if (tipo == 0)
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }
            else if (tipo == 1)
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";
            ligacao.Open();
            //Associando o @id com o Id
            SqlCommand command = new SqlCommand("SELECT * FROM " +tipoS+" WHERE Id = @id", ligacao);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;


            SqlDataReader reader = command.ExecuteReader();
            EntertainmentModel entertainmentModel = new EntertainmentModel();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entertainmentModel.Id = reader.GetInt32(0);
                    entertainmentModel.Nome = reader.GetString(1);
                    entertainmentModel.Nota = reader.GetString(2);
                    entertainmentModel.Resumo = reader.GetString(3);
                    entertainmentModel.Imagem = reader.GetString(4);
                }
            }


            return entertainmentModel;
        }
        public int Create(EntertainmentModel entertainmentModel, int tipo)
        {
            //acessando a database
            SqlConnection ligacao = new SqlConnection();
            string tipoD = "", tipoS = "";
            if (tipo == 0)
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }
            else if (tipo == 1)
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";
            ligacao.Open();
            //Associando o @id com o Id
            SqlCommand command = new SqlCommand("INSERT INTO  dbo."+tipoS+" Values(@Nome,@Nota,@Resumo,@Imagem)", ligacao);
            command.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Nome;
            command.Parameters.Add("@Nota", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Nota;
            command.Parameters.Add("@Resumo", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Resumo;
            command.Parameters.Add("@Imagem", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Imagem;

            int newId = command.ExecuteNonQuery();


            return newId;
        }
    }
}