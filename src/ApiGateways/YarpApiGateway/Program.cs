var builder = WebApplication.CreateBuilder(args);

// Add Services To Container

var app = builder.Build();

// Configure the HTTP Request Pipeline

app.Run();
