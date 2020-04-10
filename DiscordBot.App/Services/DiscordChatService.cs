﻿using Discord;
using Discord.WebSocket;
using DiscordBot.Domain.Exceptions;
using DiscordBot.Domain.Interfaces;
using DiscordBot.Domain.ValueTypes;
using System;
using System.Threading.Tasks;

namespace DiscordBot.App.Services
{
    public class DiscordChatService : IChatService
    {
        public event EventHandler<ChatMessageEventArgs> ChatMessageReceived;

        private DiscordSocketClient _client;

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
        {
            return Task.CompletedTask;
        }

        private Task Client_OnMessageReceived(SocketMessage arg)
        {
            return Task.CompletedTask;
        }
    }
}