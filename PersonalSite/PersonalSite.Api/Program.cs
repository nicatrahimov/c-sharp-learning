using PersonalSite.Api.SqlConnection;
using PersonalSite.Persistence;
using PersonalSite.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();
builder.Services.AddControllers();
builder.Services.AddScoped<IDbConnectionStringProvider, DbConnectionStringProvider>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();