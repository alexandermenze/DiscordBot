using System;

namespace DiscordBot.Domain.Exceptions
{
    public class ChatServiceConnectException : ChatServiceException
    {
        public ChatServiceConnectException()
        {
        }

        public ChatServiceConnectException(string message)
            : base(message)
        {
        }

        public ChatServiceConnectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
