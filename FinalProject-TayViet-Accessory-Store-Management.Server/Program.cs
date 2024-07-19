using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using MongoDB.Driver;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings and services
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

// Register your MongoDB client and database
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDB"));
    return new MongoClient(settings);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase("YourDatabaseName"); // Replace "YourDatabaseName" with the actual database name
    return database;
});

// Register your account services
builder.Services.AddScoped<IAccountService, AccountService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Run migration
MigrationService migrationService = new MigrationService(builder.Services.BuildServiceProvider().GetService<MainMigration>());
migrationService.CheckForUpdate();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
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
