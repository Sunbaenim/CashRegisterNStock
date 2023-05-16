using CashRegisterNStock.API.Profiles;
using CashRegisterNStock.BLL.Services;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext
builder.Services.AddScoped<CrnsDbContextFactory>();
builder.Services.AddDbContext<CrnsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrnsDatabase"));
    options.EnableSensitiveDataLogging();
});
//AutoMapper
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductOrderMappingProfile));
//BLL Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductOrderService>();
//DAL Repositories
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductOrderRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("default", builder =>
    {
        //builder.WithOrigins("http://localhost:4200");
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
