using DiscordBot.App.Services;
using DiscordBot.Domain.Exceptions;
using DiscordBot.Domain.Interfaces;
using DiscordBot.Domain.ValueTypes;
using DiscordBot.Extensions;
using System;
using System.Linq;
using System.Net.NetworkInformation;
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

            _discordService.ChatCommandReceived += OnChatCommandReceived;
        }

        private async void OnChatCommandReceived(object sender, ChatCommandEventArgs args)
        {
            if (string.Compare(args.CommandName, "pinghost", StringComparison.OrdinalIgnoreCase) != 0)
                return;

            if (args.CommandArguments.Count() < 1)
                return;

            var host = args.CommandArguments.First();

            string responseMessage;

            try
            {
                var ping = new Ping();
                var reply = ping.Send(host);
                responseMessage = $"Ping to host '{host}' response: {reply.Status}";
            }
            catch (Exception ex)
            {
                responseMessage = $"Error pinging: {ex.GetInnermostException().Message}";
            }

            await args.ChatMessage.Channel.SendMessageAsync(responseMessage).ConfigureAwait(false);
        }
    }
}
