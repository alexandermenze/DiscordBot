using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordBot.App
{
    internal class Program
    {
        private const string DiscordTokenKey = "DISCORD_TOKEN";

        internal static async Task Main(string[] args)
        {
            Console.WriteLine("Starting...");

            var client = new DiscordSocketClient();
            client.Log += Client_OnLog;
            client.MessageReceived += Client_OnMessageReceived;

            await client.LoginAsync(TokenType.Bot, GetDiscordToken()).ConfigureAwait(true);
            await client.StartAsync().ConfigureAwait(true);

            await Task.Delay(-1);
        }

        private static Task Client_OnMessageReceived(SocketMessage arg)
        {
            Console.WriteLine($"Message: {arg.Content}");
            return Task.CompletedTask;
        }

        private static Task Client_OnLog(LogMessage arg)
        {
            Console.WriteLine($"Log: {arg.Message}");
            return Task.CompletedTask;
        }

        private static string GetDiscordToken()
        {
            var token = Environment.GetEnvironmentVariable(DiscordTokenKey, EnvironmentVariableTarget.Process);

            if (token == null)
                token = Environment.GetEnvironmentVariable(DiscordTokenKey, EnvironmentVariableTarget.User);

            if (token == null)
                token = Environment.GetEnvironmentVariable(DiscordTokenKey, EnvironmentVariableTarget.Machine);

            return token;
        }
    }
}
