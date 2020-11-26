using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;

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
                Debug.WriteLine("Comando executado com sucesso");
                Debug.WriteLine(ComandoSQL);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Falha ao executar o comando SQL");
                Debug.WriteLine(ComandoSQL);
                return false;
            }
        }
        // Realiza consultas no banco de dados
        public void Saida(String ComandoSQL)
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
                this.reader = comando.ExecuteReader();
                reader.Read();
                Debug.WriteLine("Comando executado com sucesso");
                Debug.WriteLine(ComandoSQL);
                //conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao executar o comando SQL");
                Debug.WriteLine(ComandoSQL);
            }
        }
        // Metodo auxiliar utilizado para selecionar o atributo no no banco de dados
        public String GetAtributo(String Atributo)
        {
            try
            {
                Debug.WriteLine("Buscando: " + Atributo);
                return String.Format("{0}", this.reader[Atributo]);
            }catch (Exception ex)
            {
                Debug.WriteLine("Falha ao buscar atributo");
                return "";
            }
            
        }

        // Passa para o proximo registro do banco de dados
        // Quando retorna false, significa que chegou no fim da tabela
        public Boolean carregarRegistro()
        {
             return this.reader.Read();
        }
    }
}
