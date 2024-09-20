using Azure.Provisioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;
using utgiftsoversikt.Data;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddAzureCosmosClient("db");

builder.Services.AddDbContext<CosmosContext>(c => c.UseCosmos(builder.Configuration.GetConnectionString("cosmos"), "db"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBudgetRepo, BudgetRepo>();
builder.Services.AddScoped<IBudgetService, BudgetService>();

builder.Services.AddScoped<IMonthRepo, MonthRepo>();
builder.Services.AddScoped<IMonthService, MonthService>();

builder.Services.AddScoped<IExpenseRepo, ExpenseRepo>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();






// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
