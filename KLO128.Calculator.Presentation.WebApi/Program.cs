using KLO128.Calculator.Application.Contracts.Services;
using KLO128.Calculator.Application.Web;
using KLO128.Calculator.Domain;
using KLO128.Calculator.Domain.Repositories;
using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.Calculator.Domain.Shared;
using KLO128.Calculator.Infra.D3ORM;
using KLO128.Calculator.Infra.D3ORM.Repositories;
using KLO128.Calculator.Infra.D3ORM.SQLite;
using KLO128.D3ORM.Common;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.SQLite;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Localization;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infra services
builder.Services.AddScoped<ID3Context>(x => new SQLiteD3Context(EntityPropMappings.Dict));
builder.Services.AddScoped<IDbConnection>(x => new SqliteConnection(builder.Configuration.GetConnectionString(Constants.AppSettingKeys.DefaultConnectionString)));
builder.Services.AddScoped<ICalcHistoryRepository, D3CalcHistoryRepository>();
builder.Services.AddScoped<ICalcEntryRepository, D3CalcEntryRepository>();
builder.Services.AddScoped<IQueryContainer, QueryContainer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// domain services
builder.Services.AddScoped<ICryptoDomainService>(x => new CryptoDomainService("rdhe�f��f�ef�uf�ufg"));
builder.Services.AddScoped<ICultureDomainService, CultureDomainService>();
builder.Services.AddScoped<IExpressionVisitorDomainService, ExpressionVisitorDomainService>();
builder.Services.AddScoped<INumberFormatDomainService, NumberFormatDomainService>();
builder.Services.AddScoped<IExpressionDomainService, ExpressionDomainService>();
builder.Services.AddScoped<IComputeDomainService, ComputeDomainService>();
builder.Services.AddScoped<IHistoryDomainService, HistoryDomainService>();

// app services
builder.Services.AddScoped<IStringLocalizer>(
    x =>
    {
        return new MyLocalizer(Translations.ResourceManager, builder.Configuration[Constants.AppSettingKeys.DefaultCulture] ?? Constants.DefaultCulture);
    });
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

// utils
builder.Services.AddSingleton<IConfiguration>(x => builder.Configuration);
builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton<ILogger, Logger<LoggerFactory>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).AllowCredentials());

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
