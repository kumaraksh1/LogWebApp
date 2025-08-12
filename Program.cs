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
    // log.LogInformation("===========================");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:400000000025");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:300000000007");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:020000000013");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:130000000001");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:300000000007");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:020000000013");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:400000000025");
    // log.LogError("KH01 IK002:処理を開始します。");
    // log.LogError("KH01 IK003:処理を終了します。 トランザクションID:510000000031");
    // log.LogInformation("===========================");

    // log.LogInformation("##############################");
    // log.LogError("2025-07-14T01:52:35.4223689Z 2025-07-14 10:52:35.09l KH01 IK002：処理を開始します。");
    // log.LogInformation("##############################");
    log.LogInformation("***********************************");
    log.LogError("2025-07-14T01:52:35.0984989Z 2025-07-14 10:52:35.097 KH01 IK002:処理を開始します。");
    log.LogError("2025-07-14T01:52:35.4133115Z 2025-07-14 10:52:35.412 KH01 EK003:不正な値を検出しました。 トランザクションID:13A000003036、項目名:トランザクションID、明細取得結果詳細情報:10001");
    log.LogError("2025-07-14T01:52:35.4223689Z 2025-07-14 10:52:35.422 KH01 IK003:処理を終了します。 トランザクションID:13A000003036");
    log.LogInformation("***********************************");
    return "Logs pushed — check Azure Log Stream!";
});

app.Run();
