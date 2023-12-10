using Microsoft.EntityFrameworkCore;
using PackageDemo.Context;
using PackageDemo.Services;
using PackageDemo.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ITrackingNumberService, TrackingNumberService>();

builder.Services.AddDbContext<PackageContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Packages")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<PackageContext>().Database.EnsureCreatedAsync();
}

app.Run();
