using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StocksAppAss;
using StocksAppAss.Entities;
using StocksAppAss.Repositeries;
using StocksAppAss.RepositeryContracts;
using StocksAppAss.ServiceContracts;
using StocksAppAss.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinnHubService,FinnHubService>();
builder.Services.AddScoped<IStockServices,StockServices>();
builder.Services.AddScoped<IStockRepositery, StockRepositery>();
builder.Services.AddDbContext<StockDbContext>(

    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")

    ));

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection(nameof(TradingOptions)));


Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
var app = builder.Build();
app.MapControllers();
app.UseStaticFiles();

app.Run();
