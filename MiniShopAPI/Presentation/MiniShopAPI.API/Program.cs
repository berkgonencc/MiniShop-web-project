using FluentValidation.AspNetCore;
using MiniShopAPI.Application.Validators.Products;
using MiniShopAPI.Infrastructure;
using MiniShopAPI.Infrastructure.Filters;
using MiniShopAPI.Infrastructure.Services.Storage.Azure;
using MiniShopAPI.Infrastructure.Services.Storage.Local;
using MiniShopAPI.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage<AzureStorage>();


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

