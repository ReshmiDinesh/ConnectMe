global using Microsoft.EntityFrameworkCore;
global using ConnectMe.UserMicroService.Model;
using ConnectMe.UserMicroService.Data;
using ConnectMe.UserMicroService.Interface;
using ConnectMe.UserMicroService.Provider;
using Microsoft.Extensions.Options;
using ConnectMe.UserMicroService.Data.DataAccess;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add DBcontext to the Container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ConnectMeContext>(Options =>
{
    Options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var configuration = builder.Configuration;

// Add Dependencies
builder.Services.AddScoped<IUserProfileDataEF, UserProfileDataAccess>();
builder.Services.AddScoped<IUserProfileProvider, UserProfileProvider>();
builder.Services.AddScoped<IUserTypeProvider, UserTypeProvider>();

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
