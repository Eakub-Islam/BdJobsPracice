using FluentValidation;
using FluentValidation.AspNetCore;
//using GymManagementSystem.AggregateRoots.MemberValidator;
using GymManagementSystem.DTO;
using GymManagementSystem.Handler;
using GymManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMemberServiceHandler, MemberServiceHandler>();

// Register FluentValidation for MemberDto
builder.Services.AddValidatorsFromAssemblyContaining<MemberDtoValidator>();

// Add FluentValidation to MVC pipeline
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters(); // Optional: for client-side validation in views

// Configure other services...
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
