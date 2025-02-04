using Viandas.Application.Interface;
using Viandas.Application.Main.UseCase.v1.Users;
using Viandas.Infrastructure.Data.Db;
using Viandas.Infrastructure.Interface.IRepositories;
using Viandas.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDb>();

//user
builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

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

app.UseAuthorization();

app.MapControllers();

app.Run();
