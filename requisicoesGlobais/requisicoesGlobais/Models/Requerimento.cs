using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
    public class Requerimento
    {
        public int id_requerimento { get; set; }
        public int id_tp_requerimento { get; set; }
        public string trancamento_matricula { get; set; }
        public string justificativa_requerimento { get; set; }
        public int id_aluno { get; set; }

    }
}