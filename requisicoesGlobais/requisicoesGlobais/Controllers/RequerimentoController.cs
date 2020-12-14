using requisicoesGlobais.Models;
using System;
using System.Diagnostics;
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
			if (ModelState.IsValid)
			{
				Models.Usuarios usuarios = new Models.Usuarios();
				usuarios.cpf_usuario = Session["Usuario"].ToString();
				usuarios.consultar_usuario();
				usuarios.id_usuario = usuarios.id_login;
				usuarios.listar_por_idUsuario();
				requerimento.id_aluno = usuarios.id_aluno;
				var justificativa = requerimento.justificativa_requerimento;
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
							int numemero_requerimento = requerimento.criar_requerimento();
							if (numemero_requerimento != 0)
							{
								requerimento.id_requerimento = numemero_requerimento;
								SendMail(usuarios, requerimento, caminho);
							}


						}

						arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;
					}
					//ViewBag.Mensagem = "Arquivos enviados  : " + arquivoEnviados + " , com sucesso.";
				}
				catch (Exception ex)
				{
					ViewBag.Mensagem = "Erro : " + ex.Message;
				}

			}
			else {
				ViewBag.Requerimento = "Houve uma falha ao enviar o requerimento";

				return View("Requerimento");
			}

			ViewBag.Requerimento = "Requerimento enviado com sucesso";


			return View("Requerimento");

		}

		public bool SendMail(Models.Usuarios usuarios, Models.Requerimento requerimento, string caminho )
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("samuelsales81@gmail.com"); //Não funciona
                Debug.WriteLine("Email do usuario " + usuarios.email_usuario);
                // Destinatario seta no metodo abaixo

                //Configurações da mensagem
                _mailMessage.CC.Add("requisicoesglobaisfatec@gmail.com");
                _mailMessage.CC.Add(usuarios.email_usuario);
                _mailMessage.Subject =  "Requerimento Golobal #"+requerimento.id_requerimento;
                _mailMessage.IsBodyHtml = true;
				_mailMessage.Attachments.Add(new Attachment(caminho));

                // Corpo do Email 
				_mailMessage.Body = "<p>Olá "+usuarios.nome_usuario+",<br> Foi criado a requisição global número <b> "+requerimento.id_requerimento+". </b>, <br> Como justificativa foi registrado:<br>"+requerimento.justificativa_requerimento+"<br>Peço que aguarde o contato da secretaria a continuidade do processo </p>";
               
                //Configuração da porta
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", int.Parse("587"));
                //SEM PORTA
               // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

               // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticaÃ§Ã£o)
               _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("requisicoesglobaisfatec@gmail.com", "sR]HG0|5p1"); // Credenciais do email

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