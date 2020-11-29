using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
	public class Requerimento
	{
		public int id_requerimento;
		public int id_tp_requerimento;
		public String trancamento_matricula;
		public String justificativa_requerimento;
		public int id_aluno;

		// Métodos GETs
		public int getId_requerimento()
		{
			return this.id_requerimento;
		}
		public int getId_tp_requerimento()
		{
			return this.id_tp_requerimento;
		}
		public String getTrancamento_matricula()
		{
			return this.trancamento_matricula;
		}
		public String getJustificativa_requerimento()
		{
			return this.justificativa_requerimento;
		}
		public int getId_aluno()
		{
			return this.id_aluno;
		}

		// Métodos SETs
		public void setId_requerimento(int id_requerimento)
		{
			this.id_requerimento = id_requerimento;
		}
		public void setId_tp_requerimetno(int id_tp_requerimento)
		{
			this.id_tp_requerimento = id_tp_requerimento;
		}
		public void setTrancamento_matricula(string trancamento_matricula)
		{
			this.trancamento_matricula = trancamento_matricula;
		}
		public void setJustificativa_requerimento(string justificativa_requerimento)
		{
			this.justificativa_requerimento = justificativa_requerimento;
		}
		public void setId_aluno(int id_aluno)
		{
			this.id_aluno = id_aluno;
		}

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
		public void negar_requerimento()
		{

		}

	}
}