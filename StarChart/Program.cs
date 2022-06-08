
using Microsoft.EntityFrameworkCore;
using StarChart.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("StarChart"));

var app = builder.Build();

app.MapControllers();

app.Run();
