using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using TMS_managerAPI.DB;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("TMS");

builder.Services.AddDbContext<TMSDbContext>(options =>
        options.UseSqlServer(connString));
// Add services to the container.
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
