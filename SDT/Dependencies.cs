using dotenv.net;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using SDT;

[ScenarioDependencies]
static IServiceCollection ConfigureDependencies()
{
    var services = new ServiceCollection();
    
    services.AddSingleton<DropboxClientFactory>();
    
    services.AddSingleton<IDropboxClient>(serviceProvider =>
    {
        DotEnv.Load();
        var accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN")!;
        
        var factory = serviceProvider.GetService<DropboxClientFactory>();
        return factory!.CreateDropboxClient(accessToken);
    });
    
    return services;
}
