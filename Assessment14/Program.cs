using Assessment14.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom services
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<SmsService>();
builder.Services.AddHostedService<NotificationBackgroundService>();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();