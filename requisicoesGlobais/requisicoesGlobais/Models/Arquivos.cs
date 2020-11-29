using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
	public class Arquivos
	{
		//Atributos com get e set
		private int id_arquivo { get; set; }
		private string descricao_arquivo { get; set; }
		private string arquivo { get; set; }

		private string id_requerimento { get; set; }

		//Metodos
		public void enviar_novo_arquivo()
		{
			// Cria o objeto que controla o banco de dados
			Models.Cnn bancoDados = new Models.Cnn();
			// Comando que sera passado para o banco de dados
			string comandoDeInsercao = "INSERT INTO arquivo (descricao_arquivo, arquivo, id_requerimento)" +
				" VALUES ('" + this.descricao_arquivo + "','" + this.arquivo + "','" + id_requerimento + "')";
			//Realiza o comando no banco de dados
			bancoDados.Entrada(comandoDeInsercao);
		}
	}
}