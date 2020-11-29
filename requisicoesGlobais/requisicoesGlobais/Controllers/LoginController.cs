using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Controllers;

using requisicoesGlobais.Models;

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

			//DBUsuario db = new DBUsuario();
			//var usuarioRetorno = db.buscarUsuario(usuario);
			//-------------------------------------------------
			Cnn cx = new Cnn();
			Usuarios usuarios = new Usuarios();
			Alunos alunos = new Alunos();
			Requerimento requerimentos = new Requerimento();




			try
			{
				if (usuario.verificaLogin() != false)
				{
					Response.Write("<script>alert('" + usuario.verificaLogin() + "')</script>");
				}

				//Session["Usuario"] = usuarioRetorno;
				//return Redirect("Requerimento/Requerimento");

				else
				{
					Response.Write("Usuario e senha invalidos");
					return View("Login");

					//var teste = usuario;
				}
			}
			catch (Exception ex)
			{
				Response.Write("Usuario e senha invalidos");
				return View("Login");

			}

			return View();
		}

	





	}
}