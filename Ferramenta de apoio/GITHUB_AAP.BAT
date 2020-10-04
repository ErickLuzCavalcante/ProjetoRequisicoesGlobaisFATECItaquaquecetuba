@echo off
mode 60,40
TITLE CONTROLE DO GITHUB 1.0
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

cls
CALL :verificaPastaAtual
CALL :BARRA
ECHO.
ECHO. O P C O E S :
ECHO.
echo. 1. CRIAR PONTO DE RESTAURACAO NA SUA MAQUINA (OFFLINE)
echo. 2. SUBIR NA NUVEM OS PONTOS DE RESTAURACAO (ONLINE)
echo. 3. ABRIR PASTA DO PROJETO
echo. 4. DEIXAR CONFORME O GITHUB
echo. 0. Sair
Set /p opcao=" >> "
if %opcao% EQU 1 (goto :COMMIT)
if %opcao% EQU 2 (goto :PUSH)
if %opcao% EQU 3 (goto :abrir_pasta)
if %opcao% EQU 4 (call :baixar_codigo)
if %opcao% EQU 0 (exit)
echo.
echo opcao invalida, precione qualquer tecla para continuar
pause>null
goto :Menu


:abrir_pasta
explorer C:\GIT\%pastaprojeto%
goto :Menu

:baixar_codigo
cls
CALL :verificaPastaAtual
call :BARRA
ECHO. DEIXAR CONFORME O GITHUB
call :BARRA
ECHO.
ECHO. ATENCAO: NESTA OPCAO A PASTA DO PROJETO SERA REFEITA
ECHO.
ECHO. IREMOS APAGAR A PASTA DO PROJETO DESTA MAQUINA
ECHO. E INICIAREMOS O DOWNLOAD NOVAMENTE DO GITHUB
ECHO.
ECHO. POR ISSO TODAS AS ALTERACOES QUE NAO ESTEJAM 
ECHO. NO REPOSITORIO REMOTO SERAO APAGADAS
ECHO.
ECHO. PARA EVITAR ERROS, CERTIFIQUE-SE QUE 
ECHO. TENHA FECHADO TODOS OS ARQUIVOS RELACIONADOS
ECHO.
call :BARRA

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
Echo.
CALL :BARRA
ECHO.
ECHO. T E R M I N O   D A   E X C L U S A O 
ECHO.
CALL :BARRA
ECHO. CASO TENHA FICADO ALGUM ARQUIVO PARA TRAS 
ECHO. O DOWNLOAD AUTOMATICO NAO IRA INICIAR DEPOIS 
ECHO. DESSA TELA. NESSE CENARIO, REALIZE O LOGOFF
ECHO. OU REINICIE A MAQUINA E EXECUTE NOVAMENTE
ECHO. A FUNCAO DEIXAR CONFORME O GITHUB
ECHO.
ECHO.
PAUSE
)
GOTO :MENU

:clonar
cls
ECHO.
echo R E A L I Z A N D O   D O W N L O A D   D O   P R O J E T O
ECHO ----- %pastaprojeto%
ECHO.
CALL :BARRA
echo +   +   B A I X A N D O   +   + 
ECHO.
git clone %link_repositorio%
ECHO.
CALL :FINALIZADO
msg * "DOWNLOAD DO PROJETO FINALIZADO"
call :BARRA
pause
goto :Menu

:COMMIT
CALL :verificaPastaAtual
ECHO CRIAR PONTO DE RESTAURACAO NA SUA MAQUINA
CALL :BARRA
ECHO.
echo. B O A S   P R A T I C A S 
ECHO.
echo - SEJA SUCINTO
echo - A DESCRICAO TEM QUE SER RELACIONADA A ALTERACAO 
ECHO   REALIZADA.
echo - LEMBRE-SE QUE OUTROS IRAO ULTILIZAR ESSA DESCRICAO
echo - NAO COLOQUE SEU NOME OU QUALQUER OUTRA COISA QUE 
echo   NAO TENHA HAVER COM A MODIFICACAO, SEJA SUCINTO
echo.
Echo EXEMPLOS DE BOAS DESCRICOES
echo Criada a classe usuarios
echo Inserido objeto de conexao a classe Alunos
ECHO.
CALL :BARRA
Echo INSIRA A DESCRICAO DO PONTO DE RESTAURACAO
Set /p "Mensagem= >> "
ECHO.
ECHO PENSE ANTES DE CONTINUAR
ECHO.
pause
echo +   +   I N I C I A N D O   +   +  
cd %pastaprojeto%
git add .
git commit -m "%Mensagem%"
git status
CD ..
CALL :FINALIZADO
pause
goto :Menu

:PUSH
CLS
CALL :verificaPastaAtual
call :BARRA
echo. SUBIR NA NUVEM OS PONTOS DE RESTAURACAO
call :BARRA
ECHO.
echo. ESTA OPCAO SOBE OS PONTOS DE RESTAURACAO CRIADOS
ECHO. NESTA MAQUINA PARA O GITHUB
ECHO.
CALL :BARRA
ECHO.
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
CALL :FINALIZADO
)
ECHO.
ECHO.
echo VOLTANDO PARA O MENU
PAUSE
GOTO :MENU

:FINALIZADO
echo +   +   F I N A L I Z A D O   +   +
GOTO :EOF

:BARRA
ECHO ------------------------------------------------------------
GOTO :EOF

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
ECHO.
echo + + Sincronizando:
git pull
ECHO.
cd ..
goto :eof