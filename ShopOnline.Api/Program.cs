using Microsoft.Net.Http.Headers;
using ShopOnline.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddShopOnlineDataServices();

var app = builder.Build();

app.Services.SeedData(args.Length >= 1 && args[0].ToLower() == "seed");



// Configure the HTTP request pipeline.

app.UseCors(policy =>
{
    policy.WithOrigins("https://localhost:7258", "http://localhost:5258")
          .AllowAnyMethod()
          .WithHeaders(HeaderNames.ContentType);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
