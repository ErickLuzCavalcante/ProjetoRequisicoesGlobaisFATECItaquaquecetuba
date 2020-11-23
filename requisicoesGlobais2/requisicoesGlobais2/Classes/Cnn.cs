﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace requisicoesGlobais2.Classes
{
    public class Cnn
    {

        /*
         * Classe de conexao ao banco de dados
         * Erick Luz Cavalcante
         * 
         */

        // String de conexao, inidica como o sistema deve conectar ao banco de dados
        private string stringConexao = "Data Source=localhost;Initial Catalog=db_aap_sistemas_integrados;Integrated Security=True";


        public SqlDataReader reader;


        public Boolean Entrada(String ComandoSQL)
        {
            try
            {
                // Cria um objeto de conexao com o banco de dados
                SqlConnection conn = new SqlConnection(this.stringConexao);
                // envia o comando
                SqlCommand comando = new SqlCommand(ComandoSQL, conn);
                //abre a conexao
                conn.Open();
                //executa o comando com os parametros que foram adicionados acima
                comando.ExecuteNonQuery();
                //fecha a conexao
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Saida(String ComandoSQL)
        {

            // Cria um objeto de conexao com o banco de dados
            SqlConnection conn = new SqlConnection(this.stringConexao);
            // envia o comando
            SqlCommand comando = new SqlCommand(ComandoSQL, conn);
            //abre a conexao
            conn.Open();
            //executa o comando com os parametros que foram adicionados acima
            this.reader = comando.ExecuteReader();
            reader.;
            
            conn.Close();

        }

        public String GetAtributo(int indiceAtributo)
        {
            return String.Format("{0}", this.reader.GetValue(indiceAtributo));
        }

        public void carregarRegistro()
        {
             this.reader.NextResult();
        }
    }
}
