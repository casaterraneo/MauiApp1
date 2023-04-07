using Microsoft.Extensions.Logging;
using MauiApp1.Data;
using MauiApp1.Auth0;
using Microsoft.AspNetCore.Components.Authorization;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        
        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-3dqhxvd2xq7lrnab.us.auth0.com",
            ClientId = "mNEnaUTTMwTIGTDA3FfAe8sQveVPP7oH",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, Auth0AuthenticationStateProvider>();
        

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddHttpClient(string.Empty, client =>
        {
            client.BaseAddress = new Uri("https://the-trivia-api.com/api/questions");
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}
