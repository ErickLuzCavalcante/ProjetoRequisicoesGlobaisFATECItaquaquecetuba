@echo off
echo Deletando Banco de dados
sqlcmd -S localhost  -i DeletaBancoDeDados.sql
echo Criando novo Banco de dados
sqlcmd -S localhost  -i CriaBancoDeDados.sql
echo Criando tabelas
sqlcmd -S localhost  -i CriaTabelas.sql
pause 