using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace requisicoesGlobais.Models
{
    public class DBRequerimento
    {
		public string conexao()
		{
			string stringConexao = ConfigurationManager.ConnectionStrings["SistemasIntegrados"].ConnectionString;
			return stringConexao;
		}


		public List<TipoRequerimento> buscarTipos()
		{

			// Cria um objeto de conexao com o banco de dados
			SqlConnection conn = new SqlConnection(conexao());


			try
			{
				string command = "select * from tipo_requerimento;";
				List<TipoRequerimento> tipos = new List<TipoRequerimento>();

				using (SqlCommand comando = new SqlCommand(command, conn))
				{
					conn.Open();
					
					using (SqlDataReader result = comando.ExecuteReader())
					{
						
						while (result.Read())
						{
							var id = result.IsDBNull(0) ? 0 : result.GetInt32(0);
							var descricao = result.IsDBNull(1) ? null : result.GetString(1);
							TipoRequerimento tipo = new TipoRequerimento()
							{
								id_tp_requerimento = id,
								desc_tp_requerimento = descricao
							};

							tipos.Add(tipo);
						}
					}

				}
				return tipos;

			}
			catch (Exception ex)
			{
				return null;
			}


		}

	}
}