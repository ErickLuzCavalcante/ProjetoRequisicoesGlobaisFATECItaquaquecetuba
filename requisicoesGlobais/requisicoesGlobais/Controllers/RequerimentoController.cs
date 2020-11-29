using System;
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

                var db = new DBRequerimento();

                var tipos = db.buscarTipos();

                return View();
            }

            return Redirect("Login");

        }
    }
}