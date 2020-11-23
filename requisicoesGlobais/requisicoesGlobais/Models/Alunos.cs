
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Classes
{
	public class Alunos : Usuarios
	{
		// Atributos com geters e seters 
		private string id_aluno { get; set; }
		private string ra_aluno { get; set; }
		private string turno_aluno { get; set; }
		private string id_curso { get; set; }
		private string id_usuario { get; set; }


		// Metodos 
		public void cadastrar_aluno()
		{

		}
		public void alterar_aluno()
		{

		}
		public void consultar_aluno()
		{

		}
		public Boolean existe_aluno()
		{
			return true;
		}
	}

}