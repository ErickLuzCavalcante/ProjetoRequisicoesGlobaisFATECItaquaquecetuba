using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Controllers;
using requisicoesGlobais.Classes;

namespace requisicoesGlobais.Controllers
{

	public class LoginController : Controller
	{

		// GET: Login
		public ActionResult Login()
		{

			return View();
		}
		[HttpPost]
		public ActionResult Login(Usuarios us)
		{
			if (us.cpf_usuario == "123")
			{

				return Redirect("Requerimento/Requerimento");
			}
			else
			{
				var teste = us;
			}
			return View();
		}
		public ActionResult Cadastro(Usuarios us)
		{
			if (us.cpf_usuario == "123")
			{

				return Redirect("Login/Login");
			}
			else
			{
				var teste = us;
			}
			return View();
		}




	}
}