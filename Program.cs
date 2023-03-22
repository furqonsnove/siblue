using System.Data;
using HR_Service.Config;
using Npgsql;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Redis cache
var redisOptions = builder.Configuration.GetSection("Redis").Get<RedisOptions>();
var redis = ConnectionMultiplexer.Connect(redisOptions.ToString());
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = redisOptions.ToString();
});

// PostgreSQL database
var connectionString = builder.Configuration.GetConnectionString("HRServiceDB");
builder.Services.AddTransient<NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
