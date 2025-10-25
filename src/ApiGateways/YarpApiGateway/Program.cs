using Microsoft.AspNetCore.RateLimiting;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);


//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(System.Net.IPAddress.Any, 8080, listenOptions =>
//    {
//        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
//    });

//    options.Listen(System.Net.IPAddress.Any, 8081);
//});

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(System.Net.IPAddress.Any, 8081, listenOptions =>
//    {
//        listenOptions.UseHttps(httpsOptions =>
//        {
//            try
//            {
//                httpsOptions.ServerCertificate = new X509Certificate2(
//                    "/home/app/.aspnet/https/aspnetapp.pfx"
//                );
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"WARNING: HTTPS certificate failed to load. Falling back to HTTP. Error: {ex.Message}");
//            }
//        });

//        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
//    });

//    options.Listen(System.Net.IPAddress.Any, 8080);
//});

// Add Services To Container

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

// Configure the HTTP Request Pipeline

app.UseRateLimiter();

app.MapReverseProxy();

app.Run();
