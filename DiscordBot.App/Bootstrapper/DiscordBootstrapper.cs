using DiscordBot.App.Services;
using DiscordBot.Domain.Exceptions;
using DiscordBot.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace DiscordBot.App.Bootstrapper
{
    public class DiscordBootstrapper
    {
        private const string DiscordTokenKey = "DISCORD_TOKEN";

        private readonly IEnvironmentService _environmentService;
        private readonly DiscordChatService _discordService;

        public DiscordBootstrapper(IEnvironmentService environmentService, DiscordChatService discordService)
        {
            _environmentService = environmentService;
            _discordService = discordService;
        }

        public async Task Connect()
        {
            var token = _environmentService.GetVariable(DiscordTokenKey);

            if (token == null)
                throw new ChatServiceConnectException("No token found in environment!");

            try
            {
                await _discordService.Connect(token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ChatServiceConnectException("Error during connect!", ex);
            }
        }
    }
}
