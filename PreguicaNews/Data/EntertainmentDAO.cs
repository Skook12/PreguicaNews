using PreguicaNews.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PreguicaNews.Data
{
    //Vai fazer todas as operções da DataBase de entreterimento criar,deletar,pegar...
    internal class EntertainmentDAO
    {
        /// <summary>
        /// Ele vai pegar todos as informações da database e colocar em uma lista
        /// </summary>
        /// <param name="tipo">Se o tipo for 0 ele vai pegar as informações da database de jogos se for 1 ele vai pegar as de mangas</param>
        /// <returns></returns>
        public List<EntertainmentModel> FetchAll(int tipo)
        {
            List<EntertainmentModel> returnList = new List<EntertainmentModel>();//Lista que será retornada no final da função
            SqlConnection ligacao = new SqlConnection();//acessando a database
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
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD +"; Trusted_Connection = True";//acessando a database
            ligacao.Open();//acessando a database
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM "+tipoS, ligacao);//O adaptador vai peegar todas as informções da lista
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
        /// <summary>
        /// Vai pegar apenas a informação de um item da lista de acordo com o seu id e ira retornar o item
        /// </summary>
        /// <param name="Id">O id do tem que será pego</param>
        /// <param name="tipo">Se o tipo for 0 ele vai pegar as informações da database de jogos se for 1 ele vai pegar as de mangas</param>
        /// <returns></returns>
        public EntertainmentModel FetchOne(int Id , int tipo)
        {
            
            SqlConnection ligacao = new SqlConnection();//acessando a database
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
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";//acessando a database
            ligacao.Open();//acessando a database
            SqlCommand command = new SqlCommand("SELECT * FROM " +tipoS+" WHERE Id = @id", ligacao); //Associando o @id com o Id
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;//Colando o valor de @id 


            SqlDataReader reader = command.ExecuteReader();//Criando um reader com o item id selecionado
            EntertainmentModel entertainmentModel = new EntertainmentModel();
            if (reader.HasRows)
            {
                    reader.Read();
                
                    entertainmentModel.Id = reader.GetInt32(0);
                    entertainmentModel.Nome = reader.GetString(1);
                    entertainmentModel.Nota = reader.GetString(2);
                    entertainmentModel.Resumo = reader.GetString(3);
                    entertainmentModel.Imagem = reader.GetString(4);
                
            }


            return entertainmentModel;
        }
        /// <summary>
        /// Vai procurar uma palavra entre os nomes na database
        /// </summary>
        /// <param name="searchWord">A palavra que vai ser procurada na database</param>
        /// <param name="tipo">Se o tipo for 0 ele vai pegar as informações da database de jogos se for 1 ele vai pegar as de mangas</param>
        /// <returns></returns>
        internal List<EntertainmentModel> SearchForEntertainment(string searchWord,int tipo)
        {
            List<EntertainmentModel> returnList = new List<EntertainmentModel>();//acessando a database
            SqlConnection ligacao = new SqlConnection();//acessando a database
            string tipoD = "", tipoS = "";
            if (tipo == 0)//Data Base de Jogos
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }
            else if (tipo == 1)//Data Base de Manga
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";//acessando a database
            ligacao.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo." + tipoS + " WHERE Nome LIKE @search", ligacao);//Associando o @search com o Id
            command.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%"+searchWord+"%";//Associando @search com searchWord


            SqlDataReader reader = command.ExecuteReader();
            //colacando os dados na lista
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EntertainmentModel entertainmentModel = new EntertainmentModel();
                    entertainmentModel.Id = reader.GetInt32(0);
                    entertainmentModel.Nome = reader.GetString(1);
                    entertainmentModel.Nota = reader.GetString(2);
                    entertainmentModel.Resumo = reader.GetString(3);
                    entertainmentModel.Imagem = reader.GetString(4);
                    returnList.Add(entertainmentModel);
                }
            }

            return returnList;
        }
        /// <summary>
        /// Vai deletar o item no banco com o id passado
        /// </summary>
        /// <param name="id">Id do item</param>
        /// <param name="tipo">Se o tipo for 0 ele vai pegar as informações da database de jogos se for 1 ele vai pegar as de mangas</param>
        /// <returns></returns>
        internal void Delete(int id,int tipo)
        {
            SqlConnection ligacao = new SqlConnection();//acessando a database
            string tipoD = "", tipoS = "";
            if (tipo == 0)//Data Base de Jogos
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }
            else if (tipo == 1)//Data Base de Mangas
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";//acessando a database
            ligacao.Open();//acessando a database
            SqlCommand command = new SqlCommand("DELETE FROM  dbo." + tipoS + " WHERE Id = @Id", ligacao);//Associando o @id com o Id
            command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar).Value = id;//Associando o @id com o Id
            command.ExecuteNonQuery();//executando a ação
        }
        /// <summary>
        /// Ira colocar um novo item na database
        /// </summary>
        /// <param name="entertainmentModel">O item que será colocado na database</param>
        /// <param name="tipo">Se o tipo for 0 ele vai pegar as informações da database de jogos se for 1 ele vai pegar as de mangas</param>
        /// <returns></returns>
        public void Create(EntertainmentModel entertainmentModel, int tipo)
        {
            
            SqlConnection ligacao = new SqlConnection();//acessando a database
            string tipoD = "", tipoS = "";
            if (tipo == 0)//Data Base de Jogos
            {
                tipoD = "GameDB";
                tipoS = "Games";
            }
            else if (tipo == 1)//Data Base de Mangas
            {
                tipoD = "MangaDB";
                tipoS = "Manga";
            }
            ligacao.ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = " + tipoD + "; Trusted_Connection = True";//acessando a database
            ligacao.Open();//acessando a database
            SqlCommand command = new SqlCommand("INSERT INTO  dbo."+tipoS+" Values(@Nome,@Nota,@Resumo,@Imagem)", ligacao);//Está associando os valores @Nome,@Nota,@Resumo e ,@Imagem com os repectivos similares na tabela
            command.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Nome;//Está associando os valor @Nome com o de Nome
            command.Parameters.Add("@Nota", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Nota;//Está associando os valor @Nota com o de Nota
            command.Parameters.Add("@Resumo", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Resumo;//Está associando os valor @Resumo com o de Resumo
            command.Parameters.Add("@Imagem", System.Data.SqlDbType.VarChar).Value = entertainmentModel.Imagem;//Está associando os valor @Imagem com o de Imagem

            command.ExecuteNonQuery();//Ira ira exucutar a ação

        }
    }
}