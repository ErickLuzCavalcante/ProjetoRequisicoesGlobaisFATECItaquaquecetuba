using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace requisicoesGlobais.Classes
{
	public class DB
	{
		// Classe que esta sendo utilizada para o cadastro dos usuarios 
		public string conexao()
		{
			// alterar data source de acordo com cada computador 
			string stringConexao = @"Data Source=NT-SP-TI-06584\SQLEXPRESS;Initial Catalog=db_aap_sistemas_integrados;Integrated Security=True"; ;

			return stringConexao;
		}
			public string cadastro(Usuarios usuarios) { 
				// Cria um objeto de conexao com o banco de dados
				SqlConnection conn = new SqlConnection(conexao());
				// envia o comando
				SqlCommand comando = new SqlCommand();
				//fecha a conexao
				//conn.Close();
			try
			{
					comando.CommandText = "insert into usuario (id_usuario, nome_usuario," +
					"email_usuario, cpf_usuario, telefone_usuario, senha_usuario, " +
					"data_criacao_usuario, data_atualizacao_usuario, status) values (1 , @nome_usuario, @email_usuario," +
					"@cpf_usuario, @telefone_usuario, @senha_usuario, @data_criacao_usuario, @data_atualizacao_usuario, @status_usuario)";

				//comando.Parameters.Add(new SqlParameter("id_usuario", usuarios.nome_usuario));
				comando.Parameters.Add(new SqlParameter("nome_usuario", usuarios.nome_usuario));
				comando.Parameters.Add(new SqlParameter("email_usuario", usuarios.email_usuario));
				comando.Parameters.Add(new SqlParameter("cpf_usuario", usuarios.cpf_usuario));
				comando.Parameters.Add(new SqlParameter("telefone_usuario", usuarios.telefone_usuario));
				comando.Parameters.Add(new SqlParameter("senha_usuario", usuarios.senha_usuario));
				comando.Parameters.Add(new SqlParameter("data_criacao_usuario", usuarios.data_criacao_usuario));
				comando.Parameters.Add(new SqlParameter("data_atualizacao_usuario", usuarios.data_atualizacao_usuario));
				comando.Parameters.Add(new SqlParameter("status_usuario", usuarios.status_usuario));

				//abre a conexao
				comando.Connection = conn;

				conn.Open();
				//executa o comando com os parametros que foram adicionados acima
				int  result = comando.ExecuteNonQuery();

				string mensagem = "";

				if (result == 1)
				{
					mensagem = "Cadastro efetuado";


				}return mensagem;
			}
			catch (Exception ex)
			{
				string mensagem = "Erro " + ex;
				return mensagem;
			}
		}

	}
}

		