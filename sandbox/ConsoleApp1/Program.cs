using Imgur;

using var client = new ImgurClient
{
    ClientId = args[0],
    ClientSecret = args[1]
};

var bytes = await File.ReadAllBytesAsync("./image.png");

var response = await client.Image.UploadAsync(new()
{
    Image = bytes
});

Console.WriteLine(response);