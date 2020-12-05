using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
	public class Requerimento 
	{
		public int id_requerimento { get; set; }
		public int id_tp_requerimento { get; set; }
		public int id_aluno { get; set; }
		public string justificativa_requerimento { get; set; }
		public string trancamento_matricula { get; set; }
		public string arquivo_requerimento { get; set; }



		//Métodos da classe
		public void criar_requerimento()
		{
			// Cria o objeto que controla o banco de dados
			Models.Cnn bancoDados = new Models.Cnn();

			// Comando que sera passado para o banco de dados
			string comandoDeInsercao = "INSERT INTO requerimento (id_tp_requerimento, trancamento_matricula, " +
				"justificativa_requerimento,id_aluno)" +
				" VALUES(" + this.id_tp_requerimento + ",'" + this.trancamento_matricula +
							"','" + this.justificativa_requerimento + "'," + this.id_aluno + ")";

			//Realiza o comando no banco de dados
			bancoDados.Entrada(comandoDeInsercao);
		}
		public void ultimorequerimento()
		{

		}

	}
}