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
            /*Classes.Cursos curso = new Classes.Cursos();
            
            curso.listar_todos_curso();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");
            curso.proximo();
            Response.Write("<script>alert('" + curso.getNome_curso() + "')</script>");
            */

            Classes.Usuarios usuario = new Classes.Usuarios();


            usuario.setNome_usuario ( "Erick Luz Cavalcante");
            usuario.setEmail_usuario("erick@fatecBolada.com");
            usuario.setCpf_usuario("41856915580");
            usuario.setTelefone_usuario("19982434834");
            usuario.setSenha_usuario("123456789Senha");
            usuario.setData_criacao_usuario(DateTime.Now);
            usuario.setData_atualizacao_usuario(DateTime.Now);
            usuario.setStatus_usuario(1);
            usuario.cadastrar_usuario();
        }
    }
}