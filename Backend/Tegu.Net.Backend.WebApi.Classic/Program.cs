using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Data.SQL.Entities;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

#region App Service Injections

void InitSqlDb()
{
    // Add services to the container.
    services.AddDbContextFactory<TeguSqlContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("SqlDb"))
                // For detailed Migration infos / values (only debug?)
                .EnableSensitiveDataLogging(),
        ServiceLifetime.Transient
    );

}

InitSqlDb();


services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region App Configuration

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
