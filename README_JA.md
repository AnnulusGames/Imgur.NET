# Imgur.NET
 Imgur API client for .NET and Unity.

[![NuGet](https://img.shields.io/nuget/v/Imgur.NET.svg)](https://www.nuget.org/packages/Imgur.NET)
[![Releases](https://img.shields.io/github/release/AnnulusGames/Imgur.NET.svg)](https://github.com/AnnulusGames/Imgur.NET/releases)
[![GitHub license](https://img.shields.io/github/license/AnnulusGames/Imgur.NET.svg)](./LICENSE)

[English]((./README.md)) | 日本語

## 概要

Imgur.NETは.NET向けの[Imgur API](https://apidocs.imgur.com/)クライアントライブラリです。

> [!NOTE]
> 現在Imgur.NETはOAuth2.0認証用のAPIおよびImage、Album、Commentの機能をサポートしています。AccountやGalleryなどの機能はまだ用意されておらず、v1.0までに実装される予定です。

## インストール

Imgur.NETはNuGetで配布されており、.NET Standard2.1、.NET6.0、.NET8.0をサポートしています。

### .NET CLI
```
dotnet add package Imgur.NET
```

### Package Manager

```
Install-Package Imgur.NET
```

また、Imgur.NETはUnityでも利用可能です。詳細は[Unity](#unity)のセクションを参照してください。

## 基本的な使い方

`ImgurClient`クラスを通じてImgur APIの呼び出しを行うことができます。

```cs
using System.IO;
using Imgur;

using var client = new ImgurClient
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET"
};

// 画像ファイルを読み込み
var image = await File.ReadAllBytesAsync("image.png");

// 画像をアップロード
var response = await client.Images.UploadAsync(new()
{
    ImageData = image,
    ImageContentType = ImageContentType.Raw,
});

// 画像のURLを取得
Console.WriteLine(response.Link);
```

## 認証

一部のAPIを利用するにはOAuth2.0による認証が必要です。認証用のURLは`GetAuthorizationUrl()`から取得できます。

```cs
using var client = new ImgurClient
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET"
};

// 認証用のURLを取得
var url = client.Authorization.GetAuthorizationUrl();
```

認証後、取得したAccess Tokenを`ImgurClient`にセットします。

```cs
client.AccessToken = "YOUR_ACCESS_TOKEN";
```

また、Refresh Tokenを用いてAccess Tokenの再発行を行う場合には`GenerateAccessTokenAsync()`を利用できます。

```cs
var response = await client.Authorization.GenerateAccessTokenAsync(new()
{
    RefreshToken = "YOUR_REFRESH_TOKEN"
});

var newAccessToken = response.AccessToken;
var newRefreshToken = response.RefreshToken;
```

## Image

画像の取得やアップロードなどの操作は`ImgurClient.Image`を通じて行います。

```cs
// 画像を取得
var image1 = await client.Image.GetAsync(new()
{
    ImageHash = "imageHash"
});

var bytes = await File.ReadAllBytesAsync("image.png");

// 画像をアップロード
var uploadedImage = await client.Image.UploadAsync(new()
{
    ImageData = image,
    ImageContentType = ImageContentType.Raw,
});

// 画像を削除
await client.Image.DeleteAsync(new()
{
    ImageHash = "imageHash"
});
```

## Album

アルバムの操作は`ImgurClient.Album`を通じて行います。

```cs
// アルバムを取得
var album = await client.Album.GetAsync(new()
{
    AlbumHash = "albumHash"
});

// 新たなアルバムを作成
var newAlbum = await client.Album.CreateAsync(new()
{
    Ids = ["image1", "image2"],
    Title = "New Album",
    Description = "Album description",
})

// アルバムを削除
await client.Album.DeleteAsync(new()
{
    AlbumHash = "albumHash"
});
```

## Comment

コメントの取得や投稿などは`ImgurClient.Comment`を通じて行います。

```cs
// コメントを取得
var comment = await client.Comment.GetAsync(new()
{
    CommentId = 123456789,
});

// コメントを投稿
var newComment = await client.Comment.CreateAsync(new()
{
    ImageId = "image1"
    Comment = "Comment text"
});

// コメントを削除
client.Comment.DeleteAsync(new()
{
    CommendId = 123456789
});
```

## 例外処理

APIの呼び出しに失敗した場合は`ImgurException`がスローされます。

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

## HttpClientのカスタマイズ

`ImgurClient`は標準の`HttpClient`を使用して通信を行います。HttpClientの挙動を調整したい場合には、作成時に`HttpClientHandler`を渡します。

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

Imgur.NETはUnityで利用が可能です。Imgur.NETをUnityに導入するには[NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity)を使用します。

1. NugetForUnityをインストールする
2. Nuget > Manage NuGet Packagesからウィンドウを開き、Imgur.NETを検索してインストール

WebGLなどの環境で使用する場合、通信層をUnityWebRequestに置き換える必要があります。以下は[UnityWebRequestHttpMessageHandler.cs](https://gist.github.com/neuecc/854192b8d176170caf2c53fa7589dc90)を使用した例です。

```cs
// HttpClientHandlerをUnityWebRequestHttpMessageHandlerに変更する
var client = new ImgurClient(new UnityWebRequestHttpMessageHandler())
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET",
    AccessToken = "YOUR_ACCESS_TOKEN",
    ConfigureAwait = true // WebGLで安全に動作させるためにConfigureAwaitをtrueに設定
};
```

## ライセンス

このライブラリはMITライセンスの下で公開されています。