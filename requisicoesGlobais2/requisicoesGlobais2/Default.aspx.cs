﻿using System;
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
            /*
            usuario.setCpf_usuario("41856915580");
            usuario.setSenha_usuario("123456789Senh");
            usuario.verificaLogin();
            */
            //Response.Write("<script>alert('" + usuario.verificaLogin() + "')</script>");

            Classes.Requerimentos requerimentos = new Classes.Requerimentos();

            requerimentos.setId_tp_requerimetno(1);
            requerimentos.setJustificativa_requerimento("Requerimento teste");
            requerimentos.setTrancamento_matricula("Teste");
            requerimentos.setId_aluno(1);
            requerimentos.criar_requerimento();



        }
    }
}