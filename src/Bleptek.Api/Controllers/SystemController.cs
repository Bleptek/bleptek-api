using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using SendGrid;

namespace Bleptek.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly SendGridSettings _sendgridOptions;
        private readonly ISendGridClient _sendGridClient;

        public SystemController(
            IOptions<SendGridSettings> sendgridOptions,
            ISendGridClient sendGridClient)
        {
            _sendgridOptions = sendgridOptions.Value;
            _sendGridClient = sendGridClient;
        }

        /// <summary>
        /// Send email to Bleptek
        /// </summary>
        [HttpPost("sendContactEmail", Name = nameof(SendContactEmail))]
        public async Task<IActionResult> SendContactEmail([FromBody] SendContactEmailRequest body)
        {
            await SendMail(body.FullName, body.Email, body.Subject, body.Message);
            return NoContent();
        }

        private async Task SendMail(
            string fullName,
            string email,
            string subject,
            string message)
        {
            var msg = new SendGridMessage();
            msg.AddTo(_sendgridOptions.ContactMailToEmail, _sendgridOptions.ContactMailToName);
            msg.SetReplyTo(new EmailAddress(email, fullName));
            msg.SetFrom(_sendgridOptions.ContactMailFromEmail, _sendgridOptions.ContactMailFromName);
            msg.SetTemplateId(_sendgridOptions.ContactTemplateId);
            msg.SetTemplateData(new
            {
                fullName = fullName,
                email = email,
                subject = subject,
                message = message
            });

            var response = await _sendGridClient.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Body.ReadAsStringAsync();
                throw new Exception($"SendGrid invoked sending to with template {msg.TemplateId}, response {content} {response.Body}");
            }
        }
    }
}