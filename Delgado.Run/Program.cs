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

            var url = "https://localhost:59595";
            builder.Services.AddScoped(sp => new HttpClient
            { 
                BaseAddress = new Uri(url),
                
            });
           
            var host = builder.Build();
            await host.RunAsync();
        }
    }
}
