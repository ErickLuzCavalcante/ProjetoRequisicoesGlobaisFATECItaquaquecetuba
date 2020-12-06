using requisicoesGlobais.Models;
using System;
using System.IO;
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
			try
			{
				string nomeArquivo = "";
				string arquivoEnviados = "";
				foreach (var arquivo in requerimento.Arquivos)
				{
					if (arquivo.ContentLength > 0)
					{
						nomeArquivo = Path.GetFileName(arquivo.FileName);
						var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
						arquivo.SaveAs(caminho);
						requerimento.criar_requerimento();
						SendMail("erickl.cavalcante@gmail.com",caminho);

					}

					arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;
				}
				ViewBag.Mensagem = "Arquivos enviados  : " + arquivoEnviados + " , com sucesso.";
			}
			catch (Exception ex)
			{
				ViewBag.Mensagem = "Erro : " + ex.Message;
			}
		
			
            return Redirect("Requerimento/Requerimento");
        }

        public bool SendMail(string email, string caminho )
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("samuelsales81@gmail.com"); // ocultado por privacidade

                // Destinatario seta no metodo abaixo

                //ContrÃ³i o MailMessage
                _mailMessage.CC.Add("erickl.cavalcante@gmail.com");
                _mailMessage.Subject = "Olokinho Vou trancar";
                _mailMessage.IsBodyHtml = true;
				_mailMessage.Attachments.Add(new Attachment(caminho));



				_mailMessage.Body = "<b>OlÃ¡ Tudo bem ?? Vou trancar </b><p>Teste ParÃ¡grafo</p>";

                //CONFIGURAÃ‡ÃƒO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", int.Parse("587"));

                //CONFIGURAÃ‡ÃƒO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticaÃ§Ã£o)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("samuelsaleschaotic@gmail.com", "Dsl5002*"); // ocultado por privacidade

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