var builder = WebApplication.CreateBuilder(args);

// Configure logging to console (App Service will capture this)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddRazorPages();

var app = builder.Build();

// Get a logger for startup logs
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application starting at {Time}", DateTime.UtcNow);
logger.LogWarning("This is a sample warning log");
logger.LogError("This is a sample error log");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// A test endpoint for logging
app.MapGet("/log-test", (ILogger<Program> log) =>
{
    log.LogInformation("GET /log-test called at {Time}", DateTime.UtcNow);
    log.LogWarning("Testing warning log from /log-test");
    log.LogError("Testing error log from /log-test");
    return "Logs pushed — check Azure Log Stream!";
});

app.Run();
