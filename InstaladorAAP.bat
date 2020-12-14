@echo off
set link_repositorio="https://github.com/ErickLuzCavalcante/ProjetoRequisicoesGlobaisFATECItaquaquecetuba"
set pastaprojeto=ProjetoRequisicoesGlobaisFATECItaquaquecetuba
cls
Title Instalador Projeto AAP
mode 38,14
echo. Bem vindo ao Instalador de Projetos
echo. -------------------------------------
echo. AAP - Requisicoes Globais da 
echo. FATEC DE ITAQUAQUECETUBA
echo. -------------------------------------
echo ^>^>Requisitos
echo.
echo. + GIT - Atualizado
echo. + Conexao com a internet
echo. + SQLServer
echo.
echo. [Pressione uma tecla para instalar]
pause>nul
cls
echo. Limpando pasta do projeto
echo. -------------------------------------
md C:\git>nul
cd C:\
@cd git
ERASE /S /Q %pastaprojeto%
RD /S /Q %pastaprojeto%
echo [Pressione uma tecla para continuar]
pause>nul
cls
echo. Realizando download - GITHUB
echo. -------------------------------------
cd C:\>nul
@md git>nul
@cd git>nul
git clone %link_repositorio%
echo [Pressione uma tecla para continuar]
pause>nul
echo. Criando banco de dados - SQLServer
echo. -------------------------------------
cd %pastaprojeto%
cd Documentos
cd ScriptsBancoDeDados
echo %cd%
pause
echo Deletando Banco de dados
sqlcmd -S localhost  -i DeletaBancoDeDados.sql
echo Criando novo Banco de dados
sqlcmd -S localhost  -i CriaBancoDeDados.sql
echo Criando tabelas
sqlcmd -S localhost  -i CriaTabelas.sql
cd ..
cd ..
explorer %cd%
pause





