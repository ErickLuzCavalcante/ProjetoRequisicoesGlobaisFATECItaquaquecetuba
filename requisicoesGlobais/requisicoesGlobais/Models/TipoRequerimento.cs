using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace requisicoesGlobais.Models
{
    public class TipoRequerimento
    {
        public int id_tp_requerimento { get; set; }
        public string desc_tp_requerimento { get; set; }

		

		public void cadastrar_tipo_requerimento()
		{
			string[] tipo_requerimento = { "Trancamento", "Historico Escolar", "Abatimento de Materias" };
			for (int i = 0; i < 3; i++)
			{
				id_tp_requerimento = i;
				desc_tp_requerimento = tipo_requerimento[i] ;
		

			Cnn bancoDados = new Cnn();

			// Comando que sera passado para o banco de dados
			string comandoDeInsercao = "INSERT INTO tipo_requerimento (id_tp_requerimento, desc_tp_requerimento) " +
				" VALUES(" + id_tp_requerimento + ",'" + desc_tp_requerimento + "')";

			//Realiza o comando no banco de dados
				bancoDados.Entrada(comandoDeInsercao);
			}
		}
	}
	
}