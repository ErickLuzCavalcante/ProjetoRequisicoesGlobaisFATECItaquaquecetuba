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
@md C:\GIT>nul
ECHO PASTA GIT EM C: CRIADA 
PING -T 0.0.0.0>nul
CALL :verificaPastaAtual
)





:Menu
mode 60,40
cls
CALL :verificaPastaAtual

ECHO OPCOES:
echo. 1. CRIAR PONTO DE RESTAURACAO NA SUA MAQUINA
echo. 2. SUBIR NA NUVEM OS PONTOS DE RESTAURACAO
echo. 3. Abrir pasta do projeto
echo. 4. Deixar conforme o GITHUB
echo. 0. Sair
Set /p opcao=" >> "
if %opcao% EQU 1 (goto :COMMIT)
if %opcao% EQU 2 (goto :PUSH)
if %opcao% EQU 3 (explorer C:\GIT)
if %opcao% EQU 4 (call :baixar_codigo)
if %opcao% EQU 0 (exit)
echo opcao invalida, precione qualquer tecla para continuar
pause>null
goto :menu

:baixar_codigo
cls
CALL :verificaPastaAtual
mode 100, 40

ECHO NESTA DO PROJETO SERA DELETADA DA SUA MAQUINA
ECHO E SERA REALIZADO UM NOVO DONWLOAD NO GITHUB
ECHO.
ECHO PARA SALVAR SEUS DADOS NO SERVIDOR ULTILIZE A OPCAO 1
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
cd \
cd git
ERASE /S /Q %pastaprojeto%
RD /S /Q %pastaprojeto%
echo +   +   F I N A L I Z A D O   +   +
)


GOTO :MENU




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
git checkout master
git pull --rebase origin master
git push -f origin master
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
@md git>nul
@cd git
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
cd %pastaprojeto%
cls
echo Sincronizando
git pull
cd ..
goto :eof