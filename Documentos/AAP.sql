-- 1º Cria o banco de dados
create database db_aap_sistemas_integrados; 
-- 2º 'usa' o banco
use db_aap_sistemas_integrados;
-- 3º Cria as tabelas do banco
create table tipo_requerimento (
	id_tp_requerimento integer PRIMARY KEY,
	desc_tp_requerimento varchar(320) NOT NULL
);

create table requerimento(
	id_requerimento integer IDENTITY(1,1) PRIMARY KEY,
	id_tp_requerimento integer NOT NULL,
	trancamento_matricula varchar(400),
	justificativa_requerimento TEXT NOT NULL,
	id_aluno integer NOT NULL
);

create table arquivo(
	id_arquivo integer IDENTITY(1,1) PRIMARY KEY,
	descricao_arquivo varchar(40) NOT NULL,
	arquivo text NOT NULL,
	id_requerimento integer NOT NULL
);

create table curso(
	id_curso integer PRIMARY KEY,
	nome_curso varchar(80) NOT NULL
);

create table aluno(
	id_aluno integer IDENTITY(1,1) PRIMARY KEY,
	ra_aluno varchar (15) NOT NULL UNIQUE,
	turno_aluno varchar (20) NOT NULL,
	id_curso integer NOT NULL,
	id_usuario integer UNIQUE NOT NULL
);

create table usuario(
	id_usuario integer IDENTITY(1,1) PRIMARY KEY,
	nome_usuario varchar(60) NOT NULL,
	email_usuario varchar(320) UNIQUE NOT NULL,
	cpf_usuario varchar(11) UNIQUE NOT NULL,
	telefone_usuario text NOT NULL,
	senha_usuario text NOT NULL,
	data_criacao_usuario date NOT NULL,
	data_atualizacao_usuario date,
	status_usuario integer NOT NULL
);

-- 4º Altera as tabelas para criar as chaves estrangeiras
ALTER TABLE requerimento
   ADD CONSTRAINT FK_requerimento_tipoRequerimento FOREIGN KEY (id_tp_requerimento)
      REFERENCES tipo_requerimento (id_tp_requerimento)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE arquivo
   ADD CONSTRAINT FK_arquivo_requerimento FOREIGN KEY (id_requerimento)
      REFERENCES requerimento (id_requerimento)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE aluno
   ADD CONSTRAINT FK_aluno_curso FOREIGN KEY (id_curso)
      REFERENCES curso (id_curso)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE requerimento
   ADD CONSTRAINT FK_requerimento_aluno FOREIGN KEY (id_aluno)
      REFERENCES aluno (id_aluno)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE aluno
   ADD CONSTRAINT FK_aluno_usuario FOREIGN KEY (id_usuario)
      REFERENCES usuario (id_usuario)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;
