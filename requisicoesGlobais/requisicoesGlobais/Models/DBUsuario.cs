using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace requisicoesGlobais.Models
{
	public class DBUsuario
	{
		// Classe que esta sendo utilizada para o cadastro dos usuarios 
		public string conexao()
		{
			// alterar data source de acordo com cada computador 
			string stringConexao = ConfigurationManager.ConnectionStrings["SistemasIntegrados"].ConnectionString;

			return stringConexao;
		}
		public string cadastro(Usuarios usuarios) { 
			// Cria um objeto de conexao com o banco de dados
			SqlConnection conn = new SqlConnection(conexao());
			// envia o comando
			
			//fecha a conexao
			//conn.Close();
		try
		{
				string command = "insert into usuario (nome_usuario," +
				"email_usuario, cpf_usuario, senha_usuario, " +
				"data_criacao_usuario, data_atualizacao_usuario, status_usuario) values (@nome_usuario, @email_usuario," +
				"@cpf_usuario, @senha_usuario, @data_criacao_usuario, @data_atualizacao_usuario, @status_usuario)";

				SqlCommand comando = new SqlCommand(command, conn);

			//comando.Parameters.Add(new SqlParameter("id_usuario", usuarios.nome_usuario));
			comando.Parameters.Add(new SqlParameter("nome_usuario", usuarios.nome_usuario));
			comando.Parameters.Add(new SqlParameter("email_usuario", usuarios.email_usuario));
			comando.Parameters.Add(new SqlParameter("cpf_usuario", usuarios.cpf_usuario));
			comando.Parameters.Add(new SqlParameter("senha_usuario", usuarios.senha_usuario));
			comando.Parameters.Add(new SqlParameter("data_criacao_usuario", usuarios.data_criacao_usuario));
			comando.Parameters.Add(new SqlParameter("data_atualizacao_usuario", usuarios.data_atualizacao_usuario));
			comando.Parameters.Add(new SqlParameter("status_usuario", usuarios.status_usuario));

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

		public Usuarios buscarUsuario(Usuarios usuarios)
        {

			// Cria um objeto de conexao com o banco de dados
			SqlConnection conn = new SqlConnection(conexao());
			// envia o comando
			string mensagem = "";


			try {
				string command = "select nome_usuario, email_usuario, cpf_usuario, telefone_usuario, data_criacao_usuario, data_atualizacao_usuario, status_usuario from usuario where cpf_usuario = @cpf_usuario and senha_usuario like @senha_usuario";


				using (SqlCommand comando = new SqlCommand(command, conn)) {
					comando.Parameters.Add(new SqlParameter("cpf_usuario", usuarios.cpf_usuario));
					comando.Parameters.Add(new SqlParameter("senha_usuario", usuarios.senha_usuario));

					conn.Open();

					using(SqlDataReader result = comando.ExecuteReader())
                    {
						if (result.Read())
                        {
							var nome_usuario = result.IsDBNull(0) ? null : result.GetString(0);
							var email_usuario = result.IsDBNull(1) ? null : result.GetString(1);
							var cpf_usuario = result.IsDBNull(2) ? null : result.GetString(2);
							var telefone_usuario = result.IsDBNull(3) ? null : result.GetString(3);
							var data_criacao_usuario = result.GetDateTime(4);
							var data_atualizacao_usuario = result.GetDateTime(5);
							var status_usuario = result.IsDBNull(6) ? 0 : result.GetInt32(6);
							Usuarios usuario = new Usuarios()
							{
								nome_usuario = nome_usuario,
								email_usuario = email_usuario,
								cpf_usuario = cpf_usuario,
								telefone_usuario = telefone_usuario,
							//	data_criacao_usuario =  data_atualizacao_usuario,
								//data_atualizacao_usuario = data_atualizacao_usuario,
								status_usuario = status_usuario
							};

							return usuario;
						}
                    }
					
				}
				

				return null;

			} catch(Exception ex) {
				mensagem = "Erro " + ex;
				return null;
			}

			
        }
	}
}

		