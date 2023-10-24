using senior.application.Extensions;
using System.Net;
using System.Net.Mail;

namespace senior.application.Services;

public class EmailService
{
    public static bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Desafio balta.io",
        string fromEmail = "")
    {
        var smtpClient = new SmtpClient(SettingsExtension.Smtp.Host, SettingsExtension.Smtp.Port)
        {
            Credentials = new NetworkCredential(
            SettingsExtension.Smtp.Username,
            SettingsExtension.Smtp.Password),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = true
        };

        var mail = new MailMessage();

        mail.From = new MailAddress(fromEmail, fromName);
        mail.To.Add(new MailAddress(toEmail, toName));
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
