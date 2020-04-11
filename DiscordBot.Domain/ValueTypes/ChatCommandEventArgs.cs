using System;

namespace DiscordBot.Domain.ValueTypes
{
    public class ChatCommandEventArgs : EventArgs
    {
        public string Command { get; set; }
    }
}
