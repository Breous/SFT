using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SFT.Data;
using SFT.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (required before Identity)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=sustainable_fashion.db"));

// Register Identity
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

var app = builder.Build();

// ✅ NEW: Ensure database and tables are created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // This will create the .db file and tables if missing
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // <-- Don't forget this!
app.UseAuthorization();

app.MapRazorPages();

app.Run();

