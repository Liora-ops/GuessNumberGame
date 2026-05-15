using Microsoft.Extensions.DependencyInjection;
using GuessNumberGame.Interfaces;
using GuessNumberGame.Logic;
using GuessNumberGame.Services;

namespace GuessNumberGame.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameServices(this IServiceCollection services)
        {
            services.AddSingleton<IOutputService, ConsoleOutputService>();
            services.AddSingleton<IInputService, ConsoleInputService>();
            services.AddSingleton<IInputValidator, NumberInputValidator>();
            services.AddSingleton<IRandomNumberGenerator, RandomNumberGeneratorService>();
            services.AddSingleton<IGameLogic, GuessNumberGameLogic>();
            services.AddSingleton<IGameConfiguration, GameConfiguration>();
            services.AddSingleton<IGameController, GameController>();

            return services;
        }
    }
}