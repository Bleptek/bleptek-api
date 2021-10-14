namespace Bleptek.Api
{
    public class Appsettings
    {
        public string ASPNETCORE_ENVIRONMENT { get; set; }
        public SendGridSettings SendGrid { get; set; }
    }

    public class SendGridSettings
    {
        public string ApiKey { get; set; }
        public string ContactTemplateId { get; set; }
        public string ContactMailToName { get; set; }
        public string ContactMailToEmail { get; set; }
        public string ContactMailFromEmail { get; set; }
        public string ContactMailFromName { get; set; }
    }
}