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
			TipoRequerimento tipoRequerimento = new TipoRequerimento();
			Cursos cursos = new Cursos();
			tipoRequerimento.cadastrar_tipo_requerimento();
			cursos.cadastrar_curso();
			return View();
		}
		[HttpPost]
		public ActionResult Login(Usuarios usuario)
		{

			//DBUsuario db = new DBUsuario();
			//var usuarioRetorno = db.buscarUsuario(usuario);
			//-------------------------------------------------
			
			try
			{
				if (usuario.verificaLogin() != false)
				{
						Session["Usuario"] = usuario.cpf_usuario;
						
						return Redirect("Requerimento/Requerimento");
				}

				//Session["Usuario"] = usuarioRetorno;
				//return Redirect("Requerimento/Requerimento");

				else
				{
					
					return View("Login");

					//var teste = usuario;
				}
			}
			catch (Exception ex)
			{
				return View("Login");

			}

			return View();
		}

	





	}
}