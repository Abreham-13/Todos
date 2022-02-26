using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Todos.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodosContext>(options => options
                .UseMySql("Server=localhost;Port=3366;Password=Abrilow@13;User=root; Database=my_Todo;",
                    new MySqlServerVersion(new Version(8, 0, 11))));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<TodosContext>();
// Add services to the container.

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
