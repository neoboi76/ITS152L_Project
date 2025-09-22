using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Implementations;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<ItemApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDb"))
);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
