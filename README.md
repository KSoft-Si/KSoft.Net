# KSoft.si API Wrapper

> http://api.ksoft.si

## Overview

[KSoft.Si API](http://api.ksoft.si) is a service that provides Discord bot developers or others the ease in getting content from the internet. We provide easy to use interface and take hard tasks away from developers.

## Getting started

### Installing the package

Add the NuGet package `KSoftNet` to your project:

```ps
dotnet add package KSoftNet
```

### Simple Example usage

You can use the wrapper with the images API for example like so:
Create an instance of the KSoftAPI class:

```cs
using KSoftNet;

public class ExampleClass {
	private string _token = "token";

	private KSoftAPI _kSoftAPI;

	public void Setup() {
		_kSoftAPI = new KSoftAPI(_token);
	}
}
```

An example implementation of the RandomImage method:

```cs
public void ExampleMethod(string tag) {
	KSoftImage image = _kSoftAPI.imagesAPI.RandomImage(tag: tag);
}
```

### Example using dependency injection

Create an instance of the KSoftAPI class, then create a ServiceCollection, add KSoftAPI to it, and then build the service provider:

```cs
using Microsoft.Extensions.DependencyInjection;
using KSoftNet;

public class Program {

    static void Main(string[] args) {
        new Startup().Init();
    }
}

public class Startup {

    private KSoftAPI _kSoftAPI;

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
```

Using this in a class:

```cs
using KSoftNet;

 public class ExampleClass {

    private KSoftAPI _kSoftAPI;

    public ExampleClass(KSoftAPI kSoftAPI) {
        _kSoftAPI = kSoftAPI;
    }

    public void GetRandomImage(string tag) {
        KSoftImage image = _kSoftAPI.imagesAPI.RandomImage(tag: tag);

        Console.WriteLine(image.Url);
    }
}
```
