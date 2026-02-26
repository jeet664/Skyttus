namespace Assessment14.Services.Interfaces
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message);
    }
}