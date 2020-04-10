using System;

namespace DiscordBot.Domain.ValueTypes
{
    public class ChatMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
