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
          /*  Classes.Cursos curso = new Classes.Cursos();
            
            curso.listar_todos_curso();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");
            curso.proximo();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");
          */
            
            Classes.Usuarios usuario = new Classes.Usuarios();

            //usuario.setId_login(1);
            //usuario.consultar_usuario();
            //Response.Write("<script>alert('" + usuario.getCpf_usuario() + "')</script>");

            Classes.Alunos alunos = new Classes.Alunos();

            //alunos.set_id_usuario(usuario.getId_login());



            //alunos.cadastrar_aluno();

            usuario.setCpf_usuario("111");
            usuario.setSenha_usuario("1111");
            usuario.verificaLogin();

            Response.Write("<script>alert('" + alunos.get_ra_aluno() + "')</script>");


        }
    }
}