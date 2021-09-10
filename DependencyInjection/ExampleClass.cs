using System.Threading.Tasks;
using KSoftNet;
using KSoftNet.Models.Images;

namespace DependencyInjection {
  public class ExampleClass {
    private readonly KSoftApi _kSoftApi;

    public ExampleClass(KSoftApi kSoftApi) {
      _kSoftApi = kSoftApi;
    }

    public async Task<Image> GetRandomImage(string tag) {
      var image = await _kSoftApi.ImagesApi.GetRandomImage(tag: tag);

      return image;
    }
  }
}