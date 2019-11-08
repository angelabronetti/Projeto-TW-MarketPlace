using System;
using System.Net;
using System.Net.Mail;

namespace trabalho.Utils
{
    public class EmailUtils
    {

        public bool EnvioEmail(string email, string titulo, string corpo/*, string anexo*/)
        {
            try
            {
                //Instancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();

                //Remetente
                _mailMessage.From = new MailAddress("cups.coffeempty@gmail.com");//email da empresa

                //Destinatario seta noo método abaixo

                //Constrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = corpo;
                /*_mailMessage.Attachments.Add(new Attachment(anexo));*/

                //Configuração com Conta
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("cups.coffeempty@gmail.com", "Projetosenai132");
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