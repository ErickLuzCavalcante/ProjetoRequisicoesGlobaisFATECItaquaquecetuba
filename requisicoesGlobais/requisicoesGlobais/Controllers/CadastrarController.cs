using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Models;

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
			
				usuarios.cadastrar_usuario();
				usuarios.consultar_usuario();
				usuarios.id_usuario = usuarios.id_login;
				usuarios.cadastrar_aluno();


				//banco.cadastro(usuarios);
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