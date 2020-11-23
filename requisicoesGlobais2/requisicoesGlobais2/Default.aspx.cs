using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace requisicoesGlobais2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            /*Area de teste*/
            Classes.Cursos curso = new Classes.Cursos();
            curso.listar_todos_curso();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");
            curso.proximo();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");

        }
    }
}