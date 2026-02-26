using Microsoft.AspNetCore.Mvc;
using Assessment14.Models;
using Assessment14.Services;

namespace Assessment14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        public NotificationController(
            EmailService emailService,
            SmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
            return Ok("Email Sent Successfully");
        }

        [HttpPost("send-sms")]
        public async Task<IActionResult> SendSms(string number, string message)
        {
            await _smsService.SendSmsAsync(number, message);
            return Ok("SMS Sent (Mock)");
        }
    }
}