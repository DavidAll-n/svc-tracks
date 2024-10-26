using API.Filters;
using Infrastructure.Auth;
using Infrastructure.Auth.Interfaces;
using Infrastructure;
using API.Interfaces;
using API.Repositories;
using API.Services;
using API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddSingleton<IApiKeyValidation, ApiKeyValidation>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IFleetRepository, FleetRepository>();
builder.Services.AddScoped<IDataPointRepository, DataPointRepository>();
builder.Services.AddScoped<IFleetService, FleetService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<ILocationIngestionService, LocationIngestionService>();
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddSingleton<TxHub>();

var app = builder.Build();
app.MigrateTxDb();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapHub<TxHub>("/tx");
app.MapControllers();

app.Run();
