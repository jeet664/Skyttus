using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assessment14.Services
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly ILogger<NotificationBackgroundService> _logger;
        private readonly EmailService _emailService;

        public NotificationBackgroundService(
            ILogger<NotificationBackgroundService> logger,
            EmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Background Job Running at: {time}", DateTime.Now);

                    await _emailService.SendEmailAsync(
                        "prajapatijeet645@gmail.com",
                        "Background Notification",
                        $"This email was sent at {DateTime.Now}");

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in Background Service");
                }
            }
        }
    }
}