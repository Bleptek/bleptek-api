using System.ComponentModel.DataAnnotations;

namespace Bleptek.Api.Controllers
{
    public class SendContactEmailRequest
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}