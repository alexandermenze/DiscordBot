using Unity;

namespace DiscordBot.App.DependencyInjection
{
    public class Container
    {
        public static IUnityContainer Default { get; } = new UnityContainer();
    }
}
