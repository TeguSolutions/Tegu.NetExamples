using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

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
