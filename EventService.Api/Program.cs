using EventService.Api.Data.Context;
using EventService.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEventManagerService, EventManagerService>();
builder.Services.AddScoped<ITicketPackageService, TicketPackageService>();

builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("CategoryService", client =>
{
    var baseUrl = builder.Configuration["CategoryServiceBaseUrl"]
              ?? throw new InvalidOperationException("CategoryServiceBaseUrl is not configured.");
    client.BaseAddress = new Uri(baseUrl);
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.Run();
