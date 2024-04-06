using BHD.Logger.Library;
using BHD.LogsSimulator.Mock;
using BHD.LogsSimulator.Services;
using ILogger = BHD.Logger.Library.Interfaces.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLogger(builder.Configuration);

builder.Services.AddScoped<IMockService, MockService>();
builder.Services.AddScoped<ILogGenerator, LogGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    // Get an instance of IMockService from the scope's service provider
    var mockService = scope.ServiceProvider.GetRequiredService<IMockService>();
    mockService.Start();
    // Now you can use mockService here
}

app.Run();
