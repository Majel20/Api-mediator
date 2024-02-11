
using MediatR;
using Microsoft.EntityFrameworkCore;
using FirstApi.Interfaces;
using FirstApi.Model;
using FirstApi.Repository;
using FirstApi.CQRS.Commands;
using FirstApi.CQRS.Handlers;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"),
       builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); });
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//builder.Services.AddScoped(typeof(IRequestHandler<UpdateProductCommand, Product>), typeof(UpdateProductHandler));

var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();