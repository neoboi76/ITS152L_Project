using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Implementations;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

// Update Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ItemApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDb"))
);

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>(); // NEW

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>(); // NEW

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ItemApiContext>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed admin user if no users exist
    if (!context.Users.Any())
    {
        context.Users.Add(new UserModel
        {
            UserName = "admin",
            FirstName = "System",
            LastName = "Administrator",
            Password = "admin123", // Change this!
            Role = "Admin"
        });
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
