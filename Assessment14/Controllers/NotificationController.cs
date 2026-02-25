using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;

    public NotificationController(
        IEmailService emailService,
        ISmsService smsService)
    {
        _emailService = emailService;
        _smsService = smsService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send()
    {
        await _emailService.SendEmailAsync(
            "jeet202307100510135@gmail.com",
            "Manual Email from Ass14",
            "This email was triggered from Swagger."
        );

        await _smsService.SendSmsAsync(
            "9426686457",
            "Manual SMS from Swagger"
        );

        return Ok("Manual Notification Sent Successfully");
    }

    [HttpGet("status")]
    public IActionResult Status()
    {
        return Ok(new
        {
            LastExecution = NotificationBackgroundService.LastRunTime
        });
    }
}