using Viandas.Application.Interface.IDish;
using Viandas.Application.Interface.IFactory;
using Viandas.Application.Interface.IMenu;
using Viandas.Application.Interface.IUser;
using Viandas.Application.Main.Factories;
using Viandas.Application.Main.UseCase.v1.Dishes;
using Viandas.Application.Main.UseCase.v1.Menues;
using Viandas.Application.Main.UseCase.v1.Users;
using Viandas.Infrastructure.Data.Db;
using Viandas.Infrastructure.Interface.IRepositories;
using Viandas.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDb>();

//user
AddUserServices(builder);

//dish
AddDishServices(builder);

//menu
AddMenuServices(builder);

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
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

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();


static void AddUserServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICreateUser, CreateUser>();
    builder.Services.AddScoped<IQueryUser, QueryUser>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IDeleteUser, DeleteUser>();
}

static void AddDishServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IDishRepository, DishRepository>();
    builder.Services.AddScoped<ICreateDish, CreateDish>();
    builder.Services.AddScoped<IQueryDish, QueryDish>();
    builder.Services.AddScoped<IUpdateDishesPrice, UpdateDishesPrices>();
}

static void AddMenuServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IMenuFactory, MenuFactory>();
    builder.Services.AddScoped<IMenuRepository, MenuRepository>();
    builder.Services.AddScoped<ICreateMenu, CreateMenu>();
}