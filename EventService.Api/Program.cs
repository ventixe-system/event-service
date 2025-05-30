using EventService.Api.Data.Context;
using EventService.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEventManagerService, EventManagerService>();
builder.Services.AddScoped<ITicketPackageService, TicketPackageService>();

builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(policy => 
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
