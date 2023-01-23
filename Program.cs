using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Waste_Food_Management;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Waste_Food_Management.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));





var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
startup.Configure(app, builder.Environment); // calling Configure method
