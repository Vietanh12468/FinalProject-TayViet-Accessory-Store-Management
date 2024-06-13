using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for file and console logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    //.WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

//builder.Host.ConfigureLogging();

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
