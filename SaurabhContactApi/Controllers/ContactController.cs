using Microsoft.AspNetCore.Mvc;
using SaurabhContactApi.Services;

namespace SaurabhContactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly EmailService _emailService;

        public ContactController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public IActionResult SendContactEmail([FromBody] ContactForm model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Message))
            {
                return BadRequest("Invalid data");
            }

            string subject = $"New message from {model.Name}";
            string body = $"<p>Name: {model.Name}</p>" +
                          $"<p>Email: {model.Email}</p>" +
                          $"<p>Phone: {model.Phone}</p>" +
                          $"<p>Message: {model.Message}</p>";

           _emailService.SendEmail("dnyaneshwarikhupase30@gmail.com", subject, body);


            return Ok("Email sent successfully");
        }
    }

    public class ContactForm
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
    }
}
