using ApiTimers.Data;
using ApiTimers.Helpers;
using ApiTimers.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(name: "v1", new OpenApiInfo
    {
        Title = "Api Timers",
        Version = "v1",
        Description = "Api Timers 2022"
    });
});

HelperToken helper = new HelperToken(builder.Configuration);
//AÑADIMOS AUTENTIFICACION A NUESTRO SERVICIO
builder.Services.AddAuthentication(helper.GetAuthOptions())
    .AddJwtBearer(helper.GetJwtOptions());


string cnn = builder.Configuration.GetConnectionString("sqltimers");
//AGREGAMOS LOS ELEMENTOS DE CONEXION
builder.Services.AddTransient<RepositoryTimers>();
builder.Services.AddDbContext<TimersContext>
    (options => options.UseSqlServer(cnn));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1");
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
