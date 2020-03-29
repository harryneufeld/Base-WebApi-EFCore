using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting up Service...");
            _logger.LogInformation("Initiating Database");
            // Initiate Database
            var context = new Database.Logic.MainDatabaseContext();
            if (context.Database.CanConnect())
            {
                _logger.LogInformation("Datenbankverbindung konnte hergestellt werden. Starte Migration.");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    string errorMessage = "Fehler bei der Migration der Datenbank:" + Environment.NewLine + e.Message + Environment.NewLine +
                        "----------------" + Environment.NewLine +
                        "Inner Exception: " + Environment.NewLine + e.InnerException + Environment.NewLine +
                        "----------------" + Environment.NewLine +
                        "Stack Trace: " + Environment.NewLine + e.StackTrace;
                    _logger.LogError(e, errorMessage);
                    Console.ReadKey();
                }
            } else
            {
                _logger.LogWarning("Can't connect to Database. Stopping now.");
                Console.ReadKey();
                base.StopAsync(stoppingToken);
                return;
            }

            _logger.LogInformation("Successfully Migrated Database. Service now running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
