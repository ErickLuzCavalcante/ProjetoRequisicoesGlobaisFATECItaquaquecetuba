﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Models;

namespace requisicoesGlobais.Controllers
{
    public class RequerimentoController : Controller
    {
        // GET: Requerimento
        public ActionResult Requerimento()
        {
            if (Session["Usuario"] != null)
            {

				//var db = new DBRequerimento();
				//var tipos = db.buscarTipos();

				

                return View();
            }else

            return Redirect("Login/Login");

        }
		[HttpPost]
		public ActionResult Enviar(Requerimento requerimento)
		{
            Models.Usuarios usuarios = new Models.Usuarios();
            usuarios.cpf_usuario = Session["Usuario"].ToString();
            usuarios.consultar_usuario();
            usuarios.id_usuario = usuarios.id_login;
            usuarios.listar_por_idUsuario();
            requerimento.id_aluno = usuarios.id_aluno;
            requerimento.criar_requerimento();

			return Redirect("Cadastrar/Cadastrar");
		}
    }
}