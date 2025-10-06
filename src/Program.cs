using TrackingWorker.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configure URLs explicitly
builder.WebHost.UseUrls("http://localhost:5000");

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure our SOLID architecture services
builder.Services.ConfigureServices();

var app = builder.Build();

// Enable Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// Hello World endpoint
app.MapGet("/", () => "Hello World from TrackingWorker API!")
    .WithName("GetHelloWorld");

// Map controllers for User API endpoints
app.MapControllers();

Console.WriteLine("🚀 TrackingWorker API is running on http://localhost:5000");
Console.WriteLine("📚 Swagger UI available at http://localhost:5000/swagger");
Console.WriteLine("📄 Swagger JSON available at http://localhost:5000/swagger/v1/swagger.json");
Console.WriteLine("💡 Press Ctrl+C to gracefully shutdown the application");

// Configure graceful shutdown
var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => {
    e.Cancel = true; // Prevent immediate termination
    Console.WriteLine("\n🛑 Shutdown signal received. Gracefully shutting down...");
    cts.Cancel();
};

try
{
    await app.RunAsync(cts.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("✅ Application shutdown completed.");
}
finally
{
    await app.DisposeAsync();
}
