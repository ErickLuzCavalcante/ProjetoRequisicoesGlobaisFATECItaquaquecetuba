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
		public ActionResult Login(Usuarios usuario)
		{

			DBUsuario db = new DBUsuario();
			var usuarioRetorno = db.buscarUsuario(usuario);



			if (usuarioRetorno != null)
			{
				Session["Usuario"] = usuarioRetorno;
				return Redirect("Requerimento/Requerimento");
			}
			else
			{
				var teste = usuario;
			}
			return View();
		}

	





	}
}