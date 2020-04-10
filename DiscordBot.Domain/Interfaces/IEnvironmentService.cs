namespace DiscordBot.Domain.Interfaces
{
    public interface IEnvironmentService
    {
        string GetVariable(string key);
    }
}
