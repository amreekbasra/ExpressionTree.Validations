using ExpressionTree.DbValidations.Sample.utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionTree.DbValidations.Sample
{
    class Program
    {
        //static ILogger<Program> logger;
        public Program(ILoggerFactory _logger)
        {
           // logger = _logger.CreateLogger<Program>();
        }
        static async Task Main(string[] args)
        {
            //setup our DI
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug($"Starting application. Topic: {"topic"}. Entity: {"enty"}.");


            await GetStringCalled(logger);
            //async Task func()
            //{
            //    Console.WriteLine("Hello World I am there!");
            //    await Task.FromResult("");
            //}
            //await LogUtil.RunLogsAsync(logger,func);
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
            serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            serviceCollection.AddLogging(loggingBuilder => loggingBuilder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug));

            // Build configuration
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppContext.BaseDirectory)
            //    .AddJsonFile("appsettings.json", false)
            //    .Build();

            //// Add access to generic IConfigurationRoot
            //serviceCollection.AddSingleton(configuration);
        }
        public static async Task GetStringCalled(ILogger<Program> logger)
        {
             async Task func() 
            {
                await Task.Run(() => Console.WriteLine("Hello World I am there!"));
            };
            await LogUtil.RunLogsAsync(logger, func);
        }
    }
}
