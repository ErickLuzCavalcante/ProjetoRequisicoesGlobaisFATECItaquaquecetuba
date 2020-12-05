using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace requisicoesGlobais.Models
{
	public class Cnn
	{

		/*
         * Classe de conexao ao banco de dados
         * Erick Luz Cavalcante
         * 
         */

		// String de conexao, inidica como o sistema deve conectar ao banco de dados
		private string stringConexao = "Data Source=DESKTOP-KANJINS\\SQLEXPRESS;Initial Catalog=db_aap_sistemas_integrados;Integrated Security=True";


		public SqlDataReader reader;


		public Boolean Entrada(String ComandoSQL)
		{
			try
			{
				// Cria um objeto de conexao com o banco de dados
				SqlConnection conn = new SqlConnection(this.stringConexao);
				// envia o comando
				SqlCommand comando = new SqlCommand(ComandoSQL, conn);
				//abre a conexao
				conn.Open();
				//executa o comando com os parametros que foram adicionados acima
				comando.ExecuteNonQuery();
				//fecha a conexao
				conn.Close();
				Debug.WriteLine("Comando executado com sucesso");
				Debug.WriteLine(ComandoSQL);
				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine("Falha ao executar o comando SQL");
				Debug.WriteLine(ComandoSQL);
				return false;
			}
		}
		// Realiza consultas no banco de dados
		public Boolean Saida(String ComandoSQL)
		{
			try
			{
				// Cria um objeto de conexao com o banco de dados
				SqlConnection conn = new SqlConnection(this.stringConexao);
				// envia o comando
				SqlCommand comando = new SqlCommand(ComandoSQL, conn);
				//abre a conexao
				conn.Open();
				//executa o comando com os parametros que foram adicionados acima
				this.reader = comando.ExecuteReader();
				reader.Read();
				Debug.WriteLine("Comando executado com sucesso");
				Debug.WriteLine(ComandoSQL);
				//conn.Close();
				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Falha ao executar o comando SQL");
				Debug.WriteLine(ComandoSQL);
				return false;
			}
		}
		// Metodo auxiliar utilizado para selecionar o atributo no no banco de dados
		public String GetAtributo(String Atributo)
		{
			try
			{
				Debug.WriteLine("Buscando: " + Atributo);
				return this.reader[Atributo].ToString();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Falha ao buscar atributo");
				return "";
			}

		}


		// Passa para o proximo registro do banco de dados
		// Quando retorna false, significa que chegou no fim da tabela
		public Boolean carregarRegistro()
		{
			return this.reader.Read();
		}
	}
}