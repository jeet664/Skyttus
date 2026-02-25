using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class NotificationBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<NotificationBackgroundService> _logger;

    public static DateTime LastRunTime { get; private set; }

    public NotificationBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<NotificationBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background Service Started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                var smsService = scope.ServiceProvider.GetRequiredService<ISmsService>();

                _logger.LogInformation("Running Scheduled Job...");

                await emailService.SendEmailAsync(
                    "jhprajapati06@gmail.com",
                    "Scheduled Email",
                    "This email is sent every 1 minute."
                );

                await smsService.SendSmsAsync(
                    "9426686457",
                    "Scheduled SMS every 1 minute"
                );

                LastRunTime = DateTime.Now;

                _logger.LogInformation("Scheduled Job Completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Background Service");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        _logger.LogInformation("Background Service Stopped");
    }
}