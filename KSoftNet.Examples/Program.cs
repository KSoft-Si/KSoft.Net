using System;

namespace KSoftNet.Examples {
  internal static class Program {
    private static string _token = "";

    private static void Main(string[] args) {
      
    }
  }

  public class Startup {
    private KSoftApi _kSoftApi;

    private string _token = "token123";

    public void Init() {
      ServiceCollection services = new ServiceCollection();

      kSoftAPI = new KSoftAPI(_token);

      ConfigureServices(services);
      ServiceProvider provider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services) {
      services.AddSingleton(kSoftAPI);
    }
  }
}