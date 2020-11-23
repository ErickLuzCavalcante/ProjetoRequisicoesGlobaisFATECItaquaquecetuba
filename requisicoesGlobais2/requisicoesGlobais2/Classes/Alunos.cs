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
        private String cpf;
        private String nome_aluno;
        private int ra_aluno;


        //SETs 

        public void set_id_aluno(int id) {
            this.id_aluno = id;
        }

        public void set_CPF(String cpf){
            this.cpf = cpf;
        }

        public void set_nome_aluno(String nome){
            this.nome_aluno = nome;
        }

        public void set_ra_aluno(int ra){
            this.ra_aluno = ra;
        }

        //GETs 


        public int get_id_alunos(){
            return this.id_aluno;
        }

        public String get_CPF(){
            return this.cpf;
        }

        public String get_nome_aluno()
        {
            return this.nome_aluno;
        }

        public int get_ra_aluno()
        {
            return this.ra_aluno;
        }


        // Metodos
        public void cadastar_aluno()
        {
            Classes.Cnn banco_Dados = new Classes.Cnn();
            string comando_De_Insercao_De_Alunos = "INSERT INTO aluno(nome_aluno) VALUES('" + this.nome_aluno + "')";
            banco_Dados.Entrada(comando_De_Insercao_De_Alunos);
        }


        public void cadastrar_id() {
            Classes.Cnn banco_Dados = new Classes.Cnn();
            string comando_De_Insercao_De_ID = "INSERT INTO aluno(id_aluno) VALUES('"+this.id_aluno + "')";
            banco_Dados.Entrada(comando_De_Insercao_De_ID);
           
        }

        public void cadastrar_CPF(){
            Classes.Cnn banco_Dados = new Classes.Cnn();
            string comando_De_Insercao_De_CPF = "INSERT INTO aluno(cpf) VALUES('"+this.cpf+"')";
            banco_Dados.Entrada(comando_De_Insercao_De_CPF);
        }

        public void cadastar_RA_Aluno()
        {
            Classes.Cnn banco_Dados = new Classes.Cnn();
            string comando_De_Insercao_De_RA = "ISERT INTO  aluno(ra_aluno) VALUES('" + this.ra_aluno + "')";
            banco_Dados.Entrada(comando_De_Insercao_De_RA);
        }



    }









}
