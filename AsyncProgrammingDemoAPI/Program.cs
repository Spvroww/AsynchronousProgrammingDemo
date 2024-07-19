using AsyncProgrammingDemoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IoAsyncTestMethods>();
builder.Services.AddScoped<CpuAsyncTestMethods>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/TestIoAsync", async (IoAsyncTestMethods _testMethod, ILogger<Program> _logger) =>
{
    _logger.LogInformation($"IO bound async request started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
    await _testMethod.Run();
    _logger.LogInformation($"IO bound async request ended at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
    return "Done";
})
.WithName("TestIoAsync")
.WithOpenApi();

app.MapGet("/TestCpuAsync", async (CpuAsyncTestMethods _testMethod, ILogger<Program> _logger) =>
{
    _logger.LogInformation($"CPU bound async request started at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
    await _testMethod.Run();
    _logger.LogInformation($"CPU bound async request ended at Thread: {Thread.CurrentThread.ManagedThreadId}\n");
    return "Done";
})
.WithName("TestCpuAsync")
.WithOpenApi();

app.Run();


