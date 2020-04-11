using Discord;
using Discord.WebSocket;
using DiscordBot.Domain.Exceptions;
using DiscordBot.Domain.Interfaces;
using DiscordBot.Domain.ValueTypes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.App.Services
{
    public class DiscordChatService : IChatService
    {
        private const string CommandPrefix = "!";

        private DiscordSocketClient _client;

        public event EventHandler<ChatMessageEventArgs> ChatMessageReceived;
        public event EventHandler<ChatCommandEventArgs> ChatCommandReceived;

        public async Task Connect(string token)
        {
            if (_client != null)
                throw new ChatServiceConnectException("Already connected!");

            if (token == null)
                throw new ArgumentNullException(nameof(token));

            _client = new DiscordSocketClient();
            _client.Log += Client_OnLog;
            _client.MessageReceived += Client_OnMessageReceived;

            await _client.LoginAsync(TokenType.Bot, token).ConfigureAwait(false);
            await _client.StartAsync().ConfigureAwait(false);
        }

        private Task Client_OnLog(LogMessage arg)
            => Task.CompletedTask;

        private Task Client_OnMessageReceived(SocketMessage message)
        {
            if (HandleCommand(message))
                return Task.CompletedTask;

            ChatMessageReceived?.Invoke(this, new ChatMessageEventArgs { Message = message.Content });
            return Task.CompletedTask;
        }

        private bool HandleCommand(SocketMessage message)
        {
            if (!message.Content.StartsWith(CommandPrefix))
                return false;

            var command = message.Content.Substring(1);
            var commandParts = command.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            ChatCommandReceived?.Invoke(this,
                new ChatCommandEventArgs
                {
                    ChatMessage = message,
                    CommandText = command,
                    CommandName = commandParts[0],
                    CommandArguments = commandParts.Skip(1)
                });

            return true;
        }
    }
}