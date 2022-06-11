using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Context;
using Tegu.Net.Backend.Shared.DataLayer;
using Tegu.Net.Backend.Shared.Services;
using Tegu.Net.Backend.Shared.Services.Authorization;
using Tegu.Net.Backend.WebApi.Classic.Managers;
using Tegu.Net.Backend.WebApi.Classic.Services.Repositories;

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

// configure strongly typed settings object
services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

services.AddTransient<TokenService>();

services.AddTransient<AuthenticationManager>();

services.AddTransient<IAuthRepository, AuthSqlRepository>();
services.AddTransient<IUserRepository, UserSqlRepository>();
services.AddTransient<ITeguRepository, TeguSqlRepository>();

services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.WriteIndented = true;
});

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
