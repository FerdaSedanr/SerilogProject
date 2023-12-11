using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//appsetting.json ile conf.
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();


//adding file
//var logger = new LoggerConfiguration()
//  .ReadFrom.Configuration(builder.Configuration)
//  .Enrich.FromLogContext()
//  .CreateLogger();

//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);

//builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
//	loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));


//builder.Host.UseSerilog((ctx, lc) => lc
//	.WriteTo.Seq("http://localhost:5341")
//	.MinimumLevel.Verbose()
//	.WriteTo.File("logs/log.txt")
//	.WriteTo.MSSqlServer(connectionString: "Data Source=LAPTOP-U226G4BV;Initial Catalog=LOG;Integrated Security=True",
//   sinkOptions: new MSSqlServerSinkOptions
//   {
//	   TableName = "Logs", // Loglarýn yazýlacaðý SQL tablosunun adý
//	   AutoCreateSqlTable = true // Tablo otomatik olarak oluþturulsun mu?
//   })
//	);

//// Serilog ve Seq konfigürasyonu
//Log.Logger = new LoggerConfiguration()
//	.WriteTo.Console()
//	.WriteTo.Seq("http://localhost:5341") // Seq sunucu adresinizi buraya ekleyin
//	.CreateLogger();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


//app.UseSerilogRequestLogging();

app.Run();