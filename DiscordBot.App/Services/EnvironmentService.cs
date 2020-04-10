using DiscordBot.Domain.Interfaces;
using System;

namespace DiscordBot.App.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        public string GetVariable(string key)
        {
            var value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);

            if (value == null)
                value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);

            if (value == null)
                value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);

            return value;
        }
    }
}
