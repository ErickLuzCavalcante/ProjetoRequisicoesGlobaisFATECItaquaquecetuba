using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requisicoesGlobais.Classes
{
	public class Usuarios
	{
		//declaração de variáveis com gets e sets
		private int id_login { get; set; }
		public int nome_usuario { get; set; }
		public string email_usuario { get; set; }
		public string cpf_usuario { get; set; }
		public string telefone_usuario { get; set; }
		public string senha_usuario { get; set; }
		private DateTime data_criacao_usuario { get; set; }
		private DateTime data_atualizacao_usuario { get; set; }
		private int status_usuario { get; set; }
		public string ra_usuario { get; set; }

		//Métodos get e set das variáveis
		/*
        public int Id_login
        {
            get { return id_login; }
            set { id_login = value; }
        }
        public int Nome_usuario
        {
            get { return nome_usuario; }
            set { nome_usuario = value; }
        }
        public string Email_usuario
        {
            get { return email_usuario; }
            set { email_usuario = value; }
        }
        public string Cpf_usuario
        {
            get { return cpf_usuario; }
            set { cpf_usuario = value; }
        }
        public string Telefone_usuario
        {
            get { return telefone_usuario; }
            set { telefone_usuario = value; }
        }
        public string Senha_usuario
        {
            get { return senha_usuario; }
            set { senha_usuario = value; }
        }
        public DateTime Data_criacao_usuario
        {
            get { return data_criacao_usuario; }
            set { data_criacao_usuario = value; }
        }
        public DateTime Data_atualizacao_usuario
        {
            get { return data_atualizacao_usuario; }
            set { data_atualizacao_usuario = value; }
        }
        public int Status_usuario
        {
            get { return status_usuario; }
            set { status_usuario = value; }
        }
        */
		//Métodos da classe
		public void cadastrar_usuario()
		{

		}
		public void inativar_usuario()
		{

		}

		public void consultar_usuario()
		{

		}
		public void alterar_senha_usuario()
		{

		}

	}
}
