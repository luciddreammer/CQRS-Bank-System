using Microsoft.EntityFrameworkCore;
using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Services;
using CQRSBankSystem.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.UseInlineDefinitionsForEnums();
});
builder.Services.AddDbContext<CQRSBankSystemContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDataBase")));
builder.Services.AddTransient<RegistrationService>();
builder.Services.AddTransient<LoginService>();
builder.Services.AddTransient<EventService>();
builder.Services.AddTransient<MoneyService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IMoneyRepository, MoneyRepository>();
builder.Services.AddHostedService<BackgroundCheckService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

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


