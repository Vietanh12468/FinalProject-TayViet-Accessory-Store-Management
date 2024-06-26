using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<AccountDatabaseServices<Account>>();
builder.Services.AddSingleton<AccountDatabaseServices<Customer>>();
builder.Services.AddSingleton<AccountDatabaseServices<Admin>>();
builder.Services.AddSingleton<AccountDatabaseServices<Seller>>();
builder.Services.AddSingleton<CategorySectionDatabaseService>();
builder.Services.AddSingleton<BrandDatabaseServices>();
builder.Services.AddSingleton<ProductDatabaseService>();
builder.Services.AddSingleton<OrderHistoryDatabaseService>();
builder.Services.AddSingleton<MainMigration>();

MigrationService migrationService = new MigrationService(builder.Services.BuildServiceProvider().GetService<MainMigration>());
migrationService.CheckForUpdate();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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