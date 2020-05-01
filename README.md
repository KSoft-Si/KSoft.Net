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
	
Create an instance of the KSoftApi and ImagesApi classes: 
```cs
using KSoftNet.KSoft;

public class ExampleClass {
	string token = "token";

	KSoftApi kSoftApi;
	ImagesApi imagesApi;

	public void Setup() {
		kSoftApi = new KSoftApi(token);
		imagesApi = new ImagesApi(kSoftApi);
	}
}
```

An example implementation of the RandomImage method:
```cs
public void ExampleMethod(string tag) {
	KSoftImage image = imagesApi.RandomImage(tag: tag);
}
```


### Example using dependency injection

Create instances of the classes you're going to use, then create a ServiceCollection, add them to it, and then build the service provider:

```cs
using Microsoft.Extensions.DependencyInjection;
using KSoftNet.KSoft;

public class Program {

    static void Main(string[] args) {
        new Startup().Init();
    }
}

public class Startup {

    private KSoftAPI kSoftAPI;
    private ImagesAPI imagesAPI;

    private string token = "token123";

    public void Init() {
        ServiceCollection services = new ServiceCollection();

        kSoftAPI = new KSoftAPI(token);
        imagesAPI = new ImagesAPI(kSoftAPI);

        ConfigureServices(services);
        ServiceProvider provider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services) {
        services.AddSingleton(kSoftAPI);
        services.AddSingleton(imagesAPI);
    }
}
```

Using this in a class:

```cs
using KSoftNet.KSoft;

 public class ExampleClass {

    private ImagesAPI imagesApi;

    public ExampleClass(ImagesAPI imagesApi) {
        this.imagesApi = imagesApi;
    }

    public void GetRandomImage(string tag) {
        var image = imagesApi.RandomImage(tag: tag);

        Console.WriteLine(image.Url);
    }
}
```
