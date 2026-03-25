using TruckBackend.Services;
using TruckBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Host=postgres;Database=truckdb;Username=postgres;Password=postgres";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ShippingService>();
builder.Services.AddScoped<TruckService>();
builder.Services.AddDbContext<TruckContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TruckContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapGet("/", () => "API is running");

app.Run();

