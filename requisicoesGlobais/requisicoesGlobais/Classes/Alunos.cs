using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace requisicoesGlobais.Classes
{
    public class Alunos <extend>
    {
        // Atributos com geters e seters 
        public String id_aluno { get; set; }
        public String ra_aluno { get; set; }
        public String turno_aluno { get; set; }
        public String id_curso { get; set; }
        public String id_usuario { get; set; }
      
        // Metodos 
        public void cadastrar_aluno()
        {

        }
        public void alterar_aluno()
        {

        }
        public void consultar_aluno()
        {

        }
        public Boolean existe_aluno()
        {
            return true;
        }
    }
    
}