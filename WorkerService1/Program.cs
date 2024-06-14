namespace WorkerService1;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .UseWindowsService() // 添加這一行
            .ConfigureServices(services => { services.AddHostedService<Worker>(); })
            .Build();

        host.Run();
    }
}