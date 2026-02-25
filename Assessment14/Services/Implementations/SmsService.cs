using Microsoft.Extensions.Logging;

public class SmsService : ISmsService
{
    private readonly ILogger<SmsService> _logger;

    public SmsService(ILogger<SmsService> logger)
    {
        _logger = logger;
    }

    public async Task SendSmsAsync(string number, string message)
    {
        await Task.Delay(500);

        _logger.LogInformation($"SMS SENT → To: {number}, Message: {message}");
    }
}