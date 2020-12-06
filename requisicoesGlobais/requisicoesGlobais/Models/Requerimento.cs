using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
    public class Requerimento
    {
        public int id_requerimento { get; set; }
		[Required(ErrorMessage = "* Escolha o tipo de requerimento")]
		public int id_tp_requerimento { get; set; }
        public int id_aluno { get; set; }
		[Required(ErrorMessage = "* Digite a Justificativa")]
		public string justificativa_requerimento { get; set; }
        public string trancamento_matricula { get; set; }
        public string arquivo_requerimento { get; set; }

		public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }


		private Models.Cnn bancoDados = new Models.Cnn();


        //Métodos da classe
        public int criar_requerimento()
        {

            // Comando que sera passado para o banco de dados
            string comandoDeInsercao = "INSERT INTO requerimento (id_tp_requerimento, trancamento_matricula, " +
                "justificativa_requerimento,id_aluno)" +
                " VALUES(" + this.id_tp_requerimento + ",'" + this.trancamento_matricula +
                            "','" + this.justificativa_requerimento + "'," + this.id_aluno + "); SELECT SCOPE_IDENTITY() as id_requerimento";

            //Realiza o comando no banco de dados

            if (bancoDados.Saida(comandoDeInsercao))
            {
                if (bancoDados.GetAtributo("id_requerimento") != null)
                {
                    return int.Parse(bancoDados.GetAtributo("id_requerimento"));
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
        /*Metodos auxiliares de pesquisa*/

        // Pula para o proximo registro
        // Quando chegar a false, significa que chegou no ultimo registro
        public Boolean proximo()
        {
            if (bancoDados.carregarRegistro())
            {
                this.AtualizarCampos(); // Atualiza os campos confome o registro
                return true;
            }
            else
            {
                return false;
            }

        }

        private void AtualizarCampos()
        {
            if (bancoDados.GetAtributo("id_requerimento") != null)
            {
                id_requerimento = int.Parse(bancoDados.GetAtributo("id_requerimento"));
                id_tp_requerimento = int.Parse(bancoDados.GetAtributo("id_tp_requerimento"));
                id_aluno = int.Parse(bancoDados.GetAtributo("id_aluno"));
                justificativa_requerimento = bancoDados.GetAtributo("justificativa_requerimento");
                trancamento_matricula = bancoDados.GetAtributo("trancamento_matricula");
                arquivo_requerimento = bancoDados.GetAtributo("arquivo_requerimento");

            }
        }
	

    }
}