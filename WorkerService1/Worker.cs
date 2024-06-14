namespace WorkerService1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await File.AppendAllTextAsync(@"C:\Temp\ServiceLog.txt", $"服務運行中: {DateTime.Now}\n", stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}