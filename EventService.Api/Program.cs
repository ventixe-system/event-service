var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
