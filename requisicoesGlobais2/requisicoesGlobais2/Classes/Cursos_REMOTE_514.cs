using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace requisicoesGlobais2.Classes
{
    public class Cursos
    {
        /*
         * Classe de Controle de Cursos
         * Classse voltada para inserir, alterar, excluir e pesquisar um curso  no banco de dados
        */

        // Atributos
        private int id_curso { get; set; }
        private String Nome_curso;

        // GETs

        public String getNome_curso()
        {
            return this.Nome_curso;
        }

        public int getId_curso()
        {
            return this.id_curso;
        }


        // SETs
        public void setNome_curso(String Nome_curso)
        {
            this.Nome_curso = Nome_curso;
        }

        public void setId_curso(int id_curso)
        {
            this.id_curso = id_curso;
        }

        // Metodos
        public void cadastrar_curso()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            string comandoDeInsercao = "INSERT INTO curso (nome_curso) VALUES('" + this.Nome_curso + "')";

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);

        }

        public void alterar_curso()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            /* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

            string comandoDeInsercao = "UPDATE curso " +
                                       "SET nome_curso = '" + getNome_curso() + "'" +
                                       " WHERE id_curso = " + getId_curso();

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);
        }

        private Classes.Cnn bancoDados = new Classes.Cnn();

        public void listar_todos_curso()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            /* -> O que o Comando SQL faz?
             * O comando irá usar o valor do getId_curso para selecionar 
             * a linha e alterar o Nome_curso 
             * pelo valor inserido no getNome_curso() 
             */

            string comandoSelecao = "SELECT " +
                                       "id_curso,nome_curso " +
                                       "FROM curso";

            //Realiza o comando no banco de dados
            bancoDados.Saida(comandoSelecao);
            this.AtualizarCampos();

        }

        public void proximo()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            bancoDados.carregarRegistro();
            this.AtualizarCampos();
        }

        private void AtualizarCampos()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            Nome_curso = bancoDados.GetAtributo(1);
            id_curso = int.Parse(bancoDados.GetAtributo(0));
        }
    }
}