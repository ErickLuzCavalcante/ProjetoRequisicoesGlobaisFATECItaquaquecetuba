
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
	public class Alunos
	{
		// Atributos com get e set
		public int id_aluno { get; set; }
		public string ra_aluno { get; set; }
		public int id_curso { get; set; }
		public string turno_aluno { get; set; }
		public int id_usuario { get; set; }


	
		// Metodos
		public void cadastrar_aluno()
		{
			// Cria o objeto que controla o banco de dados
			Models.Cnn bancoDados = new Models.Cnn();

			// Comando que sera passado para o banco de dados
			string comandoDeInsercao = "INSERT INTO aluno (ra_aluno, turno_aluno, id_curso, id_usuario) VALUES" +
														 "('" + ra_aluno + "', '" + turno_aluno + "', " + id_curso + ", " + id_usuario + ")";

			//Realiza o comando no banco de dados
			bancoDados.Entrada(comandoDeInsercao);

		}

		public void alterar_aluno()
		{
			// Cria o objeto que controla o banco de dados
			Models.Cnn bancoDados = new Models.Cnn();

			// Comando que sera passado para o banco de dados
			string comandoDeInsercao = "UPDATE aluno " +
				"SET turno_aluno = '" + turno_aluno + "'," +
							   "id_curso = " + id_curso + "," +
							   "id_usuario = " + id_usuario +
							   "WHERE ra_aluno =" + ra_aluno;

			//Realiza o comando no banco de dados
			bancoDados.Entrada(comandoDeInsercao);

		}

		private Models.Cnn bancoDados = new Models.Cnn();
		public void listar_por_idUsuario()
		{
			// Cria o objeto que controla o banco de dados


			// Comando que sera passado para o banco de dados
			/* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

			string comandoSelecao = "SELECT " +
				"*" +
				" FROM aluno where " +
				"id_usuario = " + id_usuario;
			;

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
			id_aluno = int.Parse(bancoDados.GetAtributo("id_aluno"));
			ra_aluno = bancoDados.GetAtributo("ra_aluno");
			turno_aluno = bancoDados.GetAtributo("turno_aluno");
			id_curso = int.Parse(bancoDados.GetAtributo("id_curso"));
			id_usuario = int.Parse(bancoDados.GetAtributo("id_usuario"));
		}
	}

}