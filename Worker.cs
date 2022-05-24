using System.IO;

namespace XPlaneLogcleanup {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) {
            _logger = logger;
        }

        //TODO: Make this thing configurable.
        //TODO: Make it installable and run on startup.

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                String path = "C:\\Users\\byelo\\Desktop\\X-Plane Installer Log.txt";

                if (File.Exists(path)) {
                    File.Delete(path);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}