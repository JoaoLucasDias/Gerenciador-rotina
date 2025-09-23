using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace Gerenciador_rotina
{
 

    public class EmailHelper
    {
        public static void EnviarEmailRedefinicao(string emailDestino, string codigo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jld150109@gmail.com");
                mail.To.Add(emailDestino);
                mail.Subject = "Redefinição de Senha";
                mail.Body = $"Olá! Seu código para redefinir a senha é: {codigo}\n" +
                            "Esse código expira em 15 minutos.";

                // Servidor SMTP do Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("jld150109@gmail.com", "lsyn rlme bodp vbvv");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar e-mail: " + ex.Message);
            }
        }

       

       
    }

}
