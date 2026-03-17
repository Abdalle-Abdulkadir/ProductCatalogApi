using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Data;
using ProductCatalogApi.Models;
using ProductCatalogApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb"));


builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
