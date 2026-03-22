using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Data;
using ProductCatalogApi.Models;
using ProductCatalogApi.Services;

var builder = WebApplication.CreateBuilder(args);

var apikey= builder.Configuration["ApiKey"];

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb"));


builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter("fixed", config =>
    {
        config.Window = TimeSpan.FromSeconds(10);
        config.PermitLimit = 2;
        config.QueueLimit = 0;
    });
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Categories.Add(new Category
    {
        Id = 1,
        Name = "Electronics",
        Description = "Tech products"
    });

    context.Suppliers.Add(new Supplier
    {
        Id = 1,
        Name = "Lenovo",
        Address = "Sweden"
    });

    context.Products.Add(new Product
    {
        Id = 1,
        Name = "Laptop",
        Description = "Lenovo Ideapad",
        Price = 12000,
        CategoryId = 1,
        SupplierId = 1
    });

    context.SaveChanges();

}


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();


// UseRouting is not needed in .NET 6+ (minimal hosting).
// Routing is handled automatically by MapControllers().

app.MapControllers(); 

app.Run();
