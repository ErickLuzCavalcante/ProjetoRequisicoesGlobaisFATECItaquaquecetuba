@echo off
TITLE GITHUB BY ERICK 1.O ALFA
set link_repositorio="https://github.com/ErickLuzCavalcante/ProjetoRequisicoesGlobaisFATECItaquaquecetuba"
set pastaprojeto=ProjetoRequisicoesGlobaisFATECItaquaquecetuba


if not exist C:\git (
echo.
echo. L E I A   C O M   A T E N C A O 
ECHO.
ECHO. ESTA EH A PRIMEIRA VEZ QUE VOCE ESTA ABIRNDO ESTE APLICATIVO
ECHO.
echo. ATENCAO, tenha certeza que vc iniciou o processo como administrador.
echo.
Echo. COMO ASSIM:
echo. Feche a esta aplicacao e abra da seguinte forma.
Echo. Clicando com o botao direito no icone e indo em executar como administrador.
echo. Isso so precisa ser feito uma vez.
echo.
echo. Temos que executar dessa forma para poder criar no C: deste computador
echo. a pasta C:\GIT, que eh onde sera salvo o nosso projeto
echo.
echo. Caso vc ja tenha feito isso, podemos seguir, basta precionar qualquer tecla.
echo.
echo. att, Erick Cavalcante -  BackEnd
echo.
echo. PS. Esse aplicativo foi feito em um dia, qualquer bug, favor me reportar
pause
md C:\GIT
ECHO PASTA GIT EM C: CRIADA 
PING -T 0.0.0.0>nul
CALL :verificaPastaAtual
)





:Menu
mode 60,40
cls
CALL :verificaPastaAtual
echo. CENTRAL DE COMANDOS GIT
echo. RAMOS:
cd %pastaprojeto%
git branch
echo.
echo ------------------------------------------------------
ECHO. Nao deixe seu ramo configurado para master
ECHO. caso a master esteja verde, use a opcao 3
echo ------------------------------------------------------
echo.
cd ..
ECHO OPCOES:
echo. 1. Criar ponto de restauracao LOCALMENTE
echo. 2. Subir os pontos de restauracao para o GITHub
echo. 3. Selecionar ramo
echo. 4. Abrir pasta do projeto
echo. 5. Deixar conforme o GITHUB
echo. 0. Sair
Set /p opcao=" >> "
if %opcao% EQU 1 (goto :COMMIT)
if %opcao% EQU 2 (goto :PUSH)
if %opcao% EQU 3 (goto :RAMO)
if %opcao% EQU 4 (explorer C:\GIT)
if %opcao% EQU 5 (call :baixar_codigo)
if %opcao% EQU 0 (exit)
echo opcao invalida, precione qualquer tecla para continuar
pause>null
goto :menu

:baixar_codigo
cls
CALL :verificaPastaAtual
mode 100, 40

ECHO ESTA FUNCAO SERVE PARA ATUALIZAR SUA MAQUINA COM OS ULTIMOS UPDATES DO
ECHO PROJETO NO GITHUB
echo. 
echo QUALQUER PONTO QUE NAO ESTEJA SALVO REMOTAMENTE, SERA DESFEITO
echo isso é aquelas que nao tenham sido sincronizadas pela opcao 1 e depois a 2
echo.
ECHO ESSA FUNCAO ALTERA OS ARQUIVOS DA PASTA QUE NAO ESTAO IGUAIS AO GITHUB
ECHO.
ECHO ANTES DE USAR TENHA CERTEZA QUE SALVOU AS MODIFICACOES NECESSARIA 
ECHO NO SERVIDOR. opcao 1 e depois a 2
ECHO.
ECHO ---------------------------------------------------------------------
echo CASO TENHA CORROMPIDO ALGUM ARQUIVO NA SUA MAQUINA
ECHO E DESEJA UMA COPIA EXATA DO QUE ESTA NO GITHUB
echo SIGA OS SEGUINTES PASSOS:
echo.
echo Passo 1: NA TELA DE MENU DESTE APLICATIVO
echo .........SELECIONE A OPCAO 4 E EXCLUA A PASTA %pastaprojeto%
echo .........Ou va para o caminho C:\GIT e exclua a pasta %pastaprojeto%
ECHO.
echo Passo 2: REABRA O APLICATIVO PARA QUE ELE POSSA FAZER O DOWNLOAD
echo. 
ECHO ---------------------------------------------------------------------
ECHO.
echo TEM CERTEZA? (Precione 1 para sim)
set CERTEZA=0
Set /p CERTEZA=" >> "
if  %CERTEZA% EQU 1 (
echo +   +   B A I X A N D O   +   + 
cd %pastaprojeto%
git add .
git commit -m "Realizado sincronizacao com o servidor"
git status
git pull
git reset --hard origin~
CD..
echo +   +   F I N A L I Z A D O   +   +
)
ECHO.
ECHO.
echo VOLTANDO PARA O MENU
PAUSE
GOTO :MENU

:Ramo
CLS
echo RAMOS DISPONIVEIS
cd %pastaprojeto%
git branch
ECHO.
Echo DIGITE O NOME DE UM RAMO EXISTENTE
ECHO CONFORME A ORIETACAO DA SUA EQUIPE
echo o item em verde eh o que esta ativo
echo OBS. NAO USE A MASTER

SET /P RAMO=">> "
echo TEM CERTEZA? (Precione 1 para sim)
set CERTEZA=0
Set /p CERTEZA=" >> "
if  %CERTEZA% EQU 1 (
	ECHO +   +   T R O C A N D O   D E   R A M O   +   + 
	git checkout %RAMO%
)
cd ..
goto :MENU


:clonar
cls
mode 100, 40
echo ATENCAO: PASTA DE PROJETO NAO ENCONTRADA
echo REALIZANDO O DOWNLOAD DO PROJETO QUE ESTA GITHUB... AGUARDE..
ECHO.
echo +   +   B A I X A N D O   +   + 
git clone %link_repositorio%
echo +   +   F I N A L I Z A D O   +   +
msg * "DOWNLOAD DO PROJETO FINALIZADO"
pause
echo.
echo.
echo.
echo.
ECHO ---------------------------------------------------------------------
echo CASO TENHA TIDO ALGUMA FALHA NO DOWNLOAD DO PROJETO
echo SIGA OS SEGUINTES PASSOS:
echo.
echo Passo 1: QUANDO IRMOS PARA A TELA DE MENU DESTE APLICATIVO
echo .........SELECIONE A OPCAO 4 E EXCLUA A PASTA %pastaprojeto%
echo .........Ou va para o caminho C:\GIT e exclua a pasta %pastaprojeto%
ECHO.
echo Passo 2: REABRA O APLICATIVO PARA QUE ELE POSSA FAZER O DOWNLOAD
ECHO.
ECHO NAO DEIXE UM PROJETO CORROMPIDO NA SUA MAQUINA LOCAL
echo. 
ECHO ---------------------------------------------------------------------
pause
goto :Menu


:COMMIT
cls
CALL :verificaPastaAtual
mode 100, 40

Echo insira a descricao da modificacao feita
echo + BOAS PRATICAS
echo - TEM QUE SER SUCINTO
echo - TEM QUE TER RELACAO COM A MODIFICACAO REALIZADA
echo - LEMBRE-SE QUE OUTROS IRAO ULTILIZAR ESSA DESCRICAO
echo - NAO COLOQUE SEU NOME OU QUALQUER OUTRA COISA QUE 
echo   NAO TENHA HAVER COM A MODIFICACAO, SEJA SUCINTO
echo.
Echo ++ Exemplos de descricao
echo Criada a classe usuarios
echo Inserido objeto de conexao a classe Alunos
Set /p "Mensagem= >> "
pause
echo +   +   I N I C I A N D O   +   +  
cd %pastaprojeto%
git add .
git commit -m "%Mensagem%"
git status
CD ..
echo +   +   F I N A L I Z A D O   +   +
pause
goto :Menu


:PUSH
CLS
CALL :verificaPastaAtual
echo ESTA OPCAO SALVA AS ALTERACOES DO PROJETO NESTA MAQUINA PARA O GITHUB
echo TEM CERTEZA? (Precione 1 para sim)
set CERTEZA=0
Set /p CERTEZA=" >> "
if  %CERTEZA% EQU 1 (
echo +   +   I N I C I A N D O   +   +
cd %pastaprojeto%  
git push 
CD ..
echo +   +   F I N A L I Z A D O   +   +
)
ECHO.
ECHO.
echo VOLTANDO PARA O MENU
PAUSE
GOTO :MENU


:verificaPastaAtual
cd C:\
@md git
cd git
if %CD%  NEQ C:\GIT (
mode 80, 14
COLOR C
ECHO Nao foi possivel encontrar a pasta de repositorios neste computador
echo pasta atual = %cd%
echo pasta GIT = C:\GIT
pause
exit
)
if not exist %pastaprojeto% (
call :clonar
)
goto :eof



