using Microsoft.EntityFrameworkCore;
using TaskBook.Core.Abstraction;
using TaskBook.Data;
using TaskBook.Middlewares;
using TaskBook.Services;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = true;
    opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Weekly;
    opt.SetExternalDbConnString = builder.Configuration.GetConnectionString("Default");
    opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureExceptionMiddleware();
app.MapControllers();
app.UseCors(options => options.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());


app.UseWatchDogExceptionLogger();
//uketesia admin da user shevinaxot uketes adgilas da iqidan wamovigot
app.UseWatchDog(opt =>
{
    opt.WatchPagePassword = "123";
    opt.WatchPageUsername = "admin";
});
app.Run();
