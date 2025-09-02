using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_rotina
{
    using System;
    using System.Net;
    using System.Net.Mail;

    public class EmailHelper
    {
        public static void EnviarEmailRedefinicao(string emailDestino, string codigo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("seuemail@gmail.com");
                mail.To.Add(emailDestino);
                mail.Subject = "Redefinição de Senha";
                mail.Body = $"Olá! Seu código para redefinir a senha é: {codigo}\n" +
                            "Esse código expira em 15 minutos.";

                // Servidor SMTP do Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("seuemail@gmail.com", "sua_senha_ou_senha_de_app");
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
