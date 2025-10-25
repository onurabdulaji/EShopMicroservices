var builder = WebApplication.CreateBuilder(args);

// Add Services To Container

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure the HTTP Request Pipeline

app.MapReverseProxy();

app.Run();
