using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
	public class Cursos
	{
		// Atributos
		public int id_curso { get; set; }
		public string Nome_curso { get; set; }

		/*
         * Classe de Controle de Cursos
         * Classse voltada para inserir, alterar, excluir e pesquisar um curso  no banco de dados
        */

		// Metodos
		public void cadastrar_curso()
		{
			string[] nome_curso = { "GTI", "GCOM", "SEC" };
			for (int i = 0; i < 3; i++)
			{
				id_curso = i;
				Nome_curso = nome_curso[i];


				// Cria o objeto que controla o banco de dados
				Cnn bancoDados = new Cnn();

				// Comando que sera passado para o banco de dados
				string comandoDeInsercao = "INSERT INTO curso (id_curso, nome_curso) " +
					" VALUES(" + id_curso + ",'" + Nome_curso + "')";

				//Realiza o comando no banco de dados
				bancoDados.Entrada(comandoDeInsercao);

			}
		}

		public void alterar_curso()
		{
			// Cria o objeto que controla o banco de dados
			Models.Cnn bancoDados = new Models.Cnn();

			// Comando que sera passado para o banco de dados
			/* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

			string comandoDeInsercao = "UPDATE curso " +
									   "SET nome_curso = '" + id_curso + "'" +
									   " WHERE id_curso = " + Nome_curso;

			//Realiza o comando no banco de dados
			bancoDados.Entrada(comandoDeInsercao);
		}

		private Models.Cnn bancoDados = new Models.Cnn();
		public void listar_todos_curso()
		{
			// Cria o objeto que controla o banco de dados


			// Comando que sera passado para o banco de dados
			/* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

			string comandoSelecao = "SELECT " +
									   "id_curso,nome_curso " +
									   "FROM curso";

			//Realiza o comando no banco de dados
			if (bancoDados.Saida(comandoSelecao))
			{
				this.AtualizarCampos();
			}

		}
		/*Metodos auxiliares de pesquisa*/

		// Pula para o proximo registro
		// Quando chegar a false, significa que chegou no ultimo registro
		// Nao alterar 
		public Boolean proximo()
		{
			if (bancoDados.carregarRegistro())
			{
				this.AtualizarCampos(); // Atualiza os campos confome o registro
				return true;
			}
			else
			{
				return false;
			}

		}
		// Atualizar conforme a classe 
		private void AtualizarCampos()
		{
			// Campos conforme o indice
			Nome_curso = bancoDados.GetAtributo("Nome_curso");
			id_curso = int.Parse(bancoDados.GetAtributo("id_curso"));
		}
	}
}