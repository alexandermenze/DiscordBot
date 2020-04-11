using DiscordBot.Domain.ValueTypes;
using System;

namespace DiscordBot.Domain.Interfaces
{
    public interface IChatService
    {
        event EventHandler<ChatMessageEventArgs> ChatMessageReceived;
        event EventHandler<ChatCommandEventArgs> ChatCommandReceived;
    }
}
