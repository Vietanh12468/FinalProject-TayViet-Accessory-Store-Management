using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Services;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<AccountDatabaseServices>();
builder.Services.AddSingleton<CustomerDatabaseServices>();
builder.Services.AddSingleton<SellerDatabaseServices>();
builder.Services.AddSingleton<AdminDatabaseServices>();
builder.Services.AddSingleton<CategorySectionDatabaseService>();
builder.Services.AddSingleton<BrandDatabaseServices>();
builder.Services.AddSingleton<ProductDatabaseService>();
builder.Services.AddSingleton<OrderHistoryDatabaseService>();
builder.Services.AddSingleton<MainMigration>();

builder.Services.AddSingleton<IProductService, ProductService>();

MigrationService migrationService = new MigrationService(builder.Services.BuildServiceProvider().GetService<MainMigration>());
migrationService.CheckForUpdate();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
