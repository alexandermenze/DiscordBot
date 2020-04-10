using System;

namespace DiscordBot.Domain.Exceptions
{
    public class ChatServiceException : Exception
    {
        public ChatServiceException()
        {
        }

        public ChatServiceException(string message)
            : base(message)
        {
        }

        public ChatServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
