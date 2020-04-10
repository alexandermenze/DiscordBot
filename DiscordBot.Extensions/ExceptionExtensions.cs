using System;

namespace DiscordBot.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetInnermostException(this Exception ex)
        {
            var current = ex;

            while (current.InnerException != null)
                current = current.InnerException;

            return current;
        }
    }
}
