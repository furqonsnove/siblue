using System.Data;
using HR_Service.Config;
using HR_Service.Contract;
using HR_Service.Data;
using HR_Service.Services;
using Npgsql;
using StackExchange.Redis;
using HR_Service.Data;
using HR_Service.Models.Enitty;
using HR_Service.Services.Positions.Implementations;
using HR_Service.Services.Positions.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Redis cache
var redisOptions = builder.Configuration.GetSection("Redis").Get<RedisOptions>();
var redis = ConnectionMultiplexer.Connect(redisOptions.ToString());
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);
builder.Services.AddStackExchangeRedisCache(options =>
{
  options.Configuration = redisOptions.ToString();
});

// PostgreSQL database
var connectionString = builder.Configuration.GetConnectionString("HRServiceDB");
builder.Services.AddTransient<NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));

//Add DB Context
builder.Services.AddDbContext<ApiDBContext>();

// Add services to the container.
builder.Services.AddScoped<ILogNotifService, LogNotifService>();
builder.Services.AddAutoMapper(typeof(MasterMaps).Assembly);
builder.Services.AddScoped<IPosition, PositionService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDBContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("HRServiceDB"));
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
