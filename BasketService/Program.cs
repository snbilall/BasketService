using Business;
using Core.Model;
using DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var cs = configurationRoot.GetSection("MongoDbConnection").Get<MongoConnectionOptions>();
builder.Services.Configure<MongoConnectionOptions>(configurationRoot.GetSection("MongoDbConnection"));
builder.Services.AddDataLayers(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddApiVersioning();

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
