using Application.Interfaces;
using Application.Mapper;
using Application.UseCase;
using Infrastructure.Database;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//db
var connectionString = builder.Configuration["ConnectionStrings"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//dependencias 
builder.Services.AddTransient<IServiceContact, ServiceContact>();
builder.Services.AddTransient<ICommandContact, CommandContact>();
builder.Services.AddTransient<IQueryContact, QueryContact>();

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
