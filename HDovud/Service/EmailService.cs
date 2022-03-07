using System.Threading.Tasks;
using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace HDovud.Service
{
    public class EmailService : IEmailService
    {
        private  EmailSettings _options;

        public EmailService(IOptions<EmailSettings> options)
        {
            _options = options.Value;
        }

        public async Task SendAsync(EmailRequest request){
            var emailMessage = new MimeMessage(){
                Subject = request.Subject,
                Body = new TextPart(request?.IsHtmlBody ?? true ? TextFormat.Html: TextFormat.RichText){
                    Text = request.Body
                }
            };

            emailMessage.From.Add(new MailboxAddress(_options.DisplayName,_options.EmailFrom));
            emailMessage.To.Add(MailboxAddress.Parse(request.To));
            using var client = new SmtpClient();
            await client.ConnectAsync(_options.SmtpHost,_options.SmtpPort,false);
            await client.AuthenticateAsync(_options.SmtpUser, _options.SmtpPass);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);

        }
    }
}