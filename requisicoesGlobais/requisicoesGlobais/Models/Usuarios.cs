using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace requisicoesGlobais.Classes
{
	public class Usuarios
	{

        //declaração de variáveis com gets e sets
        private int id_login;
        public string nome_usuario;
        public string email_usuario;
        public string cpf_usuario;
        public string telefone_usuario;
        public string senha_usuario;
        public DateTime data_criacao_usuario;
        public DateTime data_atualizacao_usuario;
        public int status_usuario;

        // Métodos GETs

        public int getId_login()
        {
            return this.id_login;
        }
        public String getNome_usuario()
        {
            return this.nome_usuario;
        }
        public String getEmail_usuario()
        {
            return this.email_usuario;
        }
        public String getCpf_usuario()
        {
            return this.cpf_usuario;
        }
        public String getTelefone_usuario()
        {
            return this.telefone_usuario;
        }
        public String getSenha_usuario()
        {
            return this.senha_usuario;
        }
        public String getData_criacao_usuario()
        {
            return this.data_criacao_usuario;
        }
        public String getData_atualizacao_usuario()
        {
            return this.data_atualizacao_usuario;
        }
        public int getStatus_usuario()
        {
            return this.status_usuario;
        }

        // Métodos SETs
        public void setId_login(int id_login)
        {
            this.id_login = id_login;
        }
        public void setNome_usuario(String nome_usuario)
        {
            this.nome_usuario = nome_usuario;
        }
        public void setEmail_usuario(String email_usuario)
        {
            this.email_usuario = email_usuario;
        }
        public void setCpf_usuario(String cpf_usuario)
        {
            this.cpf_usuario = cpf_usuario;
        }
        public void setTelefone_usuario(String telefone_usuario)
        {
            this.telefone_usuario = telefone_usuario;
        }
        public void setSenha_usuario(String senha_usuario)
        {
            this.senha_usuario = senha_usuario;
        }
        public void setData_criacao_usuario(DateTime data_criacao_usuario)
        {
            this.data_criacao_usuario = data_criacao_usuario;
        }
        public void setData_atualizacao_usuario(DateTime data_atualizacao_usuario)
        {
            this.data_atualizacao_usuario = data_atualizacao_usuario;
        }
        public void setStatus_usuario(int status_usuario)
        {
            this.status_usuario = status_usuario;
        }

        //Métodos da classe
        public void cadastrar_usuario()
		{
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            string comandoDeInsercao = "INSERT INTO usuario (id_usuario, nome_usuario, email_usuario, cpf_usuario, telefone_usuario, " +
                "senha_usuario, data_criacao_usuario, data_atualização_usuario, status_usuario)" +
                " VALUES('" + this.nome_usuario + this.email_usuario + this.cpf_usuario + this.telefone_usuario + this.senha_usuario + 
                this.data_criacao_usuario + this.data_atualizacao_usuario + this.status_usuario "')";

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);
        }
		public void inativar_usuario()
		{
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            string comandoDeInsercao = "UPDATE usuario " +
                                       "SET status_usuario = '" + getStatus_usuario() + "'" +
                                       " WHERE id_usuario = " + getId_login() " AND status_usuario = 0";
        }

        public void consultar_usuario()
		{
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();
            // Comando que sera passado para o banco de dados
            /* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

            string comandoSelecao = "SELECT id_usuario, nome_usuario, email_usuario, cpf_usuario, telefone_usuario, senha_usuario, status_usuario " +
                                       "FROM usuario";

            //Realiza o comando no banco de dados
            bancoDados.Saida(comandoSelecao);
        }
		public void alterar_senha_usuario()
		{
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            string comandoDeInsercao = "UPDATE usuario " +
                                       "SET senha_usuairo = '" + getSenha_usuario() + "'" +
                                       " WHERE id_usuario = " + getId_login();

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);
            this.AtualizarCampos();
        }
        public void proximo()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            bancoDados.carregarRegistro();
            this.AtualizarCampos();
        }

        private void AtualizarCampos()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            id_login = int.Parse(bancoDados.GetAtributo("id_login"));
            nome_usuario = bancoDados.GetAtributo("nome_usuario");
            email_usuario = bancoDados.GetAtributo("email_usuario");
            cpf_usuario = bancoDados.GetAtributo("cpf_usuario");
            telefone_usuario = bancoDados.GetAtributo("telefone_usuario");
            senha_usuario = bancoDados.GetAtributo("senha_usuario");
            data_criacao_usuario = bancoDados.GetAtributo("data_criacao_usuario");
            data_atualizacao_usuario = bancoDados.GetAtributo("data_atualizacao_usuario");
            status_usuario = int.Parse(bancoDados.GetAtributo("status_usuario"));
        }

    }
}
