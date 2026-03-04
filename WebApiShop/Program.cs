//<<<<<<< HEAD
//﻿using Microsoft.EntityFrameworkCore;
//using NLog.Web;
//using Repository;
//using Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddDbContext<JewelryStoreContext>(options => 
//    options.UseSqlServer
//        (builder.Configuration.GetConnectionString("DefaultConnection")
//));

//=======
//﻿using System.Text.Json;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using NLog.Web;
//using Repository;
//using Services;
//var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseNLog();

//// Add services to the container.
//builder.Services.AddDbContext<JewelryStoreContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")
//    ));
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:4200") // הכתובת של אנגולר
//                  .AllowAnyHeader()
//                  .AllowAnyMethod();
//        });
//});

//<<<<<<< HEAD

//builder.Host.UseNLog();
//builder.Services.AddControllers();
//=======
////builder.Services.AddControllers();
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    });
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//builder.Services.AddOpenApi();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IPasswordService,PasswordService>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//<<<<<<< HEAD
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//var app = builder.Build();
//if(app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwaggerUI(Options =>
//    {
//        Options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
//    });
//}
//var logger = NLog.LogManager.GetCurrentClassLogger();
//logger.Info("Application started (env={env})", app.Environment.EnvironmentName);  
//// Configure the HTTP request pipeline.
//=======

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//var app = builder.Build();

//var logger = NLog.LogManager.GetCurrentClassLogger();
//logger.Info("Application started (env={env})", app.Environment.EnvironmentName);

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
//    });
//}



//// Configure the HTTP request pipeline.
//app.UseCors("AllowAngular");
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//<<<<<<< HEAD
//app.UseHttpsRedirection();

//app.UseCors("AllowAngular");
//=======
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//<<<<<<< HEAD
//=======

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddDbContext<JewelryStoreContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddOpenApi();

// Registration of Services and Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

var logger = NLog.LogManager.GetCurrentClassLogger();
logger.Info("Application started (env={env})", app.Environment.EnvironmentName);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();