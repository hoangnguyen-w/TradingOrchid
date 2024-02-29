using Microsoft.EntityFrameworkCore;
using TradingOrchid.Model.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Setting Database Sql Server
var connectionString = builder.Configuration.GetConnectionString("TradingOrchidSystem") ??
    throw new InvalidOperationException("Connection string 'TradingOrchidSystem' not found.");

builder.Services.AddDbContext<TradingOrchidContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
