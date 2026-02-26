using Microsoft.Extensions.Logging;

namespace Assessment14.Services
{
    public class SmsService
    {
        private readonly ILogger<SmsService> _logger;

        public SmsService(ILogger<SmsService> logger)
        {
            _logger = logger;
        }

        public Task SendSmsAsync(string number, string message)
        {
            _logger.LogInformation($"SMS Sent to {number}: {message}");
            return Task.CompletedTask;
        }
    }
}