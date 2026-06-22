using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MailMessage();
        message.From = new MailAddress(_smtpSettings.SenderEmail);
        message.To.Add(new MailAddress(toEmail));
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port)
        {
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
            EnableSsl = true
        };

        await smtpClient.SendMailAsync(message);
    }
}