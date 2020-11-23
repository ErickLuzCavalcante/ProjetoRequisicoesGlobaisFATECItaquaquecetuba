using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Classes;

namespace requisicoesGlobais.Controllers
{
    public class CadastrarController : Controller
    {
        // GET: Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Cadastrar(Usuarios usuarios)
		{
			try
			{
				//instancia a classe do banco de dados 
				DBUsuario banco = new DBUsuario();
				//executando  a função cadastro  

				usuarios.data_criacao_usuario = DateTime.Now;
				usuarios.data_atualizacao_usuario = DateTime.Now;

				banco.cadastro(usuarios);
				return View("../Login/Login");
			}
			catch (Exception ex)
			{
				string mensagem = "Erro " + ex;

				return View("Cadastrar");
			}
		}
	}
}