using System;
using System.Threading.Tasks;
using KSoftNet;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection {
  internal static class Program {

    private static void Main() {
      var startup = new Startup();
      startup.Init();
      startup.RunAsync().GetAwaiter().GetResult();
    }
  }

  public class Startup {
    private const string Token = "{token}";
    private KSoftApi _kSoftApi;

    private IServiceProvider _serviceProvider;

    public void Init() {
      var services = new ServiceCollection();

      _kSoftApi = new KSoftApi(Token);

      ConfigureServices(services);
      _serviceProvider = services.BuildServiceProvider();
    }

    public async Task RunAsync() {
      var exampleClass = _serviceProvider.GetService<ExampleClass>();

      var image = await exampleClass.GetRandomImage("birb");

      Console.WriteLine(image.Url);
    }

    private void ConfigureServices(IServiceCollection services) {
      services.AddSingleton(_kSoftApi);
      services.AddSingleton<ExampleClass>();
    }
  }

}