/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Main entry point for the ItemApi Project
 **/

using ItemDataLibrary.Models;
using ItemDataLibrary.Configuration;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Implementations;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure Email Settings from User Secrets or Environment Variables
builder.Services.Configure<EmailConfiguration>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddDbContext<ItemApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDb"))
);

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

// Register password reset services
builder.Services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
builder.Services.AddScoped<SecureEmailService>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ItemApiContext>();

    context.Database.EnsureCreated();

    /* Seed admin user if no users exist
    if (!context.Users.Any())
    {
        context.Users.Add(new UserModel
        {
            UserName = "admin",
            FirstName = "System",
            LastName = "Administrator",
            Password = "admin123",
            Role = "Admin"
        });
        context.SaveChanges();
    }*/
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
