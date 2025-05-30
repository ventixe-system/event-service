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


//REMOVE THIS LINE IN PRODUCTION
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();
