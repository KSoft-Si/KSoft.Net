using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KSoftNet;

namespace CustomHttpclient {
  internal static class Program {
    private const string Token = "{token}";

    private static void Main() {
      new ExampleClass(Token).GetRandomImage("birb").GetAwaiter().GetResult();
    }
  }

  public class ExampleClass {
    private readonly KSoftApi _kSoftApi;

    public ExampleClass(string token) {
      var httpClient = new HttpClient {
        BaseAddress = new Uri("https://api.ksoft.si"),
        DefaultRequestHeaders = {
          Authorization = new AuthenticationHeaderValue("Bearer", token)
        }
      };

      _kSoftApi = new KSoftApi(httpClient);
    }

    public async Task GetRandomImage(string tag) {
      var image = await _kSoftApi.ImagesApi.GetRandomImage(tag: tag);

      Console.WriteLine(image.Url);
    }
  }
}