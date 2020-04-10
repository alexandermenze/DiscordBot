using DiscordBot.App.Bootstrapper;
using DiscordBot.App.DependencyInjection;
using DiscordBot.App.Services;
using DiscordBot.Domain.Interfaces;
using DiscordBot.Extensions;
using System;
using System.Threading.Tasks;
using Unity;

namespace DiscordBot.App
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            Console.WriteLine("Starting...");

            try
            {
                SetupDependencies();
                await SetupDiscord().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured during start: {ex.GetInnermostException().Message}");
                Console.WriteLine(ex);
                return;
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void SetupDependencies()
        {
            var container = Container.Default;

            container.RegisterType<IEnvironmentService, EnvironmentService>();
            container.RegisterType<DiscordChatService>(TypeLifetime.Singleton);
            container.RegisterType<DiscordBootstrapper>();
        }

        private static async Task SetupDiscord()
        {
            await Container.Default.Resolve<DiscordBootstrapper>().Connect().ConfigureAwait(false);
        }
    }
}
