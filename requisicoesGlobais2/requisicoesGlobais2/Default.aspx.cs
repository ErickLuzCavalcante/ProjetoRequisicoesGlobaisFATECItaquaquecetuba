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
            curso.setId_curso(1);
            curso.setNome_curso("Bolinho");
            curso.alterar_curso();


        }
    }
}