using Assessment14.Models;
using Assessment14.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to use port 5001
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001);
});

// Bind SMTP Settings
builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings"));

// Register Services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddHostedService<NotificationBackgroundService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();