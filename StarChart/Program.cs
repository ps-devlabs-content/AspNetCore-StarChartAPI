
using Microsoft.EntityFrameworkCore;
using StarChart.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("StarChart"));
var app = builder.Build();

app.MapControllers();

app.Run();
