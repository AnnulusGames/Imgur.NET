# Imgur.NET
 Imgur API client for .NET and Unity.

[![NuGet](https://img.shields.io/nuget/v/Imgur.NET.svg)](https://www.nuget.org/packages/Imgur.NET)
[![Releases](https://img.shields.io/github/release/AnnulusGames/Imgur.NET.svg)](https://github.com/AnnulusGames/Imgur.NET/releases)
[![GitHub license](https://img.shields.io/github/license/AnnulusGames/Imgur.NET.svg)](./LICENSE)

English | [日本語](README_JA.md)

## Overview

Imgur.NET is a client library for the [Imgur API](https://apidocs.imgur.com/) designed for .NET.

> [!NOTE]
> Currently, Imgur.NET supports APIs for OAuth2.0 authentication, as well as Image, Album, and Comment functionalities. Features like Account and Gallery are not yet available and are planned to be implemented by v1.0.

## Installation

Imgur.NET is distributed via NuGet and supports .NET Standard 2.1, .NET 6.0, and .NET 8.0.

### .NET CLI
```
dotnet add package Imgur.NET
```

### Package Manager

```
Install-Package Imgur.NET
```

Additionally, Imgur.NET can be used with Unity. See the [Unity](#unity) section for details.

## Basic Usage

You can call the Imgur API using the `ImgurClient` class.

```cs
using System.IO;
using Imgur;

using var client = new ImgurClient
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET"
};

// Read the image file
var image = await File.ReadAllBytesAsync("image.png");

// Upload the image
var response = await client.Image.UploadAsync(new()
{
    ImageData = image,
    ImageContentType = ImageContentType.Raw,
});

// Get the image URL
Console.WriteLine(response.Link);
```

## Authentication

Some APIs require OAuth2.0 authentication. You can get the authentication URL using `GetAuthorizationUrl()`.

```cs
using var client = new ImgurClient
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET"
};

// Get the authorization URL
var url = client.Authorization.GetAuthorizationUrl();
```

After authentication, set the obtained Access Token in the `ImgurClient`.

```cs
client.AccessToken = "YOUR_ACCESS_TOKEN";
```

To reissue an Access Token using a Refresh Token, use `GenerateAccessTokenAsync()`.

```cs
var response = await client.Authorization.GenerateAccessTokenAsync(new()
{
    RefreshToken = "YOUR_REFRESH_TOKEN"
});

var newAccessToken = response.AccessToken;
var newRefreshToken = response.RefreshToken;
```

## Image

Operations like retrieving and uploading images are done through `ImgurClient.Image`.

```cs
// Retrieve an image
var image1 = await client.Image.GetAsync(new()
{
    ImageHash = "imageHash"
});

var bytes = await File.ReadAllBytesAsync("image.png");

// Upload an image
var uploadedImage = await client.Image.UploadAsync(new()
{
    ImageData = bytes,
    ImageContentType = ImageContentType.Raw,
});

// Delete an image
await client.Image.DeleteAsync(new()
{
    ImageHash = "imageHash"
});
```

## Album

Album operations are done through `ImgurClient.Album`.

```cs
// Retrieve an album
var album = await client.Album.GetAsync(new()
{
    AlbumHash = "albumHash"
});

// Create a new album
var newAlbum = await client.Album.CreateAsync(new()
{
    Ids = ["image1", "image2"],
    Title = "New Album",
    Description = "Album description",
})

// Delete an album
await client.Album.DeleteAsync(new()
{
    AlbumHash = "albumHash"
});
```

## Comment

Operations like retrieving and posting comments are done through `ImgurClient.Comment`.

```cs
// Retrieve a comment
var comment = await client.Comment.GetAsync(new()
{
    CommentId = 123456789,
});

// Post a comment
var newComment = await client.Comment.CreateAsync(new()
{
    ImageId = "image1",
    Comment = "Comment text"
});

// Delete a comment
client.Comment.DeleteAsync(new()
{
    CommentId = 123456789
});
```

## Exception Handling

If an API call fails, an `ImgurException` will be thrown.

```cs
try
{
    var response = await client.Images.GetAsync(new()
    {
        ImageHash = "...",
    });
}
catch (ImgurException ex)
{
    Console.WriteLine((int)ex.Status);
    Console.WriteLine(ex.Message);
}
```

## Customizing HttpClient

`ImgurClient` uses the standard `HttpClient` for communication. If you want to adjust the behavior of HttpClient, you can pass an `HttpClientHandler` during its creation.

```cs
public class ImgurClient : IDisposable
{
    readonly HttpClient httpClient;
    public HttpClient HttpClient => httpClient;

    public ImgurClient(HttpMessageHandler handler, bool disposeHandler)
    {
        httpClient = new(handler, disposeHandler);
    }

    public ImgurClient()
        : this(new HttpClientHandler(), true)
    {
    }

    public ImgurClient(HttpMessageHandler handler)
        : this(handler, true)
    {
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}
```

## Unity

Imgur.NET can be used with Unity. To install Imgur.NET in Unity, use [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity).

1. Install NugetForUnity
2. Open the Nuget > Manage NuGet Packages window, search for Imgur.NET, and install it

When using it in environments like WebGL, you need to replace the communication layer with UnityWebRequest. Here is an example using [UnityWebRequestHttpMessageHandler.cs](https://gist.github.com/neuecc/854192b8d176170caf2c53fa7589dc90).

```cs
// Change HttpClientHandler to UnityWebRequestHttpMessageHandler
var client = new ImgurClient(new UnityWebRequestHttpMessageHandler())
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET",
    AccessToken = "YOUR_ACCESS_TOKEN",
    ConfigureAwait = true // Set ConfigureAwait to true for safe operation in WebGL
};
```

## License

This library is under the MIT License.