using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using requisicoesGlobais.Classes;

namespace requisicoesGlobais.Controllers
{
    public class RequerimentoController : Controller
    {
        // GET: Requerimento
        public ActionResult Requerimento()
        {
            return View();
        }
    }
}