# KSoft.si API Wrapper

[![nuget version][0]][1]
[![downloads][2]][1]

> http://api.ksoft.si

## Overview

[KSoft.Si API](http://api.ksoft.si) is a professional, fast, reliable and easy to use multi-function service for Discord
bot developers or websites. It provides easy, no-nonsense endpoints with an extensive library of images, user data,
weather, geo-location and songs. We help you build awesome services and keep Discord community safe and sound.

### If you find any errors/issues or want any features added, [create an issue](https://github.com/KSoft-Si/KSoft.Net/issues/new/choose)

## Getting started

### Installing the package

Add the NuGet package `KSoftNet` to your project:

```ps
dotnet add package KSoftNet
```

### Simple usage

A minimal example to get a random image by tag

A complete example is available in the `examples/SimpleUsage` project

```cs
using System;
using System.Threading.Tasks;
using KSoftNet;

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
```

### Example using custom HttpClient

You can provide your own HttpClient instance, but you have to set the Authorization header and the BaseAddress manually

A complete example is available in the `examples/CustomHttpclient` project

```cs
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KSoftNet;

public ExampleClass(string token) {
  var httpClient = new HttpClient {
    BaseAddress = new Uri("https://api.ksoft.si"),
    DefaultRequestHeaders = {
      Authorization = new AuthenticationHeaderValue("Bearer", token)
    }
  };

  _kSoftApi = new KSoftApi(httpClient);
}
```

### Example using dependency injection

Create a ServiceCollection, then add an instance of the KSoftApi class to it

A complete example is available in the `examples/DependencyInjection` project

```cs
using System;
using System.Threading.Tasks;
using KSoftNet;
using Microsoft.Extensions.DependencyInjection;

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
```

Using this in a class:

```cs
using System.Threading.Tasks;
using KSoftNet;
using KSoftNet.Models.Images;

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
```

[0]: https://img.shields.io/nuget/v/KSoftNet?style=flat-square

[1]: https://www.nuget.org/packages/KSoftNet

[2]: https://img.shields.io/nuget/dt/KSoftNet?style=flat-square
