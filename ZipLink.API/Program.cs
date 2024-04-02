using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ZipLink.API.Extensions;
using ZipLink.Core;

const string _policy = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen(config =>
{
    config.OperationFilter<HeaderFilterExtension>();
});
builder.Services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
builder.Services.AddHealthChecks();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: _policy, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_policy);
app.UseHttpsRedirection();
app.MapHub<ChatHub>("chat-hub");
app.UseMiddleware<CustomMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
