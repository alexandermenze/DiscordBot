using Discord;
using System;

namespace DiscordBot.Domain.ValueTypes
{
    public class ChatMessageEventArgs : EventArgs
    {
        public IMessage ChatMessage { get; set; }
        public string Message { get; set; }
    }
}
