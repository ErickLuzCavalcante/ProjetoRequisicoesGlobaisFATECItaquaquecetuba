using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace requisicoesGlobais2.Classes
{
    public class Alunos
    {
        // Atributos com get e set
        private int id_aluno;
        private String ra_aluno;
        private String turno_aluno;
        private int id_curso;
        private int id_usuario;


        //GETs 

        public int get_id_aluno()
        {
            return this.id_aluno;
        }

        public String get_ra_aluno()
        {
            return this.ra_aluno;
        }
        public String get_turno_aluno()
        {
            return this.turno_aluno;
        }
        public int get_id_curso()
        {
            return this.id_curso;
        }
        public int get_id_usuario()
        {
            return this.id_usuario;
        }

        //SETs 
        public void set_id_aluno(int id_aluno)
        {
            this.id_aluno = id_aluno;
        }

        public void set_ra_aluno(String ra_aluno)
        {
            this.ra_aluno = ra_aluno;
        }

        public void set_turno_aluno(String turno_aluno)
        {
            this.turno_aluno = turno_aluno;
        }

        public void set_id_curso(int id_curso)
        {
            this.id_curso = id_curso;
        }

        public void set_id_usuario(int id_usuario)
        {
            this.id_usuario = id_usuario;
        }


        // Metodos
        public void cadastrar_aluno()
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            string comandoDeInsercao = "INSERT INTO aluno (ra_aluno, turno_aluno, id_curso, id_usuario) VALUES" +
                                                         "('" + ra_aluno + "', '" + turno_aluno + "', " + id_curso + ", " + id_usuario + ")";

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);

        }

        public void alterar_aluno(String RA)
        {
            // Cria o objeto que controla o banco de dados
            Classes.Cnn bancoDados = new Classes.Cnn();

            // Comando que sera passado para o banco de dados
            string comandoDeInsercao = "UPDATE aluno " +
                "SET ra_aluno = ra_aluno," +
                               "turno_aluno = turno_aluno," +
                               "id_curso = id_curso," +
                               "id_usuario = id_usuario" +
                               "WHERE < Crit�rios de Pesquisa,,> ";

            //Realiza o comando no banco de dados
            bancoDados.Entrada(comandoDeInsercao);

        }



    }









}
