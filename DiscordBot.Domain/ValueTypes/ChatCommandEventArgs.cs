using Discord;
using System;
using System.Collections.Generic;

namespace DiscordBot.Domain.ValueTypes
{
    public class ChatCommandEventArgs : EventArgs
    {
        public IMessage ChatMessage { get; set; }
        public string CommandText { get; set; }
        public string CommandName { get; set; }
        public IEnumerable<string> CommandArguments { get; set; }
    }
}
