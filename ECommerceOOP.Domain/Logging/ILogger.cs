namespace ECommerceOOP.ECommerceOOP.Domain.Logging;

// Abstraction: tách biệt logic ghi log khỏi implementation cụ thể
public interface ILogger
{
    void Log(string message);
}
