using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VisitorsNationality.Models;
using VisitorsNationality.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<VisitorsDatabaseSettings>(
    builder.Configuration.GetSection(nameof(VisitorsDatabaseSettings)));

builder.Services.AddSingleton<IVisitorsDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<VisitorsDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("VisitorsDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IVisitorsService, VisitorsService>();

builder.Services.AddControllersWithViews();

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
