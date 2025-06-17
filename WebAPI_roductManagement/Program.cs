using Microsoft.EntityFrameworkCore;
using WebAPI_roductManagement.Models;
using WebAPI_roductManagement.Sevicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddControllers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProductFlowDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));// alias de nuestra conexion
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
