using Benefit.Services.Interfaces;
using Benefit.Services.Services;
using Benefit.Services.Extensions;
using Benefit.DataAccessLayer;
using Benefit.DataAccessLayer.Extensions;
using Serilog;
using Benefits.Web.Configurations;

Log.Logger = new LoggerConfiguration()
 .MinimumLevel.Debug()
 .WriteTo.File("logs/BenefitInfo", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
var conn = configuration.GetSection(nameof(ConnectionString)).Get<ConnectionString>();
builder.Services.CreateSqlRepository(conn.BenefitConnectionString);
provider = builder.Services.BuildServiceProvider();
var repository = provider.GetService<IBenefitRepository>();
builder.Services.CreateBenefitService(repository);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
