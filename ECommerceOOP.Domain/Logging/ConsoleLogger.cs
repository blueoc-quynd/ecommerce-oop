namespace ECommerceOOP.ECommerceOOP.Domain.Logging;

// Ghi log ra console với timestamp
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"  [LOG {DateTime.Now:HH:mm:ss}] {message}");
    }
}
