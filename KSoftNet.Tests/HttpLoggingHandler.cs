using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace KSoftNet.Tests {
  public class HttpLoggingHandler : DelegatingHandler {
    public HttpLoggingHandler(HttpMessageHandler innerHandler = null)
      : base(innerHandler ?? new HttpClientHandler()) { }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
      var id = Guid.NewGuid().ToString();
      var msg = $"[{id} -   Request]";

      Console.WriteLine($"{msg}========Start==========");
      Console.WriteLine($"{msg} {request.Method} {request.RequestUri.PathAndQuery} {request.RequestUri.Scheme}/{request.Version}");
      Console.WriteLine($"{msg} Host: {request.RequestUri.Scheme}://{request.RequestUri.Host}");

      foreach (var (key, value) in request.Headers)
        Console.WriteLine($"{msg} {key}: {string.Join(", ", value)}");

      if (request.Content != null) {
        foreach (var (key, value) in request.Content.Headers)
          Console.WriteLine($"{msg} {key}: {string.Join(", ", value)}");

        if (request.Content is StringContent || IsTextBasedContentType(request.Headers) || request.Content is JsonContent || IsTextBasedContentType(request.Content.Headers)) {
          var result = await request.Content.ReadAsStringAsync();

          Console.WriteLine($"{msg} Content:");
          Console.WriteLine($"{msg} {string.Join("", result.Take(8192))}...");

        }
      }

      var start = DateTime.Now;

      var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

      var end = DateTime.Now;

      Console.WriteLine($"{msg} Duration: {end - start}");
      Console.WriteLine($"{msg}==========End==========");

      msg = $"[{id} - Response]";
      Console.WriteLine($"{msg}=========Start=========");

      Console.WriteLine($"{msg} {request.RequestUri.Scheme.ToUpper()}/{response.Version} {(int)response.StatusCode} {response.ReasonPhrase}");

      foreach (var (key, value) in response.Headers)
        Console.WriteLine($"{msg} {key}: {string.Join(", ", value)}");

      if (response.Content != null) {
        foreach (var (key, value) in response.Content.Headers)
          Console.WriteLine($"{msg} {key}: {string.Join(", ", value)}");

        if (response.Content is StringContent || IsTextBasedContentType(response.Headers) || IsTextBasedContentType(response.Content.Headers)) {
          start = DateTime.Now;
          var result = await response.Content.ReadAsStringAsync();
          end = DateTime.Now;

          Console.WriteLine($"{msg} Content:");
          Console.WriteLine($"{msg} {string.Join("", result.Take(8192))}...");
          Console.WriteLine($"{msg} Duration: {end - start}");
        }
      }

      Console.WriteLine($"{msg}==========End==========");

      return response;
    }

    private readonly string[] _types = { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

    private bool IsTextBasedContentType(HttpHeaders headers) {

      if (!headers.TryGetValues("Content-Type", out var values))
        return false;
      var header = string.Join(" ", values).ToLowerInvariant();

      return _types.Any(t => header.Contains(t));
    }
  }

}