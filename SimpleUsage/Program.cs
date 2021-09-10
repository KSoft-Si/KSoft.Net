using System;
using System.Threading.Tasks;
using KSoftNet;

namespace SimpleUsage {
  internal static class Program {
    private const string Token = "{token}";

    private static void Main() {
      new ExampleClass(Token).GetRandomImage("birb").GetAwaiter().GetResult();
    }
  }

  public class ExampleClass {
    private readonly KSoftApi _kSoftApi;

    public ExampleClass(string token) {
      _kSoftApi = new KSoftApi(token);
    }

    public async Task GetRandomImage(string tag) {
      var image = await _kSoftApi.ImagesApi.GetRandomImage(tag: tag);

      Console.WriteLine(image.Url);
    }
  }
}