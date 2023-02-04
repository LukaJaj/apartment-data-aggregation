using data_aggregation;
using data_aggregation.Repository;
using data_aggregation.Repository.Interfaces;
using data_aggregation.Services;
using data_aggregation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICsvParserService, CsvParserService>();
builder.Services.AddScoped<IApartmentDataAggregatorService, ApartmentDataAggregatorService>();
builder.Services.AddScoped<IApartmentAggregatorRepository, ApartmentAggregatorRepository>();


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

