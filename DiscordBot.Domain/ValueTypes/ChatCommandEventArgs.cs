using Discord;
using System;

namespace DiscordBot.Domain.ValueTypes
{
    public class ChatCommandEventArgs : EventArgs
    {
        public IMessage ChatMessage { get; set; }
        public string Command { get; set; }
    }
}
