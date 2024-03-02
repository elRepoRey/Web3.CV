using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;


namespace Delgado.Run
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            
            builder.Configuration.AddJsonFile("appsettings.json");

            var url = builder.Configuration["ApiUrl"] ?? "https://localhost:7036";
            builder.Services.AddScoped(sp => new HttpClient
            { 
                BaseAddress = new Uri(url),
                
            });
           
            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                var redirectUri = builder.Configuration["AzureAd:RedirectUri"];
                if (!string.IsNullOrWhiteSpace(redirectUri))
                {
                    options.ProviderOptions.Authentication.RedirectUri = redirectUri;
                }

            });

            var host = builder.Build();
            await host.RunAsync();
        }
    }
}
