using System.Security.Claims;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MiniShopAPI.API.Configurations.ColumnWriters;
using MiniShopAPI.Application;
using MiniShopAPI.Application.Validators.Products;
using MiniShopAPI.Infrastructure;
using MiniShopAPI.Infrastructure.Filters;
using MiniShopAPI.Infrastructure.Services.Storage.Azure;
using MiniShopAPI.Infrastructure.Services.Storage.Local;
using MiniShopAPI.Persistence;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

//Serilog
Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true, columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message", new RenderedMessageColumnWriter() },
        {"message_template", new MessageTemplateColumnWriter() },
        {"level", new LevelColumnWriter() },
        {"time_stamp", new TimestampColumnWriter() },
        {"exception", new ExceptionColumnWriter() },
        {"log_event", new LogEventSerializedColumnWriter() },
        {"user_name", new UsernameColumnWriter()},
    })
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog(log);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // www.bilmemne.com - kimin kullanacağını belirler.
            ValidateIssuer = true, // www.myapi.com - kimin dağıttığını ifade eder.
            ValidateLifetime = true, // Oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır.
            ValidateIssuerSigningKey = true, // Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden security key verisinin doğrulanmasıdır.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            //JWT üzerinde name claim'ine karsılık gelen değeri user.Identity.Name property'sinden elde edebiliriz.
            //Hangi kullanıcının istek yaptığını öğreniriz.
            NameClaimType = ClaimTypes.Name
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context,next) => {

    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name",username);

    await next();
});

app.MapControllers();

app.Run();

