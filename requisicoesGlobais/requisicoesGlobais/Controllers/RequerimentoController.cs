using requisicoesGlobais.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace requisicoesGlobais.Controllers
{
    public class RequerimentoController : Controller
    {
        // GET: Requerimento
        public ActionResult Requerimento()
        {
            if (Session["Usuario"] != null)
            {

                //var db = new DBRequerimento();
                //var tipos = db.buscarTipos();



                return View();
            }
            else

                return Redirect("Login/Login");
        }
        [HttpPost]
        public ActionResult Enviar(Requerimento requerimento)
        {
            Models.Usuarios usuarios = new Models.Usuarios();
            usuarios.cpf_usuario = Session["Usuario"].ToString();
            usuarios.consultar_usuario();
            usuarios.id_usuario = usuarios.id_login;
            usuarios.listar_por_idUsuario();
            requerimento.id_aluno = usuarios.id_aluno;
            requerimento.criar_requerimento();
            SendMail("erickl.cavalcante@gmail.com");
            return Redirect("Cadastrar/Cadastrar");
        }

        public bool SendMail(string email)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("envaido para"); // ocultado por privacidade

                // Destinatario seta no metodo abaixo

                //ContrÃ³i o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Teste Thiago";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "<b>OlÃ¡ Tudo bem ??</b><p>Teste ParÃ¡grafo</p>";

                //CONFIGURAÃ‡ÃƒO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", int.Parse("587"));

                //CONFIGURAÃ‡ÃƒO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticaÃ§Ã£o)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("emailderecebimento", "senha"); // ocultado por privacidade

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}